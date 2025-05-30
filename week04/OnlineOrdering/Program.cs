using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        Product testProduct = new("Death Star Parts", 435663, 89.33, 10);

        Console.WriteLine(testProduct.Display());
    }
}