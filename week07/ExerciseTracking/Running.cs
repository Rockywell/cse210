class Running : Activity
{
    //In Miles
    private double _distance;


    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;//miles
    public override double GetSpeed() => (_distance / _minutes) * 60;//miles per hour 
    public override double GetPace() =>  _minutes / _distance;//minutes per mile

    // public override string GetSummary() => $"{03 Nov 2022} Running (30 min)- Distance 3.0 miles, Speed 6.0 mph, Pace: 10.0 min per mile";
}