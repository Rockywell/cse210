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

    public string GetName => _name;
    public int GetProductId => _productId;
    public double GetTotalCost => _price * _quantity;
    public string GetPackingLabel => $"{_name} - (ID: {_productId})";
}