// GoalManager.cs

using System.IO;

public class GoalManager
{
    // private members
    private List<Goal> _goals;
    private int _score;

    // constructor
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // score getter
    public int Score => _score;

    // show player score
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\n==============================");
        Console.WriteLine($"you currently have **{_score}** points!");
        Console.WriteLine($"==============================\n");
    }

    // main menu loop
    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("menu options:");
            Console.WriteLine("  1. create new goal");
            Console.WriteLine("  2. list goals");
            Console.WriteLine("  3. save goals");
            Console.WriteLine("  4. load goals");
            Console.WriteLine("  5. record event");
            Console.WriteLine("  6. quit");
            Console.Write("select a choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("\nthanks for using the program. goodbye!");
                    break;
                default:
                    Console.WriteLine("bad option. try again.");
                    break;
            }
        }
    }

    // list goals with details
    public void ListGoalDetails()
    {
        Console.WriteLine("\nthe goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("you have no goals yet!");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            // use polymorphism
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    // ask user to make a new goal
    public void CreateGoal()
    {
        Console.WriteLine("\nthe types of goals are:");
        Console.WriteLine("  1. simple goal");
        Console.WriteLine("  2. eternal goal");
        Console.WriteLine("  3. checklist goal");
        Console.Write("which type of goal do you want to make? ");
        string typeChoice = Console.ReadLine();

        // get common details
        Console.Write("what is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("what is a short description? ");
        string description = Console.ReadLine();
        Console.Write("how many points is it worth? ");
        int points = int.Parse(Console.ReadLine());

        // create the specific goal
        switch (typeChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("how many times to finish for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("what is the bonus amount? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("bad goal type. going back to menu.");
                return;
        }

        Console.WriteLine($"\ngoal '{name}' made!");
    }

    // record an event and update score
    public void RecordEvent()
    {
        ListGoalNames();

        Console.Write("which goal did you finish? ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            Goal goal = _goals[index - 1];

            // use polymorphism
            goal.RecordEvent();

            // update points
            _score += goal.Points;
            
            // if it's a checklist goal that just finished, add the bonus points
            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                // this relies on recordevent being the catalyst for completion
            }

            DisplayPlayerInfo();
        }
        else
        {
            Console.WriteLine("bad goal number. try again.");
        }
    }

    // helper to list only names
    public void ListGoalNames()
    {
        Console.WriteLine("\nthe goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("you have no goals yet!");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }
    }

    // save goals to file
    public void SaveGoals()
    {
        Console.Write("what is the filename? ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                // save score first
                outputFile.WriteLine(_score);

                // save each goal's string
                foreach (Goal goal in _goals)
                {
                    // use polymorphism
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"\ngoals and score saved to '{filename}'!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\na save error happened: {ex.Message}");
        }
    }

    // load goals from file
    public void LoadGoals()
    {
        Console.Write("what is the filename to load? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"\nerror: file '{filename}' not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            // load score from the first line
            if (lines.Length > 0 && int.TryParse(lines[0], out int loadedScore))
            {
                _score = loadedScore;
            }
            else
            {
                Console.WriteLine("warning: could not load score. score set to 0.");
                _score = 0;
            }

            // clear old goals and load new ones
            _goals.Clear();
            for (int i = 1; i < lines.Length; i++)
            {
                // factory pattern logic
                string line = lines[i];
                string[] parts = line.Split('|');
                string goalType = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                Goal newGoal = null;
                switch (goalType)
                {
                    case "simplegoal":
                        bool isComplete = bool.Parse(parts[4]);
                        newGoal = new SimpleGoal(name, description, points, isComplete);
                        break;
                    case "eternalgoal":
                        // no extra state
                        newGoal = new EternalGoal(name, description, points);
                        break;
                    case "checklistgoal":
                        int target = int.Parse(parts[4]);
                        int bonus = int.Parse(parts[5]);
                        int amountCompleted = int.Parse(parts[6]);
                        newGoal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                        break;
                }

                if (newGoal != null)
                {
                    _goals.Add(newGoal);
                }
            }

            Console.WriteLine($"\ngoals and score loaded from '{filename}'!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\na load error happened: {ex.Message}");
        }
    }
}