public class GoalManager
{
    private List<Goal> goals = new List<Goal>();

    // Create a new goal
    public void CreateGoal()
    {
        Console.WriteLine("Enter the goal name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the goal description:");
        string description = Console.ReadLine();

        Console.WriteLine("Choose the goal type (1 - Simple, 2 - Eternal, 3 - Checklist):");
        int choice = int.Parse(Console.ReadLine());

        Goal newGoal = null;
        switch (choice)
        {
            case 1:
                newGoal = new SimpleGoal(name, description);
                break;
            case 2:
                newGoal = new EternalGoal(name, description);
                break;
            case 3:
                Console.WriteLine("Enter the total number of steps for the checklist:");
                int totalSteps = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter bonus points for completing the checklist:");
                int bonusPoints = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, totalSteps, bonusPoints);
                break;
        }

        if (newGoal != null)
        {
            goals.Add(newGoal);
            Console.WriteLine("Goal created successfully!");
        }
    }

    // Display all goals
    public void DisplayGoals()
    {
        foreach (var goal in goals)
        {
            goal.DisplayGoal();
        }
    }

    // Mark a goal as completed
    public void MarkGoalAsComplete()
    {
        Console.WriteLine("Enter the index of the goal you want to mark as complete:");
        int index = int.Parse(Console.ReadLine());

        if (index >= 0 && index < goals.Count)
        {
            goals[index].MarkAsComplete();
            Console.WriteLine("Goal marked as complete.");
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }

    // Save goals to a file
    public void SaveGoals(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.Name},{goal.Description},{goal.Points},{goal.IsCompleted}");
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    // Load goals from a file
    public void LoadGoals(string filePath)
    {
        if (File.Exists(filePath))
        {
            goals.Clear();
            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split(',');
                var name = parts[0];
                var description = parts[1];
                var points = int.Parse(parts[2]);
                var isCompleted = bool.Parse(parts[3]);

                Goal loadedGoal = new SimpleGoal(name, description);  // Modify to load the correct type
                loadedGoal.Points = points;
                loadedGoal.IsCompleted = isCompleted;
                goals.Add(loadedGoal);
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
