using System;

public class Entry
{
    string _date;
    string _prompt;
    string _response;

    public Entry()
    {
        DateTime today = DateTime.Now;
        _date = today.ToShortDateString();

        PromptGenerator prompter = new PromptGenerator();
        _prompt = prompter.GetRandomPrompt();

        Console.WriteLine(_prompt);
        Console.Write("> ");
        _response = Console.ReadLine();
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine(_response);
        Console.WriteLine();
    }
}