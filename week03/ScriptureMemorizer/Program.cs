using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        Reference ref1 = new Reference("John", 3, 16);
        Console.WriteLine(ref1.GetDisplayText());

        Reference ref2 = new Reference("Mosiah", 7, 4, 7);
        Console.WriteLine(ref2.GetDisplayText());
    }
}