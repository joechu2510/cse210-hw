public abstract class Activity
{
    private static List<Activity> _list = new List<Activity>();
    protected string _date;
    protected int _time;

    public Activity (string date, int time)
    {
        _date = date;
        _time = time;
        _list.Add(this);
    }
    public static List<Activity> GetList()
    {
        return _list;
    }
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public virtual string GetActivityName()
    {
        return "Activity";
    }
    public virtual void GetSummary()
    {
        Console.WriteLine($"{_date} {GetActivityName()} ({_time} min) - Distance {GetDistance():F2} km, Speed {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km");
    }
}