public abstract class Goal
{
	protected string _shortName;
	protected string _description;
	protected int _points;

	public Goal(string shortName, string description, int points)
	{
		_shortName = shortName;
		_description = description;
		_points = points;
	}

	public string GetName()
	{
		return _shortName;
	}

	public abstract int RecordEvent();

	public abstract bool isComplete();

	public virtual string GetDetailsString()
	{
		return $"{_shortName} ({_description})";
	}

	public abstract string GetStringRepresentation();
}