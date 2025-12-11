class Cycling : Activity
{
    private double _speed; // Stored speed in kph

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes, "Cycling")
    {
        _speed = speed;
    }

    // Override the abstract methods
    public override double GetDistance()
    {
        // Distance (km) = (speed / 60) * Minutes
        return (_speed / 60) * Minutes;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        // Pace (min per km) = 60 / speed
        return 60 / _speed;
    }
}