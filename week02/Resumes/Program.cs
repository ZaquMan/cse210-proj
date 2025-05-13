using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Micro Center";
        job1._jobTitle = "Cash Office Associate";
        job1._startYear = 2024;
        job1._endYear = 2025;

        job1.Display();

        Job job2 = new Job();
        job2._company = "ServerPlus";
        job2._jobTitle = "System Administrator";
        job2._startYear = 2019;
        job2._endYear = 2024;

        Resume resume = new Resume();
        resume._name = "Zach Barnett";
        resume._jobs.Add(job2);
        resume._jobs.Add(job1);

        resume.Display();
    }
}