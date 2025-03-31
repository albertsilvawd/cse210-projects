class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Oak Street", "Chicago", "IL", "USA");
        Address address2 = new Address("456 Maple Avenue", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("Alice Johnson", address1);
        Customer customer2 = new Customer("Bob Smith", address2);

        // Create products
        Product product1 = new Product("Laptop", 101, 999.99, 1);
        Product product2 = new Product("Mouse", 102, 25.50, 2);
        Product product3 = new Product("Keyboard", 103, 50.00, 1);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);

        // Display packing label, shipping label, and total price for each order
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}\n");
    }
}
