using System.ComponentModel;
using System.Globalization;

public class Activity
{
    //Variables
    protected string _name;
    protected string _description;
    protected int _duration;

    //Constructors
    public Activity()
    {
        _name = "Unknown";
        _description = "An unknown activity";
        _duration = 0;
    }

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    //Methods
    public void DisplayStartingMessage()
    {
        //Start activity with a clean screen.
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n\n" +
                          $"{_description}\n");
        Console.Write($"How long would you like to spend on the {_name}, in seconds? ");

        bool inputPasses = false;

        do
        {
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, NumberStyles.None, null, out int userDuration))
            {
                _duration = userDuration;
                inputPasses = true;
            }
            else
            {
                Console.WriteLine($"\"{userInput}\" is not a valid duration.  Please enter a new number.\n");
                Console.Write($"How long would you like to spend on the {_name} activity (seconds)? ");
            }

        } while (!inputPasses);

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);

    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!");
        ShowSpinner(5);

        Console.WriteLine($"You have completed the {_name}, spending {_duration} seconds being mindful.");
        ShowSpinner(5);
    }

    public void ShowSpinner(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        while(endTime > DateTime.Now)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    public void ShowCountDownSeconds(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000);
            Console.Write("\b");
        }
        Console.WriteLine();
    }
}