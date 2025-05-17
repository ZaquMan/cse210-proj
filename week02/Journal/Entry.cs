using System;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;

    public void WriteEntry()
    {
        DateTime today = DateTime.Now;
        _date = today.ToShortDateString();

        PromptGenerator prompter = new PromptGenerator();
        _prompt = prompter.GetRandomPrompt();

        Console.WriteLine(_prompt);
        Console.Write("> ");
        _response = Console.ReadLine();
    }

    public void LoadEntry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine(_response);
        Console.WriteLine();
    }

    public string[] SaveEntry()
    {
        string[] data = {_date, _prompt, _response};
        return data;
    }
}