using System;

public class Journal
{
    List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        Console.WriteLine("DEBUG: New Entry HERE");
    }

    public void DisplayAll()
    {
        // TODO: Display one message if the journal is empty.
        // TODO: Iterate through entry list calling the .Display() func.
        Console.WriteLine("DEBUG: Display Entries HERE");
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