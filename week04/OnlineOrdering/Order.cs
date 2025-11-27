using System;
using System.Collections.Generic;
using System.Text; // Required for StringBuilder

// Defines the Order class.
public class Order
{
    // Private member variables.
    private List<Product> _products;
    private Customer _customer;

    // Constructor. An order is created for a specific customer.
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>(); // Initialize the product list.
    }

    // Public method to add a product to the order's private list.
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Public method to calculate the total cost of the order.
    public decimal CalculateTotalCost()
    {
        decimal total = 0;

        // 1. Sum the cost of all products
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        // 2. Add the one-time shipping fee
        // It delegates the "IsInUSA" check to the customer.
        if (_customer.LivesInUSA())
        {
            total += 5; // $5 USA shipping
        }
        else
        {
            total += 35; // $35 International shipping
        }

        return total;
    }

    // Public method to generate the packing label.
    public string GetPackingLabel()
    {
        // Use StringBuilder for efficient string building in a loop.
        StringBuilder label = new StringBuilder();
        label.AppendLine("--- Packing Label ---");
        foreach (Product product in _products)
        {
            // Gets name and ID from each product.
            label.AppendLine($"  Product: {product.GetName()} (ID: {product.GetProductId()})");
        }
        return label.ToString();
    }

    // Public method to generate the shipping label.
    public string GetShippingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("--- Shipping Label ---");
        // Gets name and full address string from the customer and its address.
        label.AppendLine($"  {_customer.GetName()}");
        label.AppendLine($"  {_customer.GetAddress().GetFullAddressString()}");
        return label.ToString();
    }
}