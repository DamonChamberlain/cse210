// EternalGoal.cs

public class EternalGoal : Goal
{
    // new goal constructor
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        // no extra state needed
    }

    // loading constructor (for consistency)
    public EternalGoal(string name, string description, int points, int currentCount) : base(name, description, points)
    {
        // no extra state to load
    }


    // override record event
    public override void RecordEvent()
    {
        Console.WriteLine($"\nevent saved for '{_shortName}'. you earned {_points} points!");
    }

    // override is complete
    public override bool IsComplete()
    {
        return false; // never complete
    }

    // override details string
    public override string GetDetailsString()
    {
        // example: [ ] read scriptures (100 points) -- eternal
        return $"[ ] {_shortName} ({_description}) - worth {_points} points -- eternal";
    }

    // override string for saving
    public override string GetStringRepresentation()
    {
        // format: eternalgoal|name|description|points
        return $"eternalgoal|{_shortName}|{_description}|{_points}";
    }
}