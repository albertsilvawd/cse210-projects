public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description) : base(name, description)
    {
    }

    // Display the simple goal
    public override void DisplayGoal()
    {
        string status = IsCompleted ? "Completed" : "Incomplete";
        Console.WriteLine($"Simple Goal: {Name} - {Description} - Status: {status} - Points: {Points}");
    }

    // Mark the simple goal as complete and add points
    public override void MarkAsComplete()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Points += 10; // Add points when the goal is completed
        }
        else
        {
            Console.WriteLine("This goal is already completed.");
        }
    }
}
