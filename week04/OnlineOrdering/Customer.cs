public class Customer
{
    // Private attributes
    private string _name;
    private Address _address;

    // Constructor to initialize the customer with a name and address
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Method to check if the customer lives in the USA
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    // Method to return the customer's name
    public string GetName() => _name;

    // Method to return the customer's full address
    public string GetAddress() => _address.GetFullAddress();
}
