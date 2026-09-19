// Added feature to read scriptures from a file and pick one randomly
using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "scriptures.txt";
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"The file '{filePath}' was not found. Make sure to create it in the project folder.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        if (lines.Length == 0)
        {
            Console.WriteLine("The archive is empty.");
            return;
        }

        Random randomScripture = new Random();
        int randomIndex = randomScripture.Next(0, lines.Length);
        string randomLine = lines[randomIndex];

        string[] parts = randomLine.Split("|");
        string book = parts[0];
        int chapter = int.Parse(parts[1]);
        int startVerse = int.Parse(parts[2]);
        int endVerse = int.Parse(parts[3]);
        string text = parts[4];

        Reference reference;
        if (endVerse == 0)
        {
            reference = new Reference(book, chapter, startVerse);
        }
        else
        {
            reference = new Reference(book, chapter, startVerse, endVerse);
        }

        Scripture scripture = new Scripture(reference, text);

        string userInput = "";

        while (userInput != "quit")
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("Press enter to finish or type 'quit' to finish: ");
                userInput = Console.ReadLine();
                break;
            }

            Console.WriteLine("Press enter to finish or type 'quit' to finish: ");
            userInput = Console.ReadLine();

            if (userInput == "")
            {
                scripture.HideRandomWords(3);
            }
        }
    }
}