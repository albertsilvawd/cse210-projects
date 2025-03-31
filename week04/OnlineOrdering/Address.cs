public class Address
{
    // Private attributes
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    // Constructor to initialize the address
    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return _country == "USA";
    }

    // Method to return the full address as a string
    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
    }

    // Getters for private attributes
    public string Street => _street;
    public string City => _city;
    public string StateOrProvince => _stateOrProvince;
    public string Country => _country;
}
