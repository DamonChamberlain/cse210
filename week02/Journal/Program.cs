ausing System;
using System.IO;
using System.Collections.Generic;

// The main application class for the Journal Program.
public class Program
{
    /*
    * Exceeding Requirements:
    * 1. Added three custom prompts to the PromptGenerator's list, exceeding the minimum of five.
    * 2. Added basic error handling (try-catch blocks) in the Journal class for file operations (FileNotFoundException, general Exception).
    * 3. Implemented a ToFileString() method in the Entry class for better abstraction of the file format logic.
    */

    public static void Main(string[] args)
    {
        // initialize core objects
        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        string choice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        while (choice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Write a new entry
                    // 1. Get a random prompt
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    
                    // 2. Get the user's response
                    Console.Write("> ");
                    string entryText = Console.ReadLine();

                    // 3. Get the current date
                    DateTime theCurrentTime = DateTime.Now;
                    string dateText = theCurrentTime.ToShortDateString();

                    // 4. Create the new Entry object
                    Entry newEntry = new Entry
                    {
                        _date = dateText,
                        _promptText = prompt,
                        _entryText = entryText
                    };

                    // 5. Add the entry to the journal
                    myJournal.AddEntry(newEntry);
                    break;

                case "2": // Display the journal
                    myJournal.DisplayAll();
                    break;

                case "3": // Load the journal from a file
                    Console.Write("What is the filename? ");
                    string loadFilename = Console.ReadLine();
                    myJournal.LoadFromFile(loadFilename);
                    break;

                case "4": // Save the journal to a file
                    Console.Write("What is the filename? ");
                    string saveFilename = Console.ReadLine();
                    myJournal.SaveToFile(saveFilename);
                    break;

                case "5": // Quit
                    Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}