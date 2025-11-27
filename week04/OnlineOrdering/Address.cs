using System;

// Defines the Address class.
public class Address
{
    // All member variables are private to ensure encapsulation.
    private string _streetAddress;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    // The constructor is the only way to set the initial state.
    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    // Public method to determine if the address is in the USA.
    public bool IsInUSA()
    {
        // Simple case-insensitive check.
        return _country.Equals("USA", StringComparison.OrdinalIgnoreCase) ||
               _country.Equals("United States", StringComparison.OrdinalIgnoreCase);
    }

    // Public method to return the fully formatted address string.
    public string GetFullAddressString()
    {
        // Formats the address with newlines for labels.
        return $"{_streetAddress}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}