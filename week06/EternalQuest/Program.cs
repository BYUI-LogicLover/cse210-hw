using EternalQuest;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
        
        Console.WriteLine("Welcome to Eternal Quest!");
        Console.WriteLine("Track your goals and earn points to level up!");

        while (true)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. View Statistics");
            Console.WriteLine("7. Quit");
            Console.Write("Please select an option (1-7): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        goalManager.CreateGoal();
                        break;
                    case 2:
                        goalManager.ListGoalNames();
                        break;
                    case 3:
                        goalManager.SaveGoals();
                        break;
                    case 4:
                        goalManager.LoadGoals();
                        break;
                    case 5:
                        goalManager.RecordEvent();
                        break;
                    case 6:
                        goalManager.ShowStatistics();
                        break;
                    case 7:
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}