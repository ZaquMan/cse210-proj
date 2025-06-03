using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Homework Project.");

        WritingAssignment assignment1 = new();
        Console.WriteLine(assignment1.GetWritingInformation());

        WritingAssignment assignment2 = new("Jimanthy Bootlicker", "Rednekin", "Hows Ter Blend In Wit Udder Folk");
        Console.WriteLine(assignment2.GetWritingInformation());
    }
}