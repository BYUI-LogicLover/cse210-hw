using System;

namespace ScriptureMemorizer;

public class Program
{
    public static void Main(string[] args)
    {
        var scripture = new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all your heart and lean not on your own understanding"
        );

        while (true)
        {
            scripture.Display();
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
            var input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords();

            if (scripture.AllWordsHidden())
            {
                scripture.Display();
                break;
            }
        }
    }
}