namespace EternalQuest;

public class SimpleGoal : Goal
{
    private bool complete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        this.complete = false;
    }

    public override void RecordEvent()
    {
        if (!complete)
        {
            complete = true;
        }
    }

    public override bool IsComplete()
    {
        return complete;
    }

    public override string GetDetailsString()
    {
        return $"{shortName} ({description}) - {points} points" +
               (complete ? " [COMPLETED]" : " [INCOMPLETE]");
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{shortName},{description},{points},{complete}";
    }

    public bool Complete
    {
        get => complete;
        set => complete = value;
    }
}