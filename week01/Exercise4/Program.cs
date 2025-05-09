using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        string userInput = "0";
        int userNum;
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            userInput = Console.ReadLine();
            userNum = int.Parse(userInput);

            if (userNum != 0)
            {
                numbers.Add(userNum);
            }

        } while (userInput != "0");

        int sum = 0;
        int largestNum = -99999;
        int smallestPosNum = 9999;

        foreach (int number in numbers)
        {
            sum += number;

            if (number > largestNum)
            {
                largestNum = number;
            }

            if (number > 0 && number < smallestPosNum)
            {
                smallestPosNum = number;
            }
        }

        float average = ((float)sum) / numbers.Count;

        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNum}");
        Console.WriteLine($"The smallest positive number is: {smallestPosNum}");
        Console.WriteLine("The sorted list is:");
        numbers.ForEach(Console.WriteLine);
    }
}