class SimpleGoal : Goal 
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool? isComplete = null) : base(name, description, points)
    {
        _isComplete = isComplete ?? false;
    }

    public override int RecordEvent()
    {
        _isComplete = true;

        return _points;
    }
    public override bool IsComplete() => _isComplete;
    
    public override string GetStringRepresentation() => $"{base.GetStringRepresentation()},{_isComplete}";
}