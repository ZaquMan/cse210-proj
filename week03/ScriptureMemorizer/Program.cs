//Above and Beyond:
//Get reference from user input and pull the text from json scripture objects.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Please enter a scripture reference that you'd like to memorize. Or leave it blank for the default scripture.");
        Console.WriteLine("If your reference includes a number, do not include the 'st', 'rd', etc. EX: 1 Nephi");
        Console.Write("Scripture Reference (Default: 3 Nephi 11:4-7): ");

        string reference = Console.ReadLine();

        Scripture script1;

        if (reference != "")
        {
            script1 = new Scripture(reference);
        }
        else
        {
            reference = "3 Nephi 11:4-7";
            string verse = "And it came to pass that again they heard the voice, and they understood it ";
            verse += "not. And again the third time they did hear the voice, and did open their ears to ";
            verse += "hear it; and their eyes were towards the sound thereof; and they did look ";
            verse += "steadfastly towards heaven, from whence the sound came. And behold, the third ";
            verse += "time they did understand the voice which they heard; and it said unto them: Behold ";
            verse += "my Beloved Son, in whom I am well pleased, in whom I have glorified my name—hear ye him.";

            script1 = new Scripture(reference, verse);
        }

        int numberToHide = 3;

        while (!script1.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(script1.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press enter to continue or type 'quit' to finish:");

            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                // Leave the main function, ending the program;
                return;
            }
            // Else continue
            script1.HideRandomWords(numberToHide);

            // Loop back to the top
            // Console.WriteLine(script1.GetDisplayText());
        }

        // Once all is hidden, print the scripture one more time with all the blanks
        Console.Clear();
        Console.WriteLine(script1.GetDisplayText());
    }
}