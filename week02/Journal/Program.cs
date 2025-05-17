using System;

class Program
{
    static void ShowMenu()
    {
        string menu = "";
        menu += "Please select one of the following choices:\n";
        menu += "1. Write\n";
        menu += "2. Display\n";
        menu += "3. Load\n";
        menu += "4. Save\n";
        menu += "5. Quit\n";
        menu += "What would you like to do? ";

        Console.Write(menu);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");

        // Create a new journal object to work with.
        Journal activeJournal = new Journal();

        // Create other empty variables for use in loop
        string userInput;
        string filename;

        // I want this to loop until the user chooses to stop it.
        while (true)
        {
            ShowMenu();
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Entry newEntry = new Entry();
                    newEntry.WriteEntry();
                    activeJournal.AddEntry(newEntry);
                    break;
                case "2":
                    activeJournal.DisplayAll();
                    break;
                case "3":
                    Console.Write("What is the name of the file to load? ");
                    filename = Console.ReadLine();
                    activeJournal.LoadFromFile(filename);
                    break;
                case "4":
                    Console.Write("What is the name of the file to save to? ");
                    filename = Console.ReadLine();
                    activeJournal.SaveToFile(filename);
                    break;
                case "5":
                    // Return in the main program quits it.
                    return;
                default:
                    Console.WriteLine($"{userInput} is not a valid option.");
                    break;
            }

        }
    }
}