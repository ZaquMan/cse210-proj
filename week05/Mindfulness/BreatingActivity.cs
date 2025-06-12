public class BreathingActivity : Activity
{
    //Variables
    //Constructors
    public BreathingActivity()
    {
        //No base constructor since the base class variables are set specific to the class used.
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing " +
                       "in and out slowly.  Clear your mind and focus on your breathing.";

        //Duration does not need to be set since it gets set as part of the welcome message.
    }

    public BreathingActivity(string name, string description) : base(name, description)
    {
        //No variables.  Everything gets handled by the base constructor
    }

    public void Run()
    {
        DisplayStartingMessage();

        //Run the activity.
        Console.Write("Breathe in  ");
        ShowCountDownSeconds(2);
        Console.Write("Now breathe out  ");
        ShowCountDownSeconds(3);
        Console.WriteLine();

        for (int i = _duration; i > 0; i -= 10)
        {
            Console.Write("Breathe in  ");
        ShowCountDownSeconds(4);
        Console.Write("Now breathe out  ");
        ShowCountDownSeconds(6);
        Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}