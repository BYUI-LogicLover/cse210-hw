using System;
using System.Collections.Generic;
using Journal.Data;
using Microsoft.Data.Sqlite;

namespace Journal;

class Program
{
    static void Main(string[] args)
    {
        JournalPromptGenerator promptGenerator = new JournalPromptGenerator();
        List<JournalEntry> journalEntries = new List<JournalEntry>();
        
        Console.WriteLine("Welcome to the Journal App!");
        JournalRepository.InitializeDatabase();

        while (true)
        {
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Enter a new journal entry");
            Console.WriteLine("2. View existing journal entries");
            Console.WriteLine("3. Save journal entries to a file");
            Console.WriteLine("4. Load journal entries from a file");
            Console.WriteLine("5. Delete a journal entry");
            Console.WriteLine("9. Exit");

            Console.Write("-> ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.WriteLine("Please write your response:");

                    string content = Console.ReadLine();
                    JournalEntry journalEntry = new JournalEntry(DateTime.Now, prompt, content);
                    JournalRepository.InsertEntry(journalEntry);
                    Console.Clear();
                    break;
                case "2":
                    Console.WriteLine("Existing journal entries:");
                    journalEntries = JournalRepository.GetAllEntries();
                    foreach (var entry in journalEntries)
                    {
                        Console.WriteLine($"Date: {entry.GetDateTime()}, Prompt: {entry.GetPrompt()}, Content: {entry.GetContent()}");
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    Console.WriteLine("Enter the filename to save your journal entries:");
                    string saveFileName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(saveFileName))
                    {
                        Console.WriteLine("Filename cannot be empty. Please try again.");
                        continue;
                    }

                    // Get the current directory of the application
                    string currentDirectory = Environment.CurrentDirectory;
                    string fullPath = Path.Combine(currentDirectory, saveFileName);
                    bool success = JournalEntry.SaveEntriesToFile(journalEntries, fullPath);
                    if (success)
                    {
                        Console.WriteLine("Journal entries saved successfully.");
                        Console.WriteLine($"Saved to {fullPath}");   
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
                    journalEntries = JournalEntry.LoadEntriesFromFile(loadFileName, journalEntries);
                    Console.WriteLine("Journal entries loaded successfully.");
                    break;
                case "5":
                    foreach (var entry in journalEntries)
                    {
                        Console.WriteLine($"Entry Number: {journalEntries.IndexOf(entry)}, Date: {entry.GetDateTime()}, Prompt: {entry.GetPrompt()}, Content: {entry.GetContent()}");
                    }
                    Console.WriteLine("Enter the journal entry number to delete:");
                    Console.Write("-> ");
                    string deleteEntryNumber = Console.ReadLine();
                    JournalRepository.DeleteEntry(int.Parse(deleteEntryNumber));
                    Console.WriteLine("Journal entry deleted successfully.");
                    Console.WriteLine("Press any key to continue...");
                    Console.Clear();
                    break;
                case "9":
                    Console.WriteLine("Exiting the Journal App. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}