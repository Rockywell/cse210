class Cycling : Activity
{
    //MPH
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => _speed * ((double)_minutes / 60);//miles
    public override double GetSpeed() => _speed;//miles per hour 
    public override double GetPace() => 60 / _speed;//minutes per mile

    // public override string GetSummary() => $"{03 Nov 2022} Running (30 min)- Distance 3.0 miles, Speed 6.0 mph, Pace: 10.0 min per mile";
}