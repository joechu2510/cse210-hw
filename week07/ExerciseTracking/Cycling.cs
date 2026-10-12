public class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int time, double speed) : base(date, time)
    {
        _speed = speed;
    }
    public override string GetActivityName() => "Cycling";
    public override double GetSpeed()
    {
        return _speed;
    }
    public override double GetDistance()
    {
        return (_time / 60.0) * _speed;
    }
    public override double GetPace()
    {
        return 60.0 / _speed;
    }
}