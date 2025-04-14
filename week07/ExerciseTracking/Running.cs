using System;

public class Running : Activity
{
    private double _distance;  // Distance in kilometers

    public Running(DateTime date, int durationInMinutes, double distance) 
        : base(date, durationInMinutes)
    {
        _distance = distance;
    }

    // Override the method to calculate the distance (already passed in the constructor)
    public override double GetDistance()
    {
        return _distance;
    }

    // Override to calculate the speed in kilometers per hour
    public override double GetSpeed()
    {
        return (GetDistance() / DurationInMinutes) * 60; // Speed = Distance / Time * 60
    }

    // Override to calculate the pace in minutes per kilometer
    public override double GetPace()
    {
        return DurationInMinutes / GetDistance(); // Pace = Time / Distance
    }
}
