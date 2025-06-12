namespace EternalQuest;

public class ChecklistGoal : Goal
{
    private int amountCompleted;
    private int target;
    private int bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        this.amountCompleted = 0;
        this.target = target;
        this.bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (amountCompleted < target)
        {
            amountCompleted++;
        }
    }

    public override bool IsComplete()
    {
        return amountCompleted >= target;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[COMPLETED]" : $"[{amountCompleted}/{target}]";
        return $"{shortName} ({description}) - {points} points each, " +
               $"{bonus} bonus - Completed {amountCompleted}/{target} times {status}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{shortName},{description},{points}," +
               $"{target},{bonus},{amountCompleted}";
    }

    public int AmountCompleted
    {
        get => amountCompleted;
        set => amountCompleted = value;
    }

    public int Target => target;
    public int Bonus => bonus;
}