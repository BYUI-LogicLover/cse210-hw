using ExerciseTracking;

class Program
{
    static void Main(string[] args)
    {
        Activity running1 = new Running(new DateTime(2025, 06, 3), 30, 3.0);
        Activity running2 = new Running(new DateTime(2025, 06, 4), 45, 5.2);

        Activity biking1 = new Bicycle(new DateTime(2025, 06, 3), 40, 15.0);
        Activity biking2 = new Bicycle(new DateTime(2025, 06, 5), 60, 12.5);

        Activity swimming1 = new Swimming(new DateTime(2025, 06, 3), 25, 20);
        Activity swimming2 = new Swimming(new DateTime(2025, 06, 6), 35, 30);

        List<Activity> activities = new List<Activity>
        {
            running1,
            biking1,
            swimming1,
            running2,
            biking2,
            swimming2
        };

        Console.WriteLine("=== FITNESS CENTER ACTIVITY TRACKER ===\n");

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine("\n=== DETAILED BREAKDOWN FOR FIRST RUNNING ACTIVITY ===");
        Activity firstRun = running1;
        Console.WriteLine($"Activity: {firstRun.GetActivityName()}");
        Console.WriteLine($"Date: {firstRun.Date:dd MMM yyyy}");
        Console.WriteLine($"Duration: {firstRun.DurationMinutes} minutes");
        Console.WriteLine($"Distance: {firstRun.GetDistance():F2} miles");
        Console.WriteLine($"Speed: {firstRun.GetSpeed():F2} mph");
        Console.WriteLine($"Pace: {firstRun.GetPace():F2} min per mile");

        Console.WriteLine("\n=== DETAILED BREAKDOWN FOR FIRST BICYCLE ACTIVITY ===");
        Activity firstBike = biking1;
        Console.WriteLine($"Activity: {firstBike.GetActivityName()}");
        Console.WriteLine($"Date: {firstBike.Date:dd MMM yyyy}");
        Console.WriteLine($"Duration: {firstBike.DurationMinutes} minutes");
        Console.WriteLine($"Distance: {firstBike.GetDistance():F2} miles");
        Console.WriteLine($"Speed: {firstBike.GetSpeed():F2} mph");
        Console.WriteLine($"Pace: {firstBike.GetPace():F2} min per mile");

        Console.WriteLine("\n=== DETAILED BREAKDOWN FOR FIRST SWIMMING ACTIVITY ===");
        Activity firstSwim = swimming1;
        Console.WriteLine($"Activity: {firstSwim.GetActivityName()}");
        Console.WriteLine($"Date: {firstSwim.Date:dd MMM yyyy}");
        Console.WriteLine($"Duration: {firstSwim.DurationMinutes} minutes");
        Console.WriteLine($"Distance: {firstSwim.GetDistance():F2} miles");
        Console.WriteLine($"Speed: {firstSwim.GetSpeed():F2} mph");
        Console.WriteLine($"Pace: {firstSwim.GetPace():F2} min per mile");
    }
}