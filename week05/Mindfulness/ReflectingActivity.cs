public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity() : base()
    {
        _prompts = [];
        _questions = [];
    }

    public ReflectingActivity(string name, string description, int duration, List<string> prompts, List<string> questions) : base(name, description, duration)
    {
        _prompts = prompts;
        _questions = questions;
    }

    public void Run()
    {
        DisplayStartingMessage();
        //Run the activity.
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