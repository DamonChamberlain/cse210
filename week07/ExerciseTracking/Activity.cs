abstract class Activity
{
    private DateTime _date;
    private int _minutes;
    private string _activityType; // For the summary output

    // FIX: Public read-only property to allow derived classes (and others) to access the minutes value.
    public int Minutes
    {
        get { return _minutes; }
    }

    public Activity(DateTime date, int minutes, string activityType)
    {
        _date = date;
        _minutes = minutes;
        _activityType = activityType;
    }

    // Abstract methods must be implemented by derived classes (polymorphism)
    public abstract double GetDistance(); // km
    public abstract double GetSpeed();    // kph
    public abstract double GetPace();     // minutes per km

    // This method is defined in the base class and uses the abstract methods.
    public virtual string GetSummary()
    {
        // Format the date as "03 Nov 2022" (adjusting format based on C# conventions)
        string formattedDate = _date.ToString("dd MMM yyyy");

        // Calculations using the overridden methods (polymorphism in action)
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        // Example summary: 03 Nov 2022 Running (30 min): Distance 4.8 km, Speed: 9.7 kph, Pace: 6.25 min per km
        return $"{formattedDate} {_activityType} ({_minutes} min): Distance {distance:F2} km, Speed: {speed:F2} kph, Pace: {pace:F2} min per km";
    }
}