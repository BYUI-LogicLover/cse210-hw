namespace ExerciseTracking;

public class Bicycle : Activity
{
    private double _speed;

    public Bicycle(DateTime date, int durationMinutes, double speed) 
        : base(date, durationMinutes)
    {
        _speed = speed;
    }

    public override string GetActivityName()
    {
        return "Bicycling";
    }

    public override double GetDistance()
    {
        return (_speed * DurationMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}