namespace Mindfulness;

public class Grounding : Activity
{
    public Grounding() 
        : base("Grounding",
            "This activity will help you in the present moment by focusing on the 5-4-3-2-1 grounding technique.")
    {
    }
    
    protected override void DoActivity()
    {
        Console.WriteLine("Take a deep breath in... and out.");
        ShowAnnimation(5);

        Console.WriteLine("\nNow, let's focus on your senses.");
        Console.WriteLine("I will ask you to identify things you can see, touch, hear, smell, and taste.");
        
        Console.WriteLine("\nNotice 5 things you can see");
        Console.ReadLine();
        Console.ReadLine();
        Console.ReadLine();
        Console.ReadLine();
        Console.ReadLine();
        
        Console.WriteLine("\nNotice 4 things you can touch");
        Console.ReadLine();
        Console.ReadLine();
        Console.ReadLine();
        Console.ReadLine();
        
        Console.WriteLine("\nNotice 3 things you can hear");
        Console.ReadLine();
        Console.ReadLine();
        Console.ReadLine();
        
        Console.WriteLine("\nNotice 2 things you can smell");
        Console.ReadLine();
        Console.ReadLine();
        
        Console.WriteLine("\nNotice 1 things you can taste");
        Console.ReadLine();

    }
}