using System.Runtime.InteropServices;

public class SimpleGoal : Goal
{
	private bool _isComplete;

	public SimpleGoal(string shortName, string description, int points) : base(shortName, description, points)
	{
		_isComplete = false;
	}

	public SimpleGoal(string shortName, string description, int points, bool isComplete) : base(shortName, description, points)
	{
		_isComplete = isComplete;
	}

	public override int RecordEvent()
	{
		if (_isComplete)
		{
			Console.WriteLine("This goal has already been completed.");
			return 0;
		}
		else
		{
			_isComplete = true;
			Console.WriteLine($"Congratulations! You have earned {_points}!");
			return _points;
		}
	}

	public override bool isComplete()
	{
		return _isComplete;
	}

	public override string GetStringRepresentation()
	{
		//That isn't a comma.  It's an inverted quote mark.  However since it looks like a comma,
		//I can use it as a control character that isn't going to by typed, but is still human-readable.
		return $"SimpleGoal‚{_shortName}‚{_description}‚{_points}‚{_isComplete}";
	}
}