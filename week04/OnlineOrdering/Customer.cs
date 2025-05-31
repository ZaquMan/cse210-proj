class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public Customer(string name, string streetAddress, string city, string state, string country)
    {
        _name = name;
        _address = new(streetAddress, city, state, country);
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    public string Display()
    {
        return $"{_name}\n" +
               $"{_address.Display()}";
    }
}