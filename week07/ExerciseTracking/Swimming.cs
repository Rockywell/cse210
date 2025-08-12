class Swimming : Activity
{
    private double _laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000 * 0.62;//miles
    public override double GetSpeed() => (GetDistance()/_minutes) * 60;//miles per hour 
    public override double GetPace() {
        return _minutes / GetDistance();
    }//minutes per mile

    // public override string GetSummary() => $"{03 Nov 2022} Running (30 min)- Distance 3.0 miles, Speed 6.0 mph, Pace: 10.0 min per mile";

}