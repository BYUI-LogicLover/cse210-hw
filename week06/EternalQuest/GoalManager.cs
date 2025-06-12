namespace EternalQuest;

public class GoalManager
{
    private List<Goal> goals;
    private int score;
    private int level;

    public GoalManager()
    {
        goals = new List<Goal>();
        score = 0;
        level = 1;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine("\n" + new string('=', 40));
        Console.WriteLine($"Player Info - Level {level} | Score: {score} points");
        Console.WriteLine($"XP to next level: {GetXPForLevel(level + 1) - score}");
        Console.WriteLine(new string('=', 40));
    }

    public void ListGoalNames()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            string checkbox = goal.IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {checkbox} {goal.ShortName}");
        }
    }

    public void ListGoalDetails()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        Console.WriteLine("\nGoal Details:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal (Bad Habit)");
        Console.Write("Which type of goal would you like to create? ");

        if (!int.TryParse(Console.ReadLine(), out int type))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points value.");
            return;
        }

        switch (type)
        {
            case 1:
                goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                if (!int.TryParse(Console.ReadLine(), out int target))
                {
                    Console.WriteLine("Invalid target value.");
                    return;
                }

                Console.Write("What is the bonus for accomplishing it that many times? ");
                if (!int.TryParse(Console.ReadLine(), out int bonus))
                {
                    Console.WriteLine("Invalid bonus value.");
                    return;
                }

                goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case 4:
                goals.Add(new NegativeGoal(name, description, points));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available to record.");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");

        if (!int.TryParse(Console.ReadLine(), out int goalNumber) ||
            goalNumber < 1 || goalNumber > goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        int goalIndex = goalNumber - 1;
        Goal goal = goals[goalIndex];

        if (goal is SimpleGoal && goal.IsComplete())
        {
            Console.WriteLine("This goal is already completed!");
            return;
        }

        int pointsEarned = goal.Points;
        bool wasCompleted = goal.IsComplete();

        goal.RecordEvent();
        
        if (goal is NegativeGoal)
        {
            score -= pointsEarned;
            Console.WriteLine($"Oh no! You lost {pointsEarned} points for this bad habit.");
        }
        else
        {
            score += pointsEarned;
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        }
        
        if (goal is ChecklistGoal checklistGoal)
        {
            if (!wasCompleted && checklistGoal.IsComplete())
            {
                score += checklistGoal.Bonus;
                Console.WriteLine(
                    $"BONUS! You completed your checklist goal and earned an additional {checklistGoal.Bonus} points!");
            }
        }

        CheckLevelUp();
        Console.WriteLine($"You now have {score} points.");
    }

    private void CheckLevelUp()
    {
        int newLevel = CalculateLevel(score);
        if (newLevel > level)
        {
            Console.WriteLine($"🎉 LEVEL UP! You are now level {newLevel}! 🎉");
            level = newLevel;
        }
    }

    private int CalculateLevel(int score)
    {
        return (int)Math.Sqrt(score / 100.0) + 1;
    }

    private int GetXPForLevel(int level)
    {
        return (level - 1) * (level - 1) * 100;
    }

    public void SaveGoals()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                writer.WriteLine(score);
                writer.WriteLine(level);
                foreach (Goal goal in goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving goals: {e.Message}");
        }
    }

    public void LoadGoals()
    {
        try
        {
            if (!File.Exists("goals.txt"))
            {
                Console.WriteLine("No saved goals found.");
                return;
            }

            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                goals.Clear();

                score = int.Parse(reader.ReadLine());
                level = int.Parse(reader.ReadLine());

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string[] typeParts = parts[0].Split(':');
                    string type = typeParts[0];
                    string name = typeParts[1];
                    string description = parts[1];
                    int points = int.Parse(parts[2]);

                    switch (type)
                    {
                        case "SimpleGoal":
                            SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                            simpleGoal.Complete = bool.Parse(parts[3]);
                            goals.Add(simpleGoal);
                            break;
                        case "EternalGoal":
                            goals.Add(new EternalGoal(name, description, points));
                            break;
                        case "ChecklistGoal":
                            int target = int.Parse(parts[3]);
                            int bonus = int.Parse(parts[4]);
                            int completed = int.Parse(parts[5]);
                            ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                            checklistGoal.AmountCompleted = completed;
                            goals.Add(checklistGoal);
                            break;
                        case "NegativeGoal":
                            goals.Add(new NegativeGoal(name, description, points));
                            break;
                    }
                }
            }

            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading goals: {e.Message}");
        }
    }

    public void ShowStatistics()
    {
        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("ETERNAL QUEST STATISTICS");
        Console.WriteLine(new string('=', 50));

        int totalGoals = goals.Count;
        int completedGoals = 0;
        int simpleGoals = 0, eternalGoals = 0, checklistGoals = 0, negativeGoals = 0;

        foreach (Goal goal in goals)
        {
            if (goal.IsComplete()) completedGoals++;
            if (goal is SimpleGoal) simpleGoals++;
            else if (goal is EternalGoal) eternalGoals++;
            else if (goal is ChecklistGoal) checklistGoals++;
            else if (goal is NegativeGoal) negativeGoals++;
        }

        Console.WriteLine($"Player Level: {level}");
        Console.WriteLine($"Total Score: {score} points");
        Console.WriteLine($"Total Goals: {totalGoals}");
        Console.WriteLine($"Completed Goals: {completedGoals}/{totalGoals}");
        Console.WriteLine($"Simple Goals: {simpleGoals}");
        Console.WriteLine($"Eternal Goals: {eternalGoals}");
        Console.WriteLine($"Checklist Goals: {checklistGoals}");
        Console.WriteLine($"Negative Goals (Bad Habits): {negativeGoals}");

        if (totalGoals > 0)
        {
            double completionRate = (double)completedGoals / totalGoals * 100;
            Console.WriteLine($"Completion Rate: {completionRate:F1}%");
        }

        Console.WriteLine("\nDetailed Goal List:");
        ListGoalDetails();

        Console.WriteLine(new string('=', 50));
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Eternal Quest!");
        DisplayPlayerInfo();
    }
}