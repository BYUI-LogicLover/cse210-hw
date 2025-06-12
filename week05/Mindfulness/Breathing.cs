namespace Mindfulness;

public class Breathing : Activity
{
    public Breathing() : base("Breathing",
        "This activity will help you relax by focusing on your breathing using the 4, 7, 8 method.")
    {
    }

    protected override void DoActivity()

    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\nIn.....");
            for (int i = 2; i <= 4; i++)
            {
                Console.Write($"{i}");
                if (i < 4) Console.Write(", ");
                Thread.Sleep(2000);
            }

            Console.Write("\nHold...");
            for (int i = 2; i <= 7; i++)
            {
                Console.Write($"{i}");
                if (i < 7) Console.Write(", ");
                Thread.Sleep(2000);
            }

            Console.Write("\nOut....");
            for (int i = 2; i <= 8; i++)
            {
                Console.Write($"{i}");
                if (i < 8) Console.Write(", ");
                Thread.Sleep(2000);
            }

            Console.WriteLine("");
        }

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}