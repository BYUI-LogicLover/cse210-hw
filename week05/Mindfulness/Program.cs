using System;

namespace Mindfulness
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Mindfulness App!");
                Console.WriteLine("1. Start a breathing session");
                Console.WriteLine("2. Start a reflecting session");
                Console.WriteLine("3. Start a listing session");
                Console.WriteLine("4. Start a grounding session");
                Console.WriteLine("5. Exit the app");
                
                Console.Write("Please select an option (1-5): ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Breathing breathing = new Breathing();
                        breathing.Start();
                        break;
                    case "2":
                        Console.Clear();
                        Reflecting reflecting = new Reflecting();
                        reflecting.Start();
                        break;
                    case "3":
                        Console.Clear();
                        Listing listing = new Listing();
                        listing.Start();
                        break;
                    case "4":
                        Console.Clear();
                        Grounding grounding = new Grounding();
                        grounding.Start();
                        break;
                    case "5":
                        Console.WriteLine("Thank you for using the Mindfulness App. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}