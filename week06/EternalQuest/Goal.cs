// Goal.cs

public abstract class Goal
{
    // private members
    protected string _shortName;
    protected string _description;
    protected int _points;

    // constructor
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // getters for saving/loading
    public string ShortName => _shortName;
    public string Description => _description;
    public int Points => _points;


    // abstract methods
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation(); // for saving
}