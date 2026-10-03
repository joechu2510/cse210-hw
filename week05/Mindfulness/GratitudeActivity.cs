using System;
using System.Collections.Generic;
using System.Threading;

public class GratitudeActivity : Activity
{
    private List<string> _gratitudePrompts;

    public GratitudeActivity() : base("Gratitude Activity", "This activity will help you cultivate mindfulness and joy by focusing on the blessings and positive aspects of your life.")
    {
        _gratitudePrompts = new List<string>
        {
            "Think of a small, comforting moment you experienced today.",
            "What is something or someone you took for granted recently that you appreciate now?",
            "What is a challenging situation that taught you a valuable lesson?",
            "Think of someone who has brought unexpected joy into your life.",
            "What is a physical ability or comfort you enjoy every day that you are thankful for?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.Clear();
        Console.WriteLine("Consider the following thought on gratitude:\n");
        DisplayPrompt();

        Console.WriteLine("\nWhen you have something in mind, press enter to begin your reflection.");
        Console.ReadLine();

        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\nTake a moment to deeply appreciate this...");
            ShowSpinner(8);
            
            if (DateTime.Now >= endTime) break;

            Console.WriteLine("Let the feeling of thankfulness fill your mind.");
            ShowSpinner(7);
        }

        DisplayEndingMessage();
    }

    public void DisplayPrompt()
    {
        Random random = new Random();
        string prompt = _gratitudePrompts[random.Next(_gratitudePrompts.Count)];
        Console.WriteLine($" --- {prompt} --- ");
    }
}