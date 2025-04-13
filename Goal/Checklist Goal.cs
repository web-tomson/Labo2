public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        return (_currentCount >= _targetCount) ? _points + _bonus : _points;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus()
        => $"[{(_currentCount >= _targetCount ? "X" : " ")}] {_name} -- Completed {_currentCount}/{_targetCount} times";

    public override string GetStringRepresentation()
        => $"ChecklistGoal:{_name},{_description},{_points},{_bonus},{_targetCount},{_currentCount}";
}
