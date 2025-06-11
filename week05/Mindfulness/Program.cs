using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
        Activity testAct = new();
        testAct.ShowSpinner(5);
        testAct.ShowCountDownSeconds(5);
    }
}