using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. Build a List of Shapes
        List<Shape> shapes = new List<Shape>();

        // 2. Add different instances to the list
        // Notice we are adding specific shapes to a generic List<Shape>
        shapes.Add(new Square("Red", 3));
        shapes.Add(new Rectangle("Blue", 4, 5));
        shapes.Add(new Circle("Green", 6));

        // 3. Iterate through the list
        foreach (Shape s in shapes)
        {
            // POLYMORPHISM IN ACTION:
            // The GetColor() method is defined in the base class.
            // The GetArea() method is overridden in each child class.
            // The program knows which GetArea() to call based on the object type.
            
            string color = s.GetColor();
            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}
