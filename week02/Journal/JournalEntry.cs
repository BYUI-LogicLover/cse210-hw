using System;

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
        
        // Override ToString for better display
        public override string ToString()
        {
            return $"[{Timestamp:yyyy-MM-dd HH:mm:ss}]|Prompt: {Prompt}|{Content}";
        }
        
        public static DateTime GetTimestamp(string timestamp) 
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
                        writer.WriteLine(entry.ToString());
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

        public static List<JournalEntry> LoadEntriesFromFile(string fileName)
        {
            string path = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(path, fileName);
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                List<JournalEntry> entries = new List<JournalEntry>();
                foreach (var line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        entries.Add(new JournalEntry(GetTimestamp(parts[0]), parts[1], parts[2]));
                    }
                }

                return entries;
            }

            return new List<JournalEntry>();
        }
    }
}