using System;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count > 0)
        {
            foreach (Entry journalEntry in _entries)
            {
                journalEntry.Display();
            }
        }
        else
        {
            Console.WriteLine("There are no journal entries to display");
        }
        
    }

    public void SaveToFile(string filename)
    {
        
        if (_entries.Count > 0)
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry journalEntry in _entries)
                {
                    string[] entryData = journalEntry.SaveEntry();
                    string dataOutput = String.Join("|", entryData);
                    outputFile.WriteLine($"{dataOutput}");
                }
            }
        }
        else
        {
            Console.WriteLine("There is nothing to save.");
        }
    }

    public void LoadFromFile(string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            string date = parts[0];
            string prompt = parts[1];
            string response = parts[2];

            Entry newEntry = new Entry();
            newEntry.LoadEntry(date, prompt, response);
            _entries.Add(newEntry);
        }
    }
}