namespace EternalQuest;

public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[!] {shortName} ({description}) - Penalty: -{points} points";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{shortName},{description},{points}";
    }
}