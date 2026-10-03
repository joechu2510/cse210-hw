public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine($"\n{_description}");
        Console.WriteLine("\nHow long, in seconds would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}");
        ShowSpinner(3);
    }
    public void ShowSpinner(int seconds)
    {
        List<string> spinnerStrings = new List<string>
        {"|", "/", "-", "\\", "|", "/", "-", "\\"};

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = spinnerStrings[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i++;
            if (i >= spinnerStrings.Count)
            {
                i = 0;
            }
        }
    }
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}