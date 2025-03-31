using System;
using System.Collections.Generic;

public class Order
{
    // Private attributes
    private List<Product> products;
    private Customer customer;
    private const double shippingCostUSA = 5.0;
    private const double shippingCostInternational = 35.0;

    // Constructor to initialize the order with a customer
    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Method to calculate the total price of the order
    public double GetTotalPrice()
    {
        double totalProductCost = 0;
        foreach (Product product in products)
        {
            totalProductCost += product.GetTotalCost();
        }

        // Calculate shipping cost based on the customer's location
        double shippingCost = customer.IsInUSA() ? shippingCostUSA : shippingCostInternational;
        return totalProductCost + shippingCost;
    }

    // Method to generate the packing label
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in products)
        {
            label += $"{product.Name} (ID: {product.Id})\n";
        }
        return label;
    }

    // Method to generate the shipping label
    public string GetShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += $"{customer.GetName()}\n{customer.GetAddress()}\n";
        return label;
    }
}
