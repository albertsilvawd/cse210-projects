public class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        string filePath = "goals.txt";

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Create goal");
            Console.WriteLine("2 - Display goals");
            Console.WriteLine("3 - Mark goal as complete");
            Console.WriteLine("4 - Save goals");
            Console.WriteLine("5 - Load goals");
            Console.WriteLine("6 - Exit");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    goalManager.CreateGoal();
                    break;
                case 2:
                    goalManager.DisplayGoals();
                    break;
                case 3:
                    goalManager.MarkGoalAsComplete();
                    break;
                case 4:
                    goalManager.SaveGoals(filePath);
                    break;
                case 5:
                    goalManager.LoadGoals(filePath);
                    break;
                case 6:
                    return;
            }
        }
    }
}
