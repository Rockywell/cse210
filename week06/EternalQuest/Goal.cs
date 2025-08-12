abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetName() => _shortName;

    public abstract int RecordEvent();
    public abstract bool IsComplete();

    public virtual string GetDetailsString() => $"{(IsComplete() ? "\u2714" : "\u2610")} - {_shortName}: {_description}";
    // This method should return the details of a goal that could be shown in a list. It should include the checkbox, the short name, and description

    public virtual string GetStringRepresentation() => $"{this.GetType().Name}:{_shortName},{_description},{_points}";
    // This method should provide all of the details of a goal in a way that is easy to save to a file, and then load later.
}