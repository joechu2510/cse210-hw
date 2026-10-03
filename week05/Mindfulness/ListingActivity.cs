public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _count = 0;
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nList as many responses you can to the following prompt");
        GetRandomPrompt();

        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> userList = GetListFromUser();
        _count = userList.Count;

        Console.WriteLine($"\nYou listed {_count} items!");

        DisplayEndingMessage();
    }
    public void GetRandomPrompt()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine($" --- {prompt} --- ");
    }
    public List<string> GetListFromUser()
    {
        List<string> userList = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            TimeSpan remaining = endTime - DateTime.Now;
            if (remaining.TotalMilliseconds <= 0)
                break;

            Console.Write("> ");
            var inputTask = Task.Run(() => Console.ReadLine());
            if (inputTask.Wait(remaining))
            {
                string input = inputTask.Result;
                if (!string.IsNullOrEmpty(input))
                {
                    userList.Add(input);
                }
            }
            else
            {
                break;
            }
        }
        return userList;
    }
}   