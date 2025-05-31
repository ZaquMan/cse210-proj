using System;

class Program
{
    static void Main(string[] args)
    {
        //I have two constructor methods.  The first requires that you create
        //all the classes in the main program.
        Order order1;
        Product product101;
        Product product102;
        Product product103;
        Customer customer1;
        Address address1;

        address1 = new("123 Baker St", "Anyville", "Utah", "United States");
        customer1 = new("Bobby King", address1);
        product101 = new("Baked Beans", 203948, 4.99, 5);
        product102 = new("Corn Bread Mix", 934043, 3.25, 4);
        product103 = new("Hot Dog Buns (8pk)", 322432, 7.00, 2);
        order1 = new([product101, product102, product103], customer1);


        //The second uses a cascading strategy.  You pass all the variables
        //that the next classes will need and the class constructors get called
        //as part of the earlier class's constructor.

        Order order2 = new("Kevin Spacey", "1479 Parliament Way", "Mexicali", "Baja California", "MX");
        order2.AddProduct(new Product("Sofa - Red Leather", 3044, 1320.00, 1));
        order2.AddProduct(new Product("Coffee Table - Rose", 2011, 394.99, 2));

        //Start with a clean screen
        Console.Clear();
        Console.WriteLine("Order 1\n\n");
        Console.WriteLine(order1.GetPackingLabel() + "\n");
        Console.WriteLine(order1.GetShippingLabel() + "\n");
        Console.WriteLine($"Total Cost: {order1.CalculateOrderCost():C}");

        Console.WriteLine("\n\nOrder 2:\n\n");
        Console.WriteLine(order2.GetPackingLabel() + "\n");
        Console.WriteLine(order2.GetShippingLabel() + "\n");
        Console.WriteLine($"Total Cost: {order2.CalculateOrderCost():C}");
    }
}