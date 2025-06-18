public class Running : Exercise
{
	private float _distance;

	public Running(string date, int minutes, float distance) : base(date, minutes)
	{
		_distance = distance;
	}

	public override float GetDistance()
	{
		return _distance;
	}

	public override float GetSpeed()
	{
		return _distance / _minutes * 60;
	}

	public override float GetPace()
	{
		return _minutes / _distance;
	}

	public override string GetSummary()
	{
		return $"{_date} Running ({_minutes} min): Distance: {GetDistance():.1f} km, Speed: {GetSpeed():.1f} kph, Pace: {GetPace():.2f} min per km";
	}
}