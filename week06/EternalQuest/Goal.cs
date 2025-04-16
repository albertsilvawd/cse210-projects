public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; set; }

    public Goal(string name, string description)
    {
        Name = name;
        Description = description;
        Points = 0;
        IsCompleted = false;
    }

    // Abstract method to display the goal
    public abstract void DisplayGoal();
    
    // Abstract method to mark the goal as complete
    public abstract void MarkAsComplete();
}
