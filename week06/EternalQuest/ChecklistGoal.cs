public class ChecklistGoal : Goal
{
	private int _amountCompleted;
	private int _target;
	private int _bonus;

	public ChecklistGoal(string shortName, string description, string points, int amountCompleted, int target, int bonus) : base(shortName, description, points)
	{
		_amountCompleted = amountCompleted;
		_target = target;
		_bonus = bonus;
	}

	public override void RecordEvent()
	{

	}

	public override bool isComplete()
	{
		return _amountCompleted < _target ? false : true;
	}

	public override string GetDetailsString()
	{
		return "";
	}

	public override string GetStringRepresentation()
	{
		return "";
	}
	
}