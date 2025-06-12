public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        //No base constructor since the base class variables are set specific to the class used.
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by " +
                       "having you list as many things as you can in a certain area.";

        //Duration does not need to be set since it gets set as part of the welcome message.
        _count = 0;
        SetupPrompts();
    }

    public ListingActivity(string name, string description) : base(name, description)
    {
        //Use default constructor for prompts while still accepting variables for the Activity class.
        _count = 0;
        SetupPrompts();
    }

    public ListingActivity(string name, string description, int count, List<string> prompts) : base(name, description)
    {
        _count = count;
        _prompts = prompts;
    }

    private void SetupPrompts()
    {
        _prompts = ["Who are people that you appreciate?",
                    "What are personal strengths of yours?",
                    "Who are people that you have helped this week?",
                    "When have you felt the Holy Ghost this month?",
                    "Who are some of your personal heroes?",];
    }

    public void Run()
    {
        DisplayStartingMessage();
        //Run the activity.
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.Write(" ---");
        GetRandomPrompt();
        Console.WriteLine(" ---");

        Console.Write("You may begin in: ");
        ShowCountDownSeconds(5);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        _count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string userInput = Console.ReadLine();
            if (userInput.Trim() != "")
            {
                _count++;
            }
        }

        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
    }

    private void GetRandomPrompt()
    {
        //Gets a random prompt from the list of prompts.
        //DEVNOTE: A suggest "Above and Beyond" is restricting prompts from repeating until all have been cycled through.
        //This can be easily done by having two lists, and words are moved between them as they are used.
        Random rand = new Random();
        //Write the prompt corresponding to the iterator selected between 0 and the number of possible prompts.
        Console.Write(_prompts[rand.Next(_prompts.Count)]);
    }

    private List<string> GetListFromUser()
    {
        //TODO: This needs to accept input until the base _duration expires.
        return [];
    }
}