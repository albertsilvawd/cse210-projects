public class Product
{
    // Private attributes
    private string name;
    private int id;
    private double price;
    private int quantity;

    // Constructor to initialize the product
    public Product(string name, int id, double price, int quantity)
    {
        this.name = name;
        this.id = id;
        this.price = price;
        this.quantity = quantity;
    }

    // Method to calculate the total cost of the product
    public double GetTotalCost()
    {
        return price * quantity;
    }

    // Getters for private attributes
    public string Name => name;
    public int Id => id;
    public double Price => price;
    public int Quantity => quantity;
}
