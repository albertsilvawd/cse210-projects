using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Creating instances of activities
        var running = new Running(new DateTime(2022, 11, 3), 30, 5.0);  // 30 min run with 5 km distance
        var cycling = new Cycling(new DateTime(2022, 11, 3), 45, 25.0);  // 45 min cycling with 25 kph speed
        var swimming = new Swimming(new DateTime(2022, 11, 3), 60, 30);  // 60 min swimming with 30 laps

        // Creating a list to hold activities
        List<Activity> activities = new List<Activity>
        {
            running,
            cycling,
            swimming
        };

        // Loop through each activity and display the summary
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
