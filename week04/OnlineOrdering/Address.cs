public class Address
{
    // Private attributes
    private string street;
    private string city;
    private string stateOrProvince;
    private string country;

    // Constructor to initialize the address
    public Address(string street, string city, string stateOrProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return country == "USA";
    }

    // Method to return the full address as a string
    public string GetFullAddress()
    {
        return $"{street}\n{city}, {stateOrProvince}\n{country}";
    }

    // Getters for private attributes
    public string Street => street;
    public string City => city;
    public string StateOrProvince => stateOrProvince;
    public string Country => country;
}
