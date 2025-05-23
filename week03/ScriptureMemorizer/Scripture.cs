using System;
using System.Collections.Concurrent;
using System.Threading.Tasks.Dataflow;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(string reference, string text)
    {
        // Parse reference into book, chapter, verse, and optional ending verse
        string[] parts = reference.Split([' ', ':', '-']);
        // Words Of Mormon 1:1-3 => ["Words", "Of", "Mormon", "1", "1", "3"]
        // This is the most complicated reference, a multi-word book, and multiple verses

        // If there is a hyphen, use the 4-parameter constructor
        if (reference.IndexOf('-') >= 0)
        {
            string[] bookParts = parts[0..^3];
            string book = string.Join(" ", bookParts);
            int chapter = int.Parse(parts[^3]);
            int verse = int.Parse(parts[^2]);
            int endVerse = int.Parse(parts[^1]);

            _reference = new Reference(book, chapter, verse, endVerse);
        }
        else // Use the 3-parameter constructor
        {
            string[] bookParts = parts[0..^2];
            string book = string.Join(" ", bookParts);
            int chapter = int.Parse(parts[^2]);
            int verse = int.Parse(parts[^1]);

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
}