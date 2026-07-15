using System;
using System.Collections.Generic;

public class StationeryItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public StationeryItem(int id, string name, string category, string brand, decimal price, int quantity)
    {
        Id = id;
        Name = name;
        Category = category;
        Brand = brand;
        Price = price;
        Quantity = quantity;
    }
}
