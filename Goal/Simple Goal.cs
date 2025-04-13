public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return _points;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStatus() => $"[{(_isComplete ? "X" : " ")}] {_name}";

    public override string GetStringRepresentation()
        => $"SimpleGoal:{_name},{_description},{_points},{_isComplete}";
}
