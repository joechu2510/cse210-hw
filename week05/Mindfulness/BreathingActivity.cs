public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {}

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("\nBreathe in... ");
            ShowCountDown(4);

            if (DateTime.Now >= endTime) break;
            Console.Write("\nNow breathe out...");
            ShowCountDown(4);
        }
        DisplayEndingMessage();
    }
}