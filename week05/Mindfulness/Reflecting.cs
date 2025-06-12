namespace Mindfulness;

public class Reflecting : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random random = new Random();

    public Reflecting()
        : base("Reflection",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void DoActivity()
    {
        Console.WriteLine($"\nConsider the following prompt:\n");
        Console.WriteLine($" --- {prompts[random.Next(prompts.Count)]} ---");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience.");
        Console.Clear();

        int elapsedTime = 0;
        while (elapsedTime < Duration)
        {
            Console.WriteLine($"\n> {questions[random.Next(questions.Count)]}");
            int pauseTime = Math.Min(15, Duration - elapsedTime);
            ShowSpinner(pauseTime);
            elapsedTime += pauseTime;
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}