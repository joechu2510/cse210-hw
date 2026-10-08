public class ChecklistGoal : Goal
{
    private int _amountCompleted = 0;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public int GetTarget()
    {
        return _target;
    }
    public int GetBonus()
    {
        return _bonus;
    }
    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }
    public override void RecordEvent()
    {
        _amountCompleted ++;
        if (_amountCompleted == _target)
        {
            int pointsWithBonus = int.Parse(_points) + _bonus;
            Console.WriteLine($"Congratulations! You have earned {pointsWithBonus} points!");
        }
        else
        {
            Console.WriteLine($"Congratulations! You have earned {_points} points!");  
        }
    }
    public override bool IsComplete()
    {
        if (_amountCompleted >= _target)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override string GetDetailsString()
    {
        return $"({_description}) " + $"-- Currently completed: {_amountCompleted}/{_target}";
    }
    public override string GetStringRepresentation()
    {
        string no = "[ ]";
        string yes = "[X]";
        
        if (IsComplete() == true)
        {
            return $"{yes} " + $"{_shortName} " + $"{GetDetailsString()}"; 
        }
        else
        {
            return $"{no} " + $"{_shortName} " + $"{GetDetailsString()}";  
        }
    }
}