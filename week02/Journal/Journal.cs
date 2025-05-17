using System;

public class Journal
{
    List<Entry> _entries = new List<Entry>();

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
        Console.WriteLine("DEBUG: Saving file, I guess");
    }

    public void LoadFromFile(string filename)
    {
        Console.WriteLine("DEBUG: Loading, Loading, Loading");
    }
}