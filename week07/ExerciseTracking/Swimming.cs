using System;

public class Swimming : Activity
{
    private int _laps;  // Number of laps

    public Swimming(DateTime date, int durationInMinutes, int laps) 
        : base(date, durationInMinutes)
    {
        _laps = laps;
    }

    // Override to calculate the distance in kilometers
    public override double GetDistance()
    {
        return (_laps * 50) / 1000.0; // Distance in kilometers
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
