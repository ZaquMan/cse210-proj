public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
    {
        //No base constructor since the base class variables are set specific to the class used.
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown " +
                       "strength and resilience.  This will help you recognize the power you have and " +
                       "how you can use it in other aspects of your life.";

        //Duration does not need to be set since it gets set as part of the welcome message.
        SetupPromptsAndQuestions();
    }

    public ReflectingActivity(string name, string description) : base(name, description)
    {
        //Use default constructor for prompts while still accepting variables for the Activity class.
        SetupPromptsAndQuestions();
    }

    public ReflectingActivity(string name, string description, List<string> prompts, List<string> questions) : base(name, description)
    {
        _prompts = prompts;
        _questions = questions;
    }

    private void SetupPromptsAndQuestions()
    {
        _prompts = ["Think of a time when you stood up for someone else.",
                    "Think of a time when you did something really difficult.",
                    "Think of a time when you helped someone in need.",
                    "Think of a time when you did something truly selfless.",];

        _questions = ["Why was this experience meaningful to you?",
                      "Have you ever done anything like this before?",
                      "How did you get started?",
                      "How did you feel when it was complete?",
                      "What made this time different than other times when you were not as successful?",
                      "What is your favorite thing about this experience?",
                      "What could you learn from this experience that applies to other situations?",
                      "What did you learn about yourself through this experience?",
                      "How can you keep this experience in mind in the future?",];
    }

    public void Run()
    {
        DisplayStartingMessage();
        //Run the activity.
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($" --- {GetRandomPrompt()} ---\n");
        Console.Write("When you have something in mind, press enter to continue.\n");
        //Don't need to set a variable since we're just using this to hold the program until the user presses enter.
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDownSeconds(5);

        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(5);
            Console.Write("\n");
        }
        
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        //Gets a random prompt from the list of prompts.
        //DEVNOTE: A suggest "Above and Beyond" is restricting prompts from repeating until all have been cycled through.
        //This can be easily done by having two lists, and words are moved between them as they are used.
        Random rand = new Random();
        //Write the prompt corresponding to the iterator selected between 0 and the number of possible prompts.
        return _prompts[rand.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        //Gets a random prompt from the list of prompts.
        //DEVNOTE: A suggest "Above and Beyond" is restricting prompts from repeating until all have been cycled through.
        //This can be easily done by having two lists, and words are moved between them as they are used.
        Random rand = new Random();
        //Write the prompt corresponding to the iterator selected between 0 and the number of possible prompts.
        return _questions[rand.Next(_prompts.Count)];
    }

    private void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
    }

    private void DisplayQuestions()
    {
        //TODO: Add duration constraint
        Console.WriteLine();
    }
}