class ChecklistGoal : Goal {
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int? amountCompleted = null) : base(name, description, points)
    {
        _amountCompleted = amountCompleted ?? 0;

        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;

        int awardedPoints = _points;

        if(IsComplete()) awardedPoints += _bonus;

        return awardedPoints;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString() => $"{(IsComplete() ? "\u2714" : "\u2610")} ({_amountCompleted}/{_target}) - {_shortName}: {_description}";
    public override string GetStringRepresentation() =>  $"{base.GetStringRepresentation()},{_target},{_bonus},{_amountCompleted}";
}