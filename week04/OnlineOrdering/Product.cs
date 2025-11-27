using System;

// Defines the Product class.
public class Product
{
    // Private member variables.
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    // Constructor to initialize the product.
    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Public method to calculate the total cost for this product line item.
    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }

    // Getter for the product name (needed by Order for packing label).
    public string GetName()
    {
        return _name;
    }

    // Getter for the product ID (needed by Order for packing label).
    public string GetProductId()
    {
        return _productId;
    }
}