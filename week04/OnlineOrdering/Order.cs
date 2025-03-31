using System;
using System.Collections.Generic;

public class Order
{
    // Private attributes
    private List<Product> _products;
    private Customer _customer;
    private const double _shippingCostUSA = 5.0;
    private const double _shippingCostInternational = 35.0;

    // Constructor to initialize the order with a customer
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Method to calculate the total price of the order
    public double GetTotalPrice()
    {
        double totalProductCost = 0;
        foreach (Product product in _products)
        {
            totalProductCost += product.GetTotalCost();
        }

        // Calculate shipping cost based on the customer's location
        double shippingCost = _customer.IsInUSA() ? _shippingCostUSA : _shippingCostInternational;
        return totalProductCost + shippingCost;
    }

    // Method to generate the packing label
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in _products)
        {
            label += $"{product.Name} (ID: {product.Id})\n";
        }
        return label;
    }

    // Method to generate the shipping label
    public string GetShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += $"{_customer.GetName()}\n{_customer.GetAddress()}\n";
        return label;
    }
}
