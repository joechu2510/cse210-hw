// Added a mood tracker field to each journal entry to save additional personal data

using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        int userOption = -1; 
        Journal theJournal = new Journal();

        while (userOption != 5)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("What would you like to do?");
            userOption = int.Parse(Console.ReadLine());

            if (userOption == 1)
            {
                PromptGenerator promptGenerator = new PromptGenerator();
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                
                string userResponse = Console.ReadLine();

                Console.WriteLine("How are you feeling today? ");
                string userMood = Console.ReadLine();

                string currentDate = DateTime.Now.ToShortDateString();
                
                Entry newEntry = new Entry();
                newEntry._date = currentDate;
                newEntry._promptText = prompt;
                newEntry._entryText = userResponse;
                newEntry._mood = userMood;

                theJournal.AddEntry(newEntry);
            }

            else if (userOption == 2)
            {
                theJournal.DisplayAll();
            }

            else if (userOption == 3)
            {
                Console.WriteLine("What is the filename? ");
                string filename = Console.ReadLine();
                theJournal.LoadFromFile(filename);
            }

            else if (userOption == 4)
            {
                Console.WriteLine("What is the filename? ");
                string filename = Console.ReadLine();
                theJournal.SaveToFile(filename);
                }
        }
    }
}