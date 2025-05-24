using System;
using System.Collections;
using System.Collections.Concurrent;
using System.IO.Enumeration;
using System.Text.Json;
using System.Threading.Tasks.Dataflow;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Dictionary<string, List<string>> _bookToFilename;

    public Scripture(string reference)
    {
        // Initialize _words, to be used in GetScriptureFromJson()
        _words = new List<Word>();

        FilenameDictionaryConstructor();

        // Parse reference into book, chapter, verse, and optional ending verse
        string[] parts = reference.Split([' ', ':', '-']);
        // Words Of Mormon 1:1-3 => ["Words", "Of", "Mormon", "1", "1", "3"]
        // This is the most complicated reference, a multi-word book, and multiple verses

        string book;
        int chapter;
        int verse;
        int endVerse = 0;
        // If there is a hyphen, use the 4-parameter constructor
        if (reference.IndexOf('-') >= 0)
        {
            string[] bookParts = parts[0..^3];
            book = string.Join(" ", bookParts);
            chapter = int.Parse(parts[^3]);
            verse = int.Parse(parts[^2]);
            endVerse = int.Parse(parts[^1]);

            _reference = new Reference(book, chapter, verse, endVerse);

            GetScriptureFromJson(book, chapter, verse, endVerse);
        }
        else // Use the 3-parameter constructor
        {
            string[] bookParts = parts[0..^2];
            book = string.Join(" ", bookParts);
            chapter = int.Parse(parts[^2]);
            verse = int.Parse(parts[^1]);

            _reference = new Reference(book, chapter, verse);

            GetScriptureFromJson(book, chapter, verse);
        }

        // Split the text into separate words and add Word class instances to the list
        // Initialize the list
    }

    public Scripture(string reference, string text)
    {
        // Parse reference into book, chapter, verse, and optional ending verse
        string[] parts = reference.Split([' ', ':', '-']);
        // Words Of Mormon 1:1-3 => ["Words", "Of", "Mormon", "1", "1", "3"]
        // This is the most complicated reference, a multi-word book, and multiple verses

        string book;
        int chapter;
        int verse;
        int endVerse = 0;
        // If there is a hyphen, use the 4-parameter constructor
        if (reference.IndexOf('-') >= 0)
        {
            string[] bookParts = parts[0..^3];
            book = string.Join(" ", bookParts);
            chapter = int.Parse(parts[^3]);
            verse = int.Parse(parts[^2]);
            endVerse = int.Parse(parts[^1]);

            _reference = new Reference(book, chapter, verse, endVerse);
        }
        else // Use the 3-parameter constructor
        {
            string[] bookParts = parts[0..^2];
            book = string.Join(" ", bookParts);
            chapter = int.Parse(parts[^2]);
            verse = int.Parse(parts[^1]);

            _reference = new Reference(book, chapter, verse);
        }

        // Split the text into separate words and add Word class instances to the list
        // Initialize the list
        _words = new List<Word>();

        string[] verseText = text.Split();
        foreach (string verseWord in verseText)
        {
            Word newWord = new Word(verseWord);
            _words.Add(newWord);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int counter = 0;
        int wordsLeftThisRound;
        int numAvailableWords = 0;

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                numAvailableWords++;
            }
        }

        if (numAvailableWords < numberToHide)
        {
            wordsLeftThisRound = numAvailableWords;
        }
        else
        {
            wordsLeftThisRound = numberToHide;
        }

        while (counter < wordsLeftThisRound)
        {
            int i = random.Next(_words.Count);
            if (!_words[i].IsHidden())
            {
                counter++;
                _words[i].Hide();
            }
        }
    }

    public string GetDisplayText()
    {
        List<string> parts = [$"{_reference.GetDisplayText()}"];

        foreach (Word verseWord in _words)
        {
            parts.Add(verseWord.GetDisplayText());
        }
        return string.Join(' ', parts);
    }

    public bool IsCompletelyHidden()
    {
        // If any one word is not hidden, this is false
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    private void GetScriptureFromJson(string book, int chapter, int verse)
    {
        string[] verseText = [];
        string filename = "";

        foreach (var item in _bookToFilename)
        {
            if (item.Value.Contains(book))
            {
                filename = item.Key;
            }
        }

        string jsonText = File.ReadAllText(filename);

        using (JsonDocument scriptureJson = JsonDocument.Parse(jsonText))
        {
            JsonElement root = scriptureJson.RootElement;
            
            string text1 = root.GetProperty(book)
                                       .GetProperty(chapter.ToString())
                                       .GetProperty(verse.ToString())
                                       .GetString();
            verseText = text1.Split();
            
        }

        foreach (string verseWord in verseText)
        {
            Word newWord = new Word(verseWord);
            _words.Add(newWord);
        }
    }

    private void GetScriptureFromJson(string book, int chapter, int verse, int endVerse)
    {
        string[] verseText = [];
        string filename = "";

        foreach (var item in _bookToFilename)
        {
            if (item.Value.Contains(book))
            {
                filename = item.Key;
            }
        }

        string jsonText = File.ReadAllText(filename);

        using (JsonDocument scriptureJson = JsonDocument.Parse(jsonText))
        {
            JsonElement root = scriptureJson.RootElement;

            for (int i = verse; i <= endVerse; i++)
            {
                //Calling it text1 since the function parameter is already called text
                string text1 = root.GetProperty(book)
                                       .GetProperty(chapter.ToString())
                                       .GetProperty(i.ToString())
                                       .GetString();
                verseText = verseText.Concat(text1.Split()).ToArray();
            }


        }

        foreach (string verseWord in verseText)
        {
            Word newWord = new Word(verseWord);
            _words.Add(newWord);
        }
    }

    private void FilenameDictionaryConstructor()
    {
        _bookToFilename = new Dictionary<string, List<string>>();
        _bookToFilename.Add("book-of-mormon-reference.json", new List<string>([
            "1 Nephi", "2 Nephi", "Jacob", "Enos", "Jarom", "Omni", "Words of Mormon",
            "Mosiah", "Alma", "Helaman", "3 Nephi", "4 Nephi", "Mormon", "Ether", "Moroni"
        ]));

        List<string> dcSections = new List<string>();
        for (int i = 1; i <= 138; i++)
        {
            dcSections.Add($"{i}");
        }
        _bookToFilename.Add("doctrine-and-covenants-reference.json", dcSections);

        _bookToFilename.Add("new-testament-reference.json", new List<string>([
            "Matthew", "Mark", "Luke", "John", "Acts", "Romans", "1 Corinthians",
            "2 Corinthians", "Galatians", "Ephesians", "Philippians", "Colossians",
            "1 Thessalonians", "2 Thessalonians", "1 Timothy", "2 Timothy", "Titus",
            "Philemon", "Hebrews", "James", "1 Peter", "2 Peter", "1 John", "2 John",
            "3 John", "Jude", "Revelation"
        ]));

        _bookToFilename.Add("pearl-of-great-price-reference.json", new List<string>([
            "Moses", "Abraham", "Joseph Smith—Matthew", "Joseph Smith—History",
            "Articles of Faith"
        ]));
        
        _bookToFilename.Add("old-testament-reference.json", new List<string>([
            "Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy", "Joshua",
            "Judges", "Ruth", "1 Samuel", "2 Samuel", "1 Kings", "2 Kings",
            "1 Chronicles", "2 Chronicles", "Ezra", "Nehemiah", "Esther", "Job",
            "Psalms", "Proverbs", "Ecclesiastes", "Solomon's Song", "Isaiah",
            "Jeremiah", "Lamentations", "Ezekiel", "Daniel", "Hosea", "Joel", "Amos",
            "Obadiah", "Jonah", "Micah", "Nahum", "Habakkuk", "Zephaniah", "Haggai",
            "Zechariah", "Malachi"
        ]));
    }
}