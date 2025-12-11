// The Program class will typically contain the Main method in a C# console application.
class Program
{
    static void Main(string[] args)
    {
        // Create at least one activity of each type
        Running run1 = new Running(new DateTime(2025, 12, 10), 30, 4.8);   // 4.8 km in 30 min
        Cycling cycle1 = new Cycling(new DateTime(2025, 12, 11), 45, 25.0); // 25.0 kph for 45 min
        Swimming swim1 = new Swimming(new DateTime(2025, 12, 11), 30, 20);  // 20 laps (1.0 km) in 30 min

        // Put each of these activities in the same list (List<Activity> enables polymorphism)
        List<Activity> activities = new List<Activity>
        {
            run1,
            cycle1,
            swim1
        };

        Console.WriteLine("--- Exercise Tracking Summary (in Kilometers) ---");
        Console.WriteLine();

        // Iterate through this list and call the GetSummary method on each item
        foreach (Activity activity in activities)
        {
            // The correct GetDistance, GetSpeed, and GetPace methods are called
            // based on the actual object type (Running, Cycling, Swimming) at runtime.
            // This is the core of polymorphism.
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }

        Console.WriteLine("-------------------------------------------------");
    }
}