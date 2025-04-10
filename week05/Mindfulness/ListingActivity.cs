public class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?"
    };

    public override void Run()
    {
        DisplayStartingMessage(); // Using the base method

        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(randomPrompt);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        List<string> userList = new List<string>();
        while (DateTime.Now < endTime)
        {
            string entry = Console.ReadLine();
            userList.Add(entry);
            Console.WriteLine("Keep going! Press Enter to add more.");
        }

        Console.WriteLine($"You listed {userList.Count} items.");
        DisplayEndingMessage();
    }
}
