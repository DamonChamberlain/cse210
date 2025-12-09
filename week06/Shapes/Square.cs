public class Square : Shape
{
    private double _side;

    // Constructor passes the color to the base class, and sets the side
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Override the GetArea method
    // Formula: Area = side * side
    public override double GetArea()
    {
        return _side * _side;
    }
}