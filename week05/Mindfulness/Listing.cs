namespace Mindfulness;

public class Listing : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
        
    private Random _random = new Random();
        
    public Listing() 
        : base("Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }
        
    protected override void DoActivity()
    {
        Console.WriteLine($"\nList as many responses you can to the following prompt:");
        Console.WriteLine($" --- {prompts[_random.Next(prompts.Count)]} ---");
            
        Console.WriteLine("\nStart listing items (press Enter after each item):");
            
        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(Duration);
            
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }
            
        Console.WriteLine($"\nYou listed {items.Count} items!");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}