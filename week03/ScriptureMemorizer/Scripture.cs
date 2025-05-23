using System;
using System.Collections.Concurrent;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        //Parse reference into book, chapter, verse, and optional ending verse

        //Split the text into separate words and add Word class instances to the list
    }

    public void HideRandomWords(int numberToHide)
    {
        return;
    }

    public string GetDisplayText()
    {
        return "";
    }

    public bool IsCompletelyHidden()
    {
        return false;
    }
}