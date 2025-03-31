public class Customer
{
    // Private attributes
    private string name;
    private Address address;

    // Constructor to initialize the customer with a name and address
    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    // Method to check if the customer lives in the USA
    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    // Method to return the customer's name
    public string GetName() => name;

    // Method to return the customer's full address
    public string GetAddress() => address.GetFullAddress();
}
