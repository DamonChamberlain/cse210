using System; // Needed for Math.PI

public class Circle : Shape
{
    private double _radius;

    // Constructor
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override the GetArea method
    // Formula: Area = PI * r^2
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}