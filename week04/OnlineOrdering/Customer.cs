public class Customer
{
    private string _customerName;
    private Address _customerAddress;

    public Customer(string name, Address address)
    {
        _customerName = name;
        _customerAddress = address;
    }

    public bool UsaCitizen()
    {
        return _customerAddress.LiveInUsa();
    }

    public string GetCustomerName()
    {
        return _customerName;
    }

    public Address GetCustomerAddress()
    {
        return _customerAddress;
    }
}