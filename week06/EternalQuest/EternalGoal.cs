namespace EternalQuest;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Nothing special needed - points awarded by GoalManager
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never complete
    }

    public override string GetDetailsString()
    {
        return $"{shortName} ({description}) - {points} points each time [ETERNAL]";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{shortName},{description},{points}";
    }
}