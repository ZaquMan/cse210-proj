public class EternalGoal : Goal
{
	public EternalGoal(string shortName, string description, int points) : base(shortName, description, points)
	{
		//Nothing needs to be done here.  Everything is handled by the base class constructor
	}

	public override int RecordEvent()
	{
		Console.WriteLine($"Congratulations! You have earned {_points}!");
		return _points;
	}

	public override bool isComplete()
	{
		//While this is the same behavior as the base class RIGHT NOW, it may not always be.
		//Better to not just call the base class and instead have a defined behavior.
		return false;
	}

	public override string GetStringRepresentation()
	{
		return $"EternalGoal‚{_shortName}‚{_description}‚{_points}";
	}

}