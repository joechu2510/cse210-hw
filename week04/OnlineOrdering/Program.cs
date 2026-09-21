using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Seattle", "WA", "USA");
        Customer customer1 = new Customer("Joe Chu", address1);
        Order order1 = new Order(customer1);
        
        Product prod1 = new Product("Wireless Mouse", "WM-45", 25.30, 2);
        Product prod2 = new Product("Mechanical Keyboard", "KB-88", 89.99, 1);
        
        order1.AddProduct(prod1);
        order1.AddProduct(prod2);

        Address address2 = new Address("Av. Larco 456", "Miraflores", "Lima", "Peru");
        Customer customer2 = new Customer("Maria Chu", address2);
        Order order2 = new Order(customer2);
        
        Product prod3 = new Product("Gaming Monitor", "GM-27", 299.99, 1);
        Product prod4 = new Product("HDMI Cable", "HD-2", 15.50, 3);
        Product prod5 = new Product("Mousepad", "MP-10", 9.99, 2);
        
        order2.AddProduct(prod3);
        order2.AddProduct(prod4);
        order2.AddProduct(prod5);

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("          PURCHASE ORDER #1            ");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");
        Console.WriteLine();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("          PURCHASE ORDER #2            ");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
        Console.WriteLine("----------------------------------------");
    }
}