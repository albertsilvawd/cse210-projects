public class ChecklistGoal : Goal
{
    public int TotalSteps { get; set; }
    public int CurrentStep { get; set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string name, string description, int totalSteps, int bonusPoints) : base(name, description)
    {
        TotalSteps = totalSteps;
        CurrentStep = 0;
        BonusPoints = bonusPoints;
    }

    // Display the checklist goal with progress
    public override void DisplayGoal()
    {
        string status = IsCompleted ? "Completed" : "In Progress";
        Console.WriteLine($"Checklist Goal: {Name} - {Description} - Progress: {CurrentStep}/{TotalSteps} - Status: {status} - Points: {Points}");
    }

    // Record progress on the checklist goal
    public void RecordProgress()
    {
        if (CurrentStep < TotalSteps)
        {
            CurrentStep++;
            Points += 5; // Add points for each step
            if (CurrentStep == TotalSteps)
            {
                Points += BonusPoints; // Add bonus points when the goal is completed
                IsCompleted = true;
            }
        }
    }

    public override void MarkAsComplete()
    {
        // Mark as complete only if all steps are done
        if (CurrentStep == TotalSteps)
        {
            IsCompleted = true;
        }
    }
}
