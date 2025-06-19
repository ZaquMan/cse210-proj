using System;

class Program
{
    static void Main(string[] args)
    {
        List<Exercise> _exercises = [];
        _exercises.Add(new Running("03 Nov 2022", 30, 4.8f));
        _exercises.Add(new Cycling("03 Nov 2022", 20, 9.6f));
        _exercises.Add(new Swimming("05 Nov 2022", 45, 15f));

        foreach (Exercise exercise in _exercises)
        {
            Console.WriteLine(exercise.GetSummary());
        }
    }
}