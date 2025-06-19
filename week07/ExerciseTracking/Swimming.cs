public class Swimming : Exercise
{
	private float _laps;

	public Swimming(string date, int minutes, float laps) : base(date, minutes)
	{
		_laps = laps;
	}

	public override float GetDistance()
	{
		return _laps * 50 / 1000;
	}

	public override float GetSpeed()
	{
		return GetDistance() / _minutes * 60;
	}

	public override float GetPace()
	{
		return _minutes / GetDistance();
	}

	public override string GetSummary()
	{
		return $"{_date} Swimming ({_minutes} min): Distance: {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2}2 min per km";
	}
}