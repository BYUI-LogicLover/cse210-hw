namespace EternalQuest;
public abstract class Goal
{
    protected string shortName;
    protected string description;
    protected int points;

    public Goal(string name, string description, int points)
    {
        this.shortName = name;
        this.description = description;
        this.points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();

    public string ShortName => shortName;
    public string Description => description;
    public int Points => points;
}