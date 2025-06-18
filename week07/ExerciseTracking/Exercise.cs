public abstract class Exercise
{
	protected string _date;
	protected int _minutes;

	public Exercise(string date, int minutes)
	{
		_date = date;
		_minutes = minutes;
	}

	public abstract float GetDistance();
	public abstract float GetSpeed();
	public abstract float GetPace();
	public abstract string GetSummary();
}