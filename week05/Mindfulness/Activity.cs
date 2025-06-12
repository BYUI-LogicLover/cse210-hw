namespace Mindfulness;

public abstract class Activity
{
    private readonly string _name;
    private readonly string _description;
    protected int Duration;

    protected Activity(string name, string description)
    {
        this._name = name;
        this._description = description;
    }

    public void Start()
    {
        DisplayStartingMessage();
        DoActivity();
        DisplayEndingMessage();
    }
    
    private void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} activity!");
        Console.WriteLine(_description);
        if (_name != "Grounding")
        {
            Console.Write("How many seconds would you like this activity to last? ");
            Duration = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(2000); // Simulate a short pause before starting
    }
    
    private void DisplayEndingMessage()
    {
        Console.WriteLine($"Great job! You completed the {_name} activity.");
        if (_name != "Grounding")
        {
            Console.WriteLine($"You spent a total of {Duration} seconds on this activity.");
        }
        Console.WriteLine("Take a moment to reflect on how you feel now.");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    
    protected void ShowAnnimation(int duration)
    {
        for (int i = 0; i < duration; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
    
    protected void ShowSpinner(int duration)
    {
        string[] spinner = {"|", "/", "-", "\\"};
        int totalIterations = duration * 4;
            
        for (int i = 0; i < totalIterations; i++)
        {
            Console.Write($"\r{spinner[i % 4]} ");
            Thread.Sleep(250);
        }
        Console.Write("\r  ");
    }
    
    protected abstract void DoActivity();  
}