using System;

class Program
{
    static void Main(string[] args)
    {
        // Hard-coded references.  Above and beyond could be getting these from user input.
        string reference = "3rd Nephi 11:4-7";
        string verse = "And it came to pass that again they heard the voice, and they understood it ";
        verse += "not. And again the third time they did hear the voice, and did open their ears to ";
        verse += "hear it; and their eyes were towards the sound thereof; and they did look ";
        verse += "steadfastly towards heaven, from whence the sound came. And behold, the third ";
        verse += "time they did understand the voice which they heard; and it said unto them: Behold ";
        verse += "my Beloved Son, in whom I am well pleased, in whom I have glorified my name—hear ye him.";

        int numberToHide = 3;

        Scripture script1 = new Scripture(reference, verse);

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