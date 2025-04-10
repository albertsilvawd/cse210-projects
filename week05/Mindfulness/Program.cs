using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");
        
        // Display the menu
        Console.WriteLine("Choose an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("Enter your choice (1-3):");
        
        int choice = Convert.ToInt32(Console.ReadLine());
        Activity activity = null;

        switch (choice)
        {
            case 1:
                activity = new BreathingActivity();
                break;
            case 2:
                activity = new ReflectionActivity();
                break;
            case 3:
                activity = new ListingActivity();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        activity.Run(); // Run the chosen activity
    }
}
