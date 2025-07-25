class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer, List<Product> products = null)
    {
        _customer = customer;
        _products = products ?? new();
    }

    public void AddProduct(Product product) => _products.Add(product);

    public double CalcTotalCost()
    {
        double total = _products.Sum(product => product.GetTotalCost);
        double shipping = _customer.IsInUSA ? 5 : 35;

        return total + shipping;
    }

    public string GetPackingLabel => string.Join("\n\t", _products.Select(product => product.GetPackingLabel));

    public string GetShippingLabel => $"{_customer.GetName}\n\t{_customer.GetAddress.GetFullAddress.Replace("\n", "\n\t")}";

    public void DisplayAll() => Console.WriteLine($"Packing Label:\n\t{this.GetPackingLabel}\n\nShipping Label:\n\t{this.GetShippingLabel}\n\nTotal: ${this.CalcTotalCost()}\n");
}