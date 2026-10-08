using System.IO;
public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager()
    {}

    public void Start()
    {
        int userInput = -1;

        while (userInput != 6)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");
            Console.Write("Select a choice from the menu: ");
            userInput = int.Parse(Console.ReadLine());
            if (userInput == 1)
            {
                CreateGoal();
            }
            else if (userInput == 2)
            {
                ListGoalDetails();
            }
            else if (userInput == 3)
            {
                SaveGoals();
            }
            else if (userInput == 4)
            {
                LoadGoals();
            }
            else if (userInput == 5)
            {
                RecordEvent();
            }
        
        }
    }
    public void DisplayPlayerInfo()
    {
        int level = (_score / 100) + 1;
        
        Console.WriteLine($"\nYou have {_score} points | Current Level: {level}");
    }
    public void ListGoalNames()
    {
        int i = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.GetName()}");
            i++;
        }
    }
    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        int i = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.GetStringRepresentation()}");
            i++;
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.WriteLine("Which type of goal would you like to create? ");
        string newGoal = Console.ReadLine();
        if (newGoal == "1")
        {
            Console.Write("What is the name of your goal? Give a talk ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            string points = Console.ReadLine();
            SimpleGoal n1 = new SimpleGoal(name, description, points);
            _goals.Add(n1);
        }
        else if (newGoal == "2")
        {
            Console.Write("What is the name of your goal? Give a talk ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            string points = Console.ReadLine();
            EternalGoal n2 = new EternalGoal(name, description, points);
            _goals.Add(n2);
        }
        else if (newGoal == "3")
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            string points = Console.ReadLine();
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            ChecklistGoal n3 = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(n3);
        }
    }
    public void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count())
        {
            Goal selectedGoal = _goals[choice];
            selectedGoal.RecordEvent();
            int pointsEarned = int.Parse(selectedGoal.GetPoints());

            if (selectedGoal is ChecklistGoal checklist && checklist.GetAmountCompleted() == checklist.GetTarget())
            {
                pointsEarned += checklist.GetBonus();
            }

            _score += pointsEarned;
            Console.WriteLine($"You now have {_score} points");
        }
        else
        {
            Console.WriteLine("Invalid selection");
        }
    }
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                if (goal is SimpleGoal simple)
                {
                    outputFile.WriteLine($"SimpleGoal:{simple.GetName()},{simple.GetDetailsString().Trim('(', ')')},{simple.GetPoints()},{simple.IsComplete()}");
                }
                else if (goal is EternalGoal eternal)
                {
                    outputFile.WriteLine($"EternalGoal:{eternal.GetName()},{eternal.GetDetailsString().Trim('(', ')')},{eternal.GetPoints()}");
                }
                else if (goal is ChecklistGoal checklist)
                {
                    outputFile.WriteLine($"ChecklistGoal:{checklist.GetName()},{checklist.GetDetailsString().Split('(')[1].Split(')')[0]},{checklist.GetPoints()},{checklist.GetBonus()},{checklist.GetTarget()},{checklist.GetAmountCompleted()}");
                }
            }
        }
    }
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(':');
                string goalType = parts[0];
                string details = parts[1];

                string[] values = details.Split(',');

                if (goalType == "SimpleGoal")
                {
                    string name = values[0];
                    string description = values[1];
                    string points = values[2];
                    bool isComplete = bool.Parse(values[3]);

                    SimpleGoal goal = new SimpleGoal(name, description, points);
                    if (isComplete)
                    {
                        goal.MarkComplete();
                    }
                    _goals.Add(goal);
                }
                else if (goalType == "EternalGoal")
                {
                    string name = values[0];
                    string description = values[1];
                    string points = values[2];

                    EternalGoal goal = new EternalGoal(name, description, points);
                    _goals.Add(goal);
                }
                else if (goalType == "ChecklistGoal")
                {
                    string name = values[0];
                    string description = values[1];
                    string points = values[2];
                    int bonus = int.Parse(values[3]);
                    int target = int.Parse(values[4]);
                    int amountCompleted = int.Parse(values[5]);
                    ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
                    goal.SetAmountCompleted(amountCompleted);

                    _goals.Add(goal);
                }
            }
            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}