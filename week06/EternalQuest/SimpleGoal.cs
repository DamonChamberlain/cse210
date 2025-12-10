// SimpleGoal.cs

public class SimpleGoal : Goal
{
    private bool _isComplete;

    // new goal constructor
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    // loading constructor
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    // override record event
    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"\ncongrats! you finished '{_shortName}' and got {_points} points!");
        }
        else
        {
            Console.WriteLine($"\nthis goal is already finished!");
        }
    }

    // override is complete
    public override bool IsComplete()
    {
        return _isComplete;
    }

    // override details string
    public override string GetDetailsString()
    {
        // shows [x] or [ ]
        string status = _isComplete ? "[x]" : "[ ]";
        return $"{status} {_shortName} ({_description}) - worth {_points} points";
    }

    // override string for saving
    public override string GetStringRepresentation()
    {
        // format: simplegoal|name|description|points|iscomplete
        return $"simplegoal|{_shortName}|{_description}|{_points}|{_isComplete}";
    }
}