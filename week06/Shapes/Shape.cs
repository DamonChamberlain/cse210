public class Shape
{
    // Member variable for color
    private string _color;

    // Constructor
    public Shape(string color)
    {
        _color = color;
    }

    // Getter for color
    public string GetColor()
    {
        return _color;
    }

    // Setter for color
    public void SetColor(string color)
    {
        _color = color;
    }

    // Virtual method for GetArea. 
    // It returns 0 here because a generic "Shape" has no specific dimensions.
    public virtual double GetArea()
    {
        return 0.0;
    }
}