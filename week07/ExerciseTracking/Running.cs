public class Running : Activity
{
    private double _distance;
    public Running(string date, int time, double distance) : base(date, time)
    {
        _distance = distance;
    }
    public override string GetActivityName() => "Running";
    public override double GetDistance()
    {
        return _distance;
    }
    public override double GetSpeed()
    {
        return _distance / _time * 60.0;
    }
    public override double GetPace()
    {
        return _time / _distance;
    }
}