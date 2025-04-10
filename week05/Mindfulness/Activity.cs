// Activity.cs
public abstract class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _duration;

    public void SetActivityDetails(string activityName, string description, int duration)
    {
        _activityName = activityName;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_activityName}: {_description}");
        Console.WriteLine("Set the duration in seconds:");
        _duration = Convert.ToInt32(Console.ReadLine());
        Thread.Sleep(3000);  // Pause for a few seconds to prepare the user
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Good job! You've completed the activity.");
        Thread.Sleep(3000);  // Pause before finishing
    }

    public abstract void Run();
}
