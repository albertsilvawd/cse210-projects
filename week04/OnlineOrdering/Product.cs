public class Product
{
    // Private attributes
    private string _name;
    private int _id;
    private double _price;
    private int _quantity;

    // Constructor to initialize the product
    public Product(string name, int id, double price, int quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
    }

    // Method to calculate the total cost of the product
    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    // Getters for private attributes
    public string Name => _name;
    public int Id => _id;
    public double Price => _price;
    public int Quantity => _quantity;
}
