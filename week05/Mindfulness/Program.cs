using System;
using System.Collections;
using System.Runtime.CompilerServices;

//Above and Beyond - Input parsing.  While it's important to not belittle someone's attempts to be mindful,
//there are prompts that need a valid input to prevent the program from breaking.  Specifically the menu
//selection and the duration entry.  In these cases, validation is used to ensure a valid entry is provided.
//Above and Beyond - Avoid repeats in Reflection Activity.  When the questions are being shown to the user
//about their prompt, no question gets repeated until all questions have been used.  This resets each time
//the user starts a new reflection activity.

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathingActivity = new BreathingActivity();
        ListingActivity listingActivity = new ListingActivity();
        ReflectingActivity reflectingActivity = new ReflectingActivity();

        string userInput = "";

        while (userInput != "4")
        {
            //Draw menu
            Console.Clear();
            Console.WriteLine("Menu Options:\n" +
                          "  1. Start breathing activity\n" +
                          "  2. Start reflecting activity\n" +
                          "  3. Start listing activity\n" +
                          "  4. Quit");
            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    breathingActivity.Run();
                    break;
                case "2":
                    reflectingActivity.Run();
                    break;
                case "3":
                    listingActivity.Run();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine($"\"{userInput}\" is not a valid menu option.  Please try again.");
                    break;
            }
        }
    }
}