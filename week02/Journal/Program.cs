using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Journal;

class Program
{
    static void Main(string[] args)
    {
        JournalPromptGenerator promptGenerator = new JournalPromptGenerator();
        List<JournalEntry> journalEntries = new List<JournalEntry>();

        Console.WriteLine("Welcome to the Journal App!");

        while (true)
        {
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Enter a new journal entry");
            Console.WriteLine("2. View existing journal entries");
            Console.WriteLine("3. Save journal entries to a file");
            Console.WriteLine("4. Load journal entries from a file");
            Console.WriteLine("5. Exit");

            Console.Write("->");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.WriteLine("Please write your response:");

                    string content = Console.ReadLine();
                    JournalEntry journalEntry = new JournalEntry(DateTime.Now, prompt, content);
                    journalEntries.Add(journalEntry);
                    Console.Clear();
                    break;
                case "2":
                    Console.WriteLine("Existing journal entries:");
                    foreach (var entry in journalEntries)
                    {
                        Console.WriteLine(entry);
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    Console.WriteLine("Enter the filename to save your journal entries:");
                    string saveFileName = Console.ReadLine();
                    
                    // Get the current directory of the application
                    string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string fullPath = Path.Combine(currentDirectory, saveFileName);
                    bool success = JournalEntry.SaveEntriesToFile(journalEntries, fullPath);
                    if (success)
                    {
                        Console.WriteLine("Journal entries saved successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to save journal entries.");
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "4":
                    Console.WriteLine("Enter the filename to load your journal entries:");
                    string loadFileName = Console.ReadLine();
                    journalEntries = JournalEntry.LoadEntriesFromFile(loadFileName);
                    Console.WriteLine("Journal entries loaded successfully.");
                    break;
                case "5":
                    Console.WriteLine("Exiting the Journal App. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}