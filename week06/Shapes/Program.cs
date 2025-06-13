using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        Shape myShape = new Square("Yellow", 1.4f);

        
        myShape.GetColor();
    }
}