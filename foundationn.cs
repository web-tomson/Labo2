using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create Customers
        Customer customer1 = new Customer("John Doe", new Address("123 Elm St", "Springfield", "IL", "USA"));
        Customer customer2 = new Customer("Jane Smith", new Address("456 Maple Ave", "Toronto", "ON", "Canada"));
        
        // Create Products
        Product product1 = new Product("Laptop", "L123", 800.00, 1);
        Product product2 = new Product("Mouse", "M456", 25.00, 2);
        Product product3 = new Product("Keyboard", "K789", 45.00, 1);
        
        // Create Orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display Order Information
        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\nOrder 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nOrder 1 Total Cost: ${order1.GetTotalCost():F2}\n");

        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("\nOrder 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nOrder 2 Total Cost: ${order2.GetTotalCost():F2}");
    }
}

class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetLabel()
    {
        return $"{_name} (ID: {_productId})";
    }
}

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetName()
    {
        return _name;
    }

    public string GetAddress()
    {
        return _address.GetFullAddress();
    }
}

class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

class Order
{
    private List<Product> _products;
    private Customer _customer;
    private const double US_SHIPPING_COST = 5.0;
    private const double INTERNATIONAL_SHIPPING_COST = 35.0;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }
        total += _customer.IsInUSA() ? US_SHIPPING_COST : INTERNATIONAL_SHIPPING_COST;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (var product in _products)
        {
            label += product.GetLabel() + "\n";
        }
        return label.Trim();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress()}";
    }
}
