public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {}

    public void MarkComplete()
    {
        _isComplete = true;
    }
    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Congratulations! You have earned {_points} points!");
    }
    public override bool IsComplete()
    {
        if (_isComplete == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override string GetStringRepresentation()
    {
        string no = "[ ]";
        string yes = "[X]";
        
        if (IsComplete() == true)
        {
            return $"{yes} " + $"{_shortName} " + $"({GetDetailsString()})"; 
        }
        else
        {
            return $"{no} " + $"{_shortName} " + $"({GetDetailsString()})";  
        }
    }
}