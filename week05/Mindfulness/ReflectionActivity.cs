public class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult."
    };

    public override void Run()
    {
        DisplayStartingMessage(); // Using the base method

        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(randomPrompt);

        string[] questions = {
            "Why was this experience meaningful to you?",
            "How did you feel when it was complete?"
        };

        foreach (var question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(2000); // Simulate pause for reflection
        }

        DisplayEndingMessage();
    }
}
