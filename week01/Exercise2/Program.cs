using System;

class Program
{
    static void Main(string[] args)
    {
        // CORE REQUIREMENT 1: Ask the user for their grade percentage
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        
        // Convert the input string to an integer for comparison
        int percent = int.Parse(answer);

        // CORE REQUIREMENT 3: Create a single variable for the letter grade
        string letter = "";

        // CORE REQUIREMENT 1 (Cont.): Determine the letter grade
        // Using if, else if, else to set the letter variable
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // CORE REQUIREMENT 3 (Cont.): Single print statement for the final letter grade
        Console.WriteLine($"Your letter grade is: {letter}");

        // CORE REQUIREMENT 2: Determine if the user passed the course (70 or higher)
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't give up! Better luck next time.");
        }
    }
}