public class BreathingActivity : Activity
{
    //Variables
    //Constructors
    public BreathingActivity() : base()
    {
        //No variables.  Everything gets handled by the base constructor
    }

    public BreathingActivity(string name, string description, int duration) : base(name, description, duration)
    {
        //No variables.  Everything gets handled by the base constructor
    }

    public void Run()
    {
        DisplayStartingMessage();        
        //Run the activity.
        DisplayEndingMessage();
    }
}