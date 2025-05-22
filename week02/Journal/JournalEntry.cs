using System;
using Journal.Data;

namespace Journal
{
    public class JournalEntry
    {
        string Prompt { get; set; }
        string Content { get; set; }
        DateTime Timestamp { get; set; }

        // Constructor with parameters including custom timestamp
        public JournalEntry(DateTime timestamp, string prompt, string content)
        {
            Prompt = prompt;
            Content = content;
            Timestamp = timestamp;
        }

        public DateTime GetDateTime()
        {
            return Timestamp;
        }

        public string GetPrompt()
        {
            return Prompt;
        }

        public string GetContent()
        {
            return Content;
        }

        // Override ToString for better display
        public override string ToString()
        {
            return $"[{Timestamp:yyyy-MM-dd HH:mm:ss}]|Prompt: {Prompt}|{Content}";
        }

        private static DateTime GetTimestamp(string timestamp)
        {
            DateTime parsedTimestamp;
            timestamp = timestamp.Trim('[', ']');
            if (DateTime.TryParse(timestamp, out parsedTimestamp))
            {
                return parsedTimestamp;
            }
            else
            {
                throw new FormatException("Invalid timestamp format.");
            }
        }

        public static bool SaveEntriesToFile(List<JournalEntry> journalEntries, string fileName)
        {
            try
            {
                string path = Directory.GetCurrentDirectory();
                string filePath = Path.Combine(path, fileName);
                using (StreamWriter writer = new StreamWriter(filePath, append: false))
                {
                    foreach (var entry in journalEntries)
                    {
                        writer.WriteLine($"[{entry.Timestamp:yyyy-MM-dd HH:mm:ss}], {entry.Prompt}, {entry.Content}");
                    }

                    writer.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving entries: {ex.Message}");
                return false;
            }
        }

        public static List<JournalEntry> LoadEntriesFromFile(string fileName, List<JournalEntry> journalEntries)
        {
            string path = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(path, fileName);
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        // Check to see if the parts[0] already exists in journalEntries
                        if (journalEntries.Count > 0)
                        {
                            foreach (var entry in journalEntries)
                            {
                                if (entry.GetDateTime() == GetTimestamp(parts[0]))
                                {
                                    Console.WriteLine($"Entry with timestamp {parts[0]} already exists.");
                                }
                                else
                                {
                                    JournalRepository.InsertEntry(new JournalEntry(GetTimestamp(parts[0]), parts[1], parts[2]));
                                }
                            }
                        }
                    }
                }
            }
            return JournalRepository.GetAllEntries();
        }
    }
}