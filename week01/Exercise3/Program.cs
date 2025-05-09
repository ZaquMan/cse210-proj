using System;

class Program
{
    static void Main(string[] args)
    {
        bool replay = true;

        while (replay)
        {
            // Declare game variables.  These will reset each time the game is replayed.
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
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

            // I'm going to accept anything that starts with a 'y' as a confirmation.
            if (Char.ToLower(replayString[0]) != 'y')
            {
                replay = false;
            }
        }
    }
}