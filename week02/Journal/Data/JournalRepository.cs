using Microsoft.Data.Sqlite;

namespace Journal.Data;

public class JournalRepository
{
    private static readonly string DbFileName = "journal.sqlite3";
    private static readonly string DbFilePath = Path.Combine(AppContext.BaseDirectory, DbFileName);
    private static readonly string DbConnectionString = $"Data Source={DbFilePath};";
    
    public static void InitializeDatabase()
    {
        using (var connection = new SqliteConnection(DbConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    @"
                    CREATE TABLE IF NOT EXISTS Entry (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date DateTime NOT NULL,
                        Prompt TEXT NOT NULL,
                        Content TEXT NOT NULL
                    );
                ";
                command.ExecuteNonQuery();
                Console.WriteLine("Database initialized. 'Entry' table created or already exists.");
            }
        }
    }

    public static void InsertEntry(JournalEntry entry)
    {
        using (var connection = new SqliteConnection(DbConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    @"
                    INSERT INTO Entry (Date, Prompt, Content)
                    VALUES ($date, $prompt, $content);
                ";
                command.Parameters.AddWithValue("$date", entry.GetDateTime());
                command.Parameters.AddWithValue("$prompt", entry.GetPrompt());
                command.Parameters.AddWithValue("$content", entry.GetContent());
                command.ExecuteNonQuery();
            }
        }
    }

    public static List<JournalEntry> GetAllEntries()
    {
        List<JournalEntry> entries = new List<JournalEntry>();

        using (var connection = new SqliteConnection(DbConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    @"
                    SELECT Id, Date, Prompt, Content
                    FROM Entry;
                ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        JournalEntry entry = new JournalEntry(
                            reader.GetDateTime(1),
                            reader.GetString(2),
                            reader.GetString(3)
                        );
                        entries.Add(entry);
                    }
                }
            }
        }

        return entries;
    }

    public static void DeleteEntry(int id)
    {
        using (var connection = new SqliteConnection(DbConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    @"
                    DELETE FROM Entry
                    WHERE Id = $id;
                ";
                command.Parameters.AddWithValue("$id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}