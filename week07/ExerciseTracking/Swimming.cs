class Swimming : Activity
{
    private int _laps;
    private const double LAP_LENGTH_KM = 0.05; // 50 meters = 0.05 km

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes, "Swimming")
    {
        _laps = laps;
    }

    // Override the abstract methods
    public override double GetDistance()
    {
        // Distance (km) = swimming laps * 0.05
        return _laps * LAP_LENGTH_KM;
    }

    public override double GetSpeed()
    {
        // Speed (kph) = (distance / Minutes) * 60
        double distance = GetDistance();
        return (distance / Minutes) * 60;
    }

    public override double GetPace()
    {
        // Pace (min per km) = Minutes / distance
        double distance = GetDistance();
        return Minutes / distance;
    }
}