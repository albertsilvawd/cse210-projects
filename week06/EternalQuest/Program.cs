using System;
using System.Collections.Generic;
using System.IO;
using EternalQuest;  // Ensure the namespace is included for your goal classes

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalPoints = 0;
    static int userLevel = 1; // User's level, starts at level 1
    static List<string> achievements = new List<string>(); // List to store achievements

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Eternal Quest Program!");

        // Add example goals, passing totalPoints to each goal by reference
        goals.Add(new SimpleGoal("Run a marathon", 1000, ref totalPoints));
        goals.Add(new EternalGoal("Read scriptures daily", 100, ref totalPoints));
        goals.Add(new ChecklistGoal("Attend the temple", 50, 10, 500, ref totalPoints));

        // Display current goals
        DisplayGoals();

        // Example of recording events
        goals[0].RecordEvent(); // Completing a simple goal
        goals[1].RecordEvent(); // Completing an eternal goal
        goals[2].RecordEvent(); // Completing a checklist goal

        // Display goals after events are recorded
        DisplayGoals();

        // Level up check after recording the events
        LevelUpCheck();

        // Check for achievements after events are recorded
        CheckForAchievements();

        // Save goals and user progress (points, level)
        SaveGoals();

        // Load goals and user progress (points, level)
        LoadGoals();
    }

    static void DisplayGoals()
    {
        foreach (var goal in goals)
        {
            goal.DisplayGoal();
        }

        // Display current user level and total points
        Console.WriteLine($"Your current level: {userLevel}");
        Console.WriteLine($"Total points: {totalPoints}");
    }

    static void LevelUpCheck()
    {
        // Simple leveling system: level up every 1000 points
        int newLevel = totalPoints / 1000 + 1; // Calculate level based on points

        if (newLevel > userLevel)
        {
            userLevel = newLevel; // Update user level
            Console.WriteLine($"Congratulations! You've leveled up to Level {userLevel}!");
        }
    }

    // Achievement System: This feature exceeds the core requirements by adding a gamified achievement system. 
    // Users can unlock achievements when they reach certain milestones, such as earning 5000 points or setting 5 goals.
    // This adds an additional layer of engagement and motivation, encouraging users to continue progressing towards their goals.
    
    static void CheckForAchievements()
    {
        // Achievement when reaching 5000 points
        if (totalPoints >= 5000 && !achievements.Contains("Master Quest"))
        {
            achievements.Add("Master Quest");
            Console.WriteLine("Achievement unlocked: Master Quest! You've earned 5000 points.");
        }

        // Achievement when setting 5 goals
        if (goals.Count >= 5 && !achievements.Contains("Goal Setter"))
        {
            achievements.Add("Goal Setter");
            Console.WriteLine("Achievement unlocked: Goal Setter! You've set 5 goals.");
        }

        // Display all achievements
        Console.WriteLine("Your achievements:");
        foreach (var achievement in achievements)
        {
            Console.WriteLine($"- {achievement}");
        }
    }

    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.GetName()},{goal.GetPoints()}");
            }

            // Save user progress: points and level
            writer.WriteLine($"TotalPoints:{totalPoints}");
            writer.WriteLine($"UserLevel:{userLevel}");

            // Save achievements
            writer.WriteLine($"Achievements:{string.Join(",", achievements)}");
        }
        Console.WriteLine("Goals and progress saved.");
    }

    static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            string[] lines = File.ReadAllLines("goals.txt");

            // Load goals from the file
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 2)  // Ensure the line has 2 parts (goal name and points)
                {
                    Console.WriteLine($"Loaded goal: {parts[0]} with {parts[1]} points.");
                }
            }

            // Check if there are enough lines for user progress data
            if (lines.Length >= 3)
            {
                // Load user progress: points and level
                string[] progress = lines[lines.Length - 2].Split(':');
                if (progress.Length == 2 && int.TryParse(progress[1], out int loadedPoints)) 
                {
                    totalPoints = loadedPoints;
                }
                else
                {
                    Console.WriteLine("Error: Invalid format for total points.");
                }

                progress = lines[lines.Length - 1].Split(':');
                if (progress.Length == 2 && int.TryParse(progress[1], out int loadedLevel))
                {
                    userLevel = loadedLevel;
                }
                else
                {
                    Console.WriteLine("Error: Invalid format for user level.");
                    userLevel = 1; // Fallback if the format is invalid
                }

                Console.WriteLine($"Loaded user progress: {totalPoints} points, Level {userLevel}");
            }

            // Load achievements
            var achievementsLine = lines[lines.Length - 1].Split(':');
            if (achievementsLine.Length > 1)
            {
                achievements = new List<string>(achievementsLine[1].Split(','));
            }

            Console.WriteLine($"Loaded achievements: {string.Join(", ", achievements)}");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}
