public class ChecklistGoal : Goal
{
	private int _amountCompleted;
	private int _target;
	private int _bonus;

	public ChecklistGoal(string shortName, string description, int points, int target, int bonus) : base(shortName, description, points)
	{
		_amountCompleted = 0;
		_target = target;
		_bonus = bonus;
	}

	public ChecklistGoal(string shortName, string description, int points, int target, int bonus, int amountCompleted) : base(shortName, description, points)
	{
		_amountCompleted = amountCompleted;
		_target = target;
		_bonus = bonus;
	}

	public override int RecordEvent()
	{
		//Check if the goal has been completed yet
		if (_amountCompleted < _target)
		{
			_amountCompleted++;
			//Check if this event completes the goal
			if (_amountCompleted < _target)
			{
				Console.WriteLine($"Congratulations! You have earned {_points}! " +
				$"Just {_target - _amountCompleted} more completion{(_target - _amountCompleted == 1 ? "" : "s")} to receive a bonus!");
				return _points;
			}
			else
			{
				Console.WriteLine($"Congratulations! You have earned {_points} and {_bonus} points for completing you goal " +
				$"{_amountCompleted} times.");
				return _points + _bonus;
			}
		}
		else
		{
			Console.WriteLine($"You've already completed this goal {_amountCompleted} times.");
			return 0;
		}
	}

	public override bool isComplete()
	{
		return _amountCompleted < _target ? false : true;
	}

	public override string GetDetailsString()
	{
		return $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}";
	}

	public override string GetStringRepresentation()
	{
		return $"ChecklistGoal‚{_shortName}‚{_description}‚{_points}‚{_target}‚{_bonus}‚{_amountCompleted}";
	}
	
}