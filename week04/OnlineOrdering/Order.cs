using System.Net.Http.Headers;

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }

    public double CalculateOrderCost()
    {
        double cost = 0.0f;

        foreach (Product product in _products)
        {
            cost += product.CalculateCost();
        }

        return cost;
    }

    public string GetPackingLabel()
    {
        return "";
    }

    public string GetShippingLabel()
    {
        return "";
    }
}