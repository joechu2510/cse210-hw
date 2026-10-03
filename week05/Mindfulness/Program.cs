// Adding a custom GratitudeActivity.cs as a new activity.

using System;

class Program
{
    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "5")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start gratitude activity (Extra)");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
            }
            else if (choice == "4")
            {
                GratitudeActivity gratitude = new GratitudeActivity();
                gratitude.Run();
            }
            else if (choice == "5")
            {
                Console.WriteLine("\nThank you for using the Mindfulness App. Goodbye!");
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Please press enter to try again.");
                Console.ReadLine();
            }
        }
    }
}