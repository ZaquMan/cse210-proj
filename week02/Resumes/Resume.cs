//CSE210 Week 02 Learning Activity

// The Resume class should track a person's name and a list of their jobs.

// The Resume should be able to display the name first, then each of the jobs.

using System;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public Resume()
    {

    }

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}