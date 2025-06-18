using System;

//Above and Beyond:  A rudimentary, and rude, leveling system has been introduced.
//When a goal awards points, 1/10 of those (rounded down) count towards the next level.
//So while if the quest points are cleanly divisible by 10, then 1000 points equals a
//new level, anything remainders in that division are lost.  Also, any level progress
//does not carry over.


class Program
{
    static void Main(string[] args)
    {
        //The Main program doesn't actually do much since the goalManager class has the primary
        //loop built around the menu.
        GoalManager goalManager = new();
        goalManager.Start();
    }
}