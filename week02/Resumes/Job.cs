//CSE210 Week 02 Learning Activity

// The job class should keep track of the company, job title, start year and
// end year.

// The job class should be able to display this information in the following
// format.
// Job Title (Company) StartYear-EndYear

using System;

public class Job
{
    //Class variables
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    //Class constructor
    public Job()
    {
        //We're skipping this for now...
    }

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}