namespace ExerciseTracking;

public abstract class Activity
{
    private DateTime _datedate;
    private int _durationMinutes;

    protected Activity(DateTime date, int durationMinutes)
    {
        _datedate = date;
        _durationMinutes = durationMinutes;
    }

    public DateTime Date
    {
        get
        {
            return _datedate;
        }
        protected set
        {
            _datedate = value;
        }
    }

    public int DurationMinutes
    {
        get
        {
            return _durationMinutes;
        }
        protected set
        {
            _durationMinutes = value;
        }
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public abstract string GetActivityName();

    public virtual string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {GetActivityName()} ({DurationMinutes} min): " +
               $"Distance {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F1} min per mile";
    }
}