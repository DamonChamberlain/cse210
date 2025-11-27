using System;

public class Program
{
    public static void Main(string[] args)
    {
        // --- Order 1 (USA Customer) ---
        Console.WriteLine("--- Order 1 Details ---");
        
        // 1. Create Address and Customer
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        // 2. Create Products
        Product product1a = new Product("Laptop", "P-1001", 1200.50m, 1);
        Product product1b = new Product("Mouse", "P-1002", 25.99m, 2);

        // 3. Create Order and add products
        Order order1 = new Order(customer1);
        order1.AddProduct(product1a);
        order1.AddProduct(product1b);

        // 4. Display results for Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():F2}\n");


        // --- Order 2 (International Customer) ---
        Console.WriteLine("--- Order 2 Details ---");

        // 1. Create Address and Customer
        Address address2 = new Address("456 Maple Leaf Dr", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        // 2. Create Products
        Product product2a = new Product("Keyboard", "P-2005", 75.00m, 1);
        Product product2b = new Product("Monitor", "P-2006", 250.00m, 2);
        Product product2c = new Product("Desk Mat", "P-2007", 15.50m, 1);

        // 3. Create Order and add products
        Order order2 = new Order(customer2);
        order2.AddProduct(product2a);
        order2.AddProduct(product2b);
        order2.AddProduct(product2c);

        // 4. Display results for Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():F2}");
    }
}