using System;

public class Cycling : Activity
{
    private double _speed;  // Speed in kilometers per hour

    public Cycling(DateTime date, int durationInMinutes, double speed) 
        : base(date, durationInMinutes)
    {
        _speed = speed;
    }

    // Override the method to calculate the distance
    public override double GetDistance()
    {
        return (_speed * DurationInMinutes) / 60; // Distance = Speed * Time / 60
    }

    // Override to return the speed directly
    public override double GetSpeed()
    {
        return _speed;
    }

    // Override to calculate the pace in minutes per kilometer
    public override double GetPace()
    {
        return 60 / _speed; // Pace = 60 / Speed
    }
}
