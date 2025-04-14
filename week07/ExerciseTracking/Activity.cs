using System;

public abstract class Activity
{
    // Private fields
    private DateTime _date;
    private int _durationInMinutes;

    // Constructor
    public Activity(DateTime date, int durationInMinutes)
    {
        _date = date;
        _durationInMinutes = durationInMinutes;
    }

    // Properties
    public DateTime Date => _date;
    public int DurationInMinutes => _durationInMinutes;

    // Abstract methods to be overridden by derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Common method to get the summary of the activity
    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_durationInMinutes} min) - Distance {GetDistance():0.0} km, Speed {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}