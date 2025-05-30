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

    public string Display()
    {
        return $"{_productId} {_name,-15} {_quantity,3} " +
               $"@{_price,6:0.00} ${CalculateCost(),8:0.00}";
    //              var,pad,round
    }
}