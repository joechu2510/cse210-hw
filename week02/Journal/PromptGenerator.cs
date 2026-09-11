using System;
using System.Collections.Generic;
public class PromptGenerator
{
    public List<string> _prompts;
    public string GetRandomPrompt()
    {
        List<string> prompts = new List<string>
        {
            "What was the most unexpected moment of your day today?",
            "When did you feel most at peace or relaxed over the last 24 hours?",
            "What is one small detail from today that you want to make sure you never forget?",
            "When did you feel most proud of yourself today, even for something small?",
            "Who made you smile or laugh the most today, and why?",
            "If today had a theme song or a title, what would it be?",
            "What is something you are deeply grateful for right this moment?",
            "If today was a chapter in a book about your life, what would the title of the chapter be?",
            "What was the most delicious thing you ate or drank today?",
            "What is a goal you moved closer to achieving today?"
        };

        Random randomGenerator = new Random();
        int index = randomGenerator.Next(prompts.Count);
        string randomPrompt = prompts[index];
        return randomPrompt;
    }
}