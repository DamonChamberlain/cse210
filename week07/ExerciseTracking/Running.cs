class Running : Activity
{
    private double _distance; // Stored distance in km

    public Running(DateTime date, int minutes, double distance) : base(date, minutes, "Running")
    {
        _distance = distance;
    }

    // Override the abstract methods
    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        // Speed (kph) = (distance / Minutes) * 60
        return (_distance / Minutes) * 60;
    }

    public override double GetPace()
    {
        // Pace (min per km) = Minutes / distance
        return Minutes / _distance;
    }
}