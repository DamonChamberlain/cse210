// ChecklistGoal.cs

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // new goal constructor
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    // loading constructor
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    // override record event
    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            Console.WriteLine($"\nevent recorded for '{_shortName}'. you earned {_points} points!");

            if (_amountCompleted == _target)
            {
                // goal is complete, award bonus
                Console.WriteLine($"\n*** congrats! you finished the goal '{_shortName}'! ***");
                Console.WriteLine($"you earned a bonus of {_bonus} points!");
            }
        }
        else
        {
            Console.WriteLine($"\nthis goal is already finished ({_target}/{_target}) and is no longer tracked.");
        }
    }

    // override is complete
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    // override details string
    public override string GetDetailsString()
    {
        // example: [ ] attend temple (50 points) -- currently completed 2/10
        string status = IsComplete() ? "[x]" : "[ ]";
        return $"{status} {_shortName} ({_description}) - worth {_points} points - completed {_amountCompleted}/{_target}";
    }

    // override string for saving
    public override string GetStringRepresentation()
    {
        // format: checklistgoal|name|description|points|target|bonus|amountcompleted
        return $"checklistgoal|{_shortName}|{_description}|{_points}|{_target}|{_bonus}|{_amountCompleted}";
    }
}