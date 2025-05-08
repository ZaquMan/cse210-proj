using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percent: ");
        string userInput = Console.ReadLine();
        int percent = int.Parse(userInput);

        string letter;

        int passingPercent = 70;

        // Match percent to a letter
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string symbol = "";

        if ((percent % 10) >= 7 && !(letter == "A" || letter == "F"))
        {
            symbol = "+";
        }
        else if ((percent % 10) < 3 && letter != "F")
        {
            symbol = "-";
        }

        string article = "a";

        // Determine the correct article for the letter grade
        if (letter == "A" || letter == "F")
        {
            article += "n";
        }

        Console.WriteLine($"You received {article} {letter}{symbol} in the class.");

        if (percent >= passingPercent)
        {
            Console.WriteLine("Congratulations on passing the class!");
        }
        else
        {
            Console.WriteLine("You'll be able to pass next time with a little more hard work!");
        }
    }
}