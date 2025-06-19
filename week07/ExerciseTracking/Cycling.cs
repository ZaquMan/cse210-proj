public class Cycling : Exercise
{
	private float _speed;

	public Cycling(string date, int minutes, float speed) : base(date, minutes)
	{
		_speed = speed;
	}

	public override float GetDistance()
	{
		return _speed / 60 * _minutes;
	}

	public override float GetSpeed()
	{
		return _speed;
	}

	public override float GetPace()
	{
		return 60 / _speed;
	}

	public override string GetSummary()
	{
		return $"{_date} Cycling ({_minutes} min): Distance: {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2}2 min per km";
	}
}