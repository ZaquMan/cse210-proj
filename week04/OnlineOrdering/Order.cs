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

    public Order(string name, string streetAddress, string city, string state, string country)
    {
        _products = [];
        _customer = new(name, streetAddress, city, state, country);
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateOrderCost()
    {
        return _products.Aggregate(0.0, (sum , product) => sum + product.CalculateCost()) +
               (_customer.IsInUSA() ? 5 : 35);
    }

    public string GetPackingLabel()
    {

        return _products.Aggregate("Packing Label:\n\n", (returnString, product) => returnString + product.DisplayShort() + "\n").Trim();
        // string returnText = "Packing Label:\n\n";
// 
// 
        // foreach (Product product in _products)
        // {
            // returnText += $"{product.DisplayShort()}\n";
        // }
// 
        // return returnText;
        
    }

    public string GetShippingLabel()
    {
        return  $"Shipping Label:\n\n{_customer.Display()}"; 
    }
}