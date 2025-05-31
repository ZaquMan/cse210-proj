class Product
{
    private string _name;
    private int _productId;
    private double _price;
    private int _quantity;

    public Product(string name, int productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double CalculateCost()
    {
        return _price * _quantity;
    }

    public string DisplayWithPrice()
    {
        return $"{_productId} {_name,-15} {_quantity,3} " +
               $"@{_price,6:C} ${CalculateCost(),8:C}";
        //              var,pad,round
    }

    public string DisplayShort()
    {
        return $"{_productId} {_name,-15} (x{_quantity})";
    }
}