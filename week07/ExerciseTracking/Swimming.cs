public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int time, int laps) : base(date, time)
    {
        _laps = laps;
    }
    public override string GetActivityName() => "Swimming";
    public override double GetDistance()
    {
        return _laps * 50.0 / 1000.0;
    }
    public override double GetSpeed()
    {
        return (GetDistance() / _time) * 60.0;
    }
    public override double GetPace()
    {
        return 60.0 / GetSpeed();
    }
}