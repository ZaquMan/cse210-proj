public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity() : base()
    {
        _count = 0;
        _prompts = [];
    }

    public ListingActivity(string name, string description, int duration, int count, List<string> prompts) : base(name, description, duration)
    {
        _count = count;
        _prompts = prompts;
    }

    public void Run()
    {
        DisplayStartingMessage();
        //Run the activity.
        DisplayEndingMessage();
    }

    private void GetRandomPrompt()
    {
        //Gets a random prompt from the list of prompts.
        //DEVNOTE: A suggest "Above and Beyond" is restricting prompts from repeating until all have been cycled through.
        //This can be easily done by having two lists, and words are moved between them as they are used.
        Random rand = new Random();
        //Write the prompt corresponding to the iterator selected between 0 and the number of possible prompts.
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
    }

    private List<string> GetListFromUser()
    {
        //TODO: This needs to accept input until the base _duration expires.
        return [];
    }
}