using System;

class Program
{
    static void Main(string[] args)
    {
        bool replay = true;

        while (replay)
        {
            // Get user-generated magic number
            //Console.Write("Please enter a number (DEBUG): ");
            //int magicNumber = int.Parse(Console.ReadLine());

            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            //int guess;
            // Not sure if this needs to be declared before the do-while loop.

            int guess;
            int numGuesses = 0;

            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                numGuesses++;

                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("Higher");
                }
            } while (guess != magicNumber);

            Console.WriteLine($"You got it! {magicNumber} is the magic number.  It took you {numGuesses} guesses.");


            Console.Write("Would you like to play again? (Yes/No) ");
            string replayString = Console.ReadLine();

            if (Char.ToLower(replayString[0]) != 'y')
            {
                replay = false;
            }
        }
    }
}