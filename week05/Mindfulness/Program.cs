using System;
using System.Collections.Generic;

// EXCEEDING REQUIREMENTS:
// I added a log system that tracks how many times each activity 
// was performed during the current session and displays it in the menu.

class Program
{
    static void Main(string[] args)
    {
        // Keep track of activity counts
        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;

        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            
            // Display the log
            Console.WriteLine("\nActivity Log:");
            Console.WriteLine($"  Breathing: {breathingCount}");
            Console.WriteLine($"  Reflection: {reflectionCount}");
            Console.WriteLine($"  Listing: {listingCount}");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                breathingCount++;
            }
            else if (choice == "2")
            {
                ReflectionActivity reflection = new ReflectionActivity();
                reflection.Run();
                reflectionCount++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                listingCount++;
            }
        }
    }
}