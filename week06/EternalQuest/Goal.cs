public class Goal
{
	private string _shortName;
	private string _description;
	private string _points;

	public Goal(string shortName, string description, string points)
	{
		_shortName = shortName;
		_description = description;
		_points = points;
	}

	public virtual void RecordEvent()
	{
		//Do nothing for now.  Add something later so it can be called properly.
	}

	public virtual bool isComplete()
	{
		return false;
	}

	public virtual string GetDetailsString()
	{
		return "";
	}

	public virtual string GetStringRepresentation()
	{
		return ""; 
	}
}