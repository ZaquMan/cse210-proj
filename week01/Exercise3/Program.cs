using System;

class Program
{
    static void Main(string[] args)
    {
        // Get user-generated magic number
        //Console.Write("Please enter a number (DEBUG): ");
        //int magicNumber = int.Parse(Console.ReadLine());

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        //int guess;
        // Not sure if this needs to be declared before the do-while loop.

        do
        {
            Console.Write("What is your guess? ");
            int guess = int.Parse(Console.ReadLine());

            if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Higher");
            }
        } while (guess != magicNumber)

        Console.WriteLine($"You got it! {magicNumber} is the magic number.");
    }
}