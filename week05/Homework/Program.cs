using System;

class Program
{
    static void Main(string[] args)
    {
        // Test the base Assignment class
        Assignment a1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(a1.GetSummary());
        Console.WriteLine(); // Add a blank line

        // Test the MathAssignment class
        MathAssignment a2 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());
        Console.WriteLine(); // Add a blank line

        // Test the WritingAssignment class
        WritingAssignment a3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}
