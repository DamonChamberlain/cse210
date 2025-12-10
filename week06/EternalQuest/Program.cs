// Program.cs

// using needed for streamwriter and file
using System;
using System.IO;

// --- description of exceeding requirements ---
/* * exceeding requirements: 
 * * 1. bonus logic: checklistgoal gives the bonus when the target is met.
 * 2. better look: score output is clear and easy to see.
 * 3. safer files: try-catch blocks are used for saving and loading files.
 * 4. factory pattern: goal loading uses a simple factory pattern to make the right object.
 * */
// -----------------------------------------------------------------

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}