public abstract class Goal
{
    protected string _name;
    protected int _points;

    public Goal(string name, int points)
    {
        _name = name;
        _points = points;
    }

    public abstract void RecordEvent(); // Method to record an event
    public abstract void DisplayGoal(); // Method to display the goal

    public int GetPoints()
    {
        return _points;
    }

    public string GetName()
    {
        return _name;
    }
}
