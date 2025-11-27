using System;

// Defines the Customer class.
public class Customer
{
    // Private member variables.
    private string _name;
    private Address _address; // Contains an Address object.

    // Constructor to initialize the customer.
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // This method delegates the check to the Address class.
    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }

    // Getter for the customer's name (needed by Order for shipping label).
    public string GetName()
    {
        return _name;
    }

    // Getter for the Address object (needed by Order for shipping label).
    public Address GetAddress()
    {
        return _address;
    }
}