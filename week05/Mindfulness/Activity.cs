public class Activity
{
    //Variables
    protected string _name;
    protected string _description;
    protected int _duration;

    //Constructors
    public Activity()
    {
        _name = "Unknown";
        _description = "An unknown activity";
        _duration = 0;
    }

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    //Methods
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"This is the ${_name} Activity.\n" +
                          _description);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"You have completed the ${_name} Activity, spending ${_duration} seconds being mindful.");
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("\\|/-");
        }
    }

    public void ShowCountDownSeconds(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
        }
    }
}