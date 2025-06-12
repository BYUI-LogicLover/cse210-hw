namespace ExerciseTracking;

public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int durationMinutes, double distance) 
        : base(date, durationMinutes)
    {
        _distance = distance;
    }

    public override string GetActivityName()
    {
        return "Running";
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / DurationMinutes) * 60;
    }

    public override double GetPace()
    {
        return DurationMinutes / _distance;
    }
}