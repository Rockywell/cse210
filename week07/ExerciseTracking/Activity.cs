//Activity Tracker.
abstract class Activity
{
    //The Date.
    private DateTime _date;
    //The Duration.
    protected int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public abstract double GetDistance();//miles
    public abstract double GetSpeed();//miles per hour 
    public abstract double GetPace();//minutes per mile

    public virtual string GetSummary() => $"{_date.ToString("dd MMM yyyy")} {this.GetType().Name} ({_minutes} min) - Distance {GetDistance():F2} miles, Speed {GetSpeed():F2}, Pace: {GetPace():F1} min per mile";
}