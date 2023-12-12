using System;

class Address
{
    public string StreetAddress { get; private set; }
    public string City { get; private set; }
    public string StateOrProvince { get; private set; }
    public string Country { get; private set; }

    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        StateOrProvince = stateOrProvince;
        Country = country;
    }

    public bool IsInUSA() => Country.ToLower() == "usa";

    public override string ToString()
    {
        return $"{StreetAddress}\n{City}, {StateOrProvince}\n{Country}";
    }
}
class Customer
{
    public string Name { get; private set; }
    public Address CustomerAddress { get; private set; }

    public Customer(string name, Address address)
    {
        Name = name;
        CustomerAddress = address;
    }

    public bool IsInUSA() => CustomerAddress.IsInUSA();
}
class Product
{
    public string Name { get; private set; }
    public int ProductId { get; private set; }
    public decimal PricePerUnit { get; private set; }
    public int Quantity { get; private set; }

    public Product(string name, int productId, decimal pricePerUnit, int quantity)
    {
        Name = name;
        ProductId = productId;
        PricePerUnit = pricePerUnit;
        Quantity = quantity;
    }

    public decimal TotalCost() => PricePerUnit * Quantity;
}
class Order
{
    public List<Product> Products { get; private set; }
    public Customer OrderCustomer { get; private set; }

    public Order(Customer customer)
    {
        OrderCustomer = customer;
        Products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public decimal TotalPrice()
    {
        decimal total = 0;
        foreach (var product in Products)
        {
            total += product.TotalCost();
        }
        return total + (OrderCustomer.IsInUSA() ? 5 : 35);
    }

    public string PackingLabel()
    {
        string label = "";
        foreach (var product in Products)
        {
            label += $"Product Name: {product.Name}, Product ID: {product.ProductId}\n";
        }
        return label;
    }

    public string ShippingLabel()
    {
        return $"{OrderCustomer.Name}\n{OrderCustomer.CustomerAddress}";
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Create customers
        Customer customer1 = new Customer("John Doe", new Address("123 Main St", "Springfield", "IL", "USA"));
        Customer customer2 = new Customer("Jane Smith", new Address("456 Elm St", "Toronto", "ON", "Canada"));

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", 1001, 999.99m, 1));
        order1.AddProduct(new Product("Mouse", 1002, 19.99m, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Smartphone", 2001, 599.99m, 1));
        order2.AddProduct(new Product("Charger", 2002, 34.99m, 1));

        // Display order details
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.PackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.ShippingLabel());
        Console.WriteLine($"Total Price: {order.TotalPrice()}\n");
    }
}
