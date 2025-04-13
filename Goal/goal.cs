public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points) { ... }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStatus();
    public abstract string SaveFormat(); // For saving to file
}
