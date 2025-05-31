class Address
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;

    public Address(string streetAddress, string city, string state, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        if (_country.ToLower() == "usa" || _country.ToLower() == "us"
            || _country.ToLower() == "united states"
            || _country.ToLower() == "united states of america")
        {
            return true;
        } //else
        return false;
    }

    public string Display()
    {
        return $"{_streetAddress}\n" +
               $"{_city}, {_state}\n" +
               $"{_country}";
    }
}