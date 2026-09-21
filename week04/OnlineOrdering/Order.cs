public class Order
{
    private List<Product> _products;
    private Customer _customer;

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
        int shippingCost = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }
        if (_customer.UsaCitizen() == true)
        {
            shippingCost = 5;
        }
        else
        {
            shippingCost = 35;
        }
        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in _products)
        {
            label += $"- {product.GetName()} (ID: {product.GetId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string name = _customer.GetCustomerName();
        string address = _customer.GetCustomerAddress().GetFullAddress();

        return $"Shipping Label:\n{name}\n{address}";
    }
}