using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");

        List<Exercise> _exercises = [];
        //FIXME: Problem with distance getting misreported
        _exercises.Add(new Running("03 Nov 2022", 30, 4.8f));

        foreach (Exercise exercise in _exercises)
        {
            Console.WriteLine(exercise.GetSummary());
        }
    }
}