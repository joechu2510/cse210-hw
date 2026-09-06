using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int userScore = int.Parse(userInput);

        string letter = "";

        if (userScore >= 90)
        {
            letter = "A";
        }
        else if (userScore >= 80)
        {
            letter = "B";
        }
        else if (userScore >= 70)
        {
            letter = "C";
        }
        else if (userScore >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (userScore >= 70)
        {
            Console.WriteLine("Congratulations you pass the course!");
        }
        else
        {
            Console.WriteLine("You didn't pass the course, you can do it better next block!");
        }
    }
}