using System;

public class Fraction
{
    // --- Attributes ---
    // Per encapsulation principles, attributes are private.
    private int _top;
    private int _bottom;

    // --- Constructors ---

    // Constructor 1: No parameters (defaults to 1/1)
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor 2: One parameter for a whole number (e.g., 5 -> 5/1)
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // Constructor 3: Two parameters (e.g., 3/4)
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // --- Getters and Setters ---

    // Getter for the top number
    public int GetTop()
    {
        return _top;
    }

    // Setter for the top number
    public void SetTop(int top)
    {
        _top = top;
    }

    // Getter for the bottom number
    public int GetBottom()
    {
        return _bottom;
    }

    // Setter for the bottom number
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // --- Methods ---

    // Returns the fraction as a string (e.g., "3/4")
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Returns the decimal value of the fraction
    public double GetDecimalValue()
    {
        // Cast to double to ensure floating-point division
        return (double)_top / (double)_bottom;
    }
}