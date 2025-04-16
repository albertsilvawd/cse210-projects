public class EternalGoal : Goal
{
    public EternalGoal(string name, string description) : base(name, description)
    {
    }

    // Display the eternal goal
    public override void DisplayGoal()
    {
        string status = IsCompleted ? "Completed" : "Ongoing";
        Console.WriteLine($"Eternal Goal: {Name} - {Description} - Status: {status} - Points: {Points}");
    }

    // Points are added every time the user interacts with the goal
    public override void MarkAsComplete()
    {
        // Always gives points without marking as completed
        if (!IsCompleted)
        {
            Points += 5;  // Add points every time it's interacted with
        }
    }
}
