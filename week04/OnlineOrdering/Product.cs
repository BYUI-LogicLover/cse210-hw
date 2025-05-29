using System;

public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string Name { get { return _name; } }
    public string ProductId { get { return _productId; } }
    public double Price { get { return _price; } }
    public int Quantity { get { return _quantity; } }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }
}
