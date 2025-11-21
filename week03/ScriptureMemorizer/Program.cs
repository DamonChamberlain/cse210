using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        /*
        stretch goals:
        1. scripture library: load scriptures from "scriptures.txt" using the ScriptureLibrary class.
        2. random scripture: pick a random scripture from the library when the program starts.
        3. smarter hiding: make HideRandomWords only pick from words that aren't already hidden. this
           feels way better for the user.
        4. file handling: added a try/catch in ScriptureLibrary just in case the file is missing.
        */

        // load the scripture library
        ScriptureLibrary library = new ScriptureLibrary("scriptures.txt");
        Scripture scripture = library.GetRandomScripture();

        // handle case where no scriptures could be loaded
        if (scripture == null)
        {
            Console.WriteLine("Error: Could not load any scriptures. Please check 'scriptures.txt'.");
            return;
        }

        int wordsToHidePerTurn = 3; // number of words to hide each time

        // main program loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine(); // add a blank line for spacing

            // check if all words are hidden
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Well done!");
                break;
            }

            // prompt user
            Console.Write("Press enter to hide words, or type 'quit' to exit: ");
            string input = Console.ReadLine() ?? ""; // handle potential null input

            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break; // exit the loop if user types 'quit'
            }
            else
            {
                // hide a few more random words
                scripture.HideRandomWords(wordsToHidePerTurn);
            }
        }

        Console.WriteLine("Thank you for using the Scripture Memorizer!");
    }
}
