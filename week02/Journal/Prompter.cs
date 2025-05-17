using System;

public class PromptGenerator
{
    List<string> _prompts = new List<string>();

    public PromptGenerator()
    {
        // Constructors are coming next week, but I don't want to add prompts in the main program class.
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
    }

    public string GetRandomPrompt()
    {
        // Generate a random number between 0 and the number of entries in _prompts
        Random rnd = new Random();
        int i = rnd.Next(_prompts.Count);

        // Return the prompt at the iterator generated.
        return _prompts[i];
    }
}