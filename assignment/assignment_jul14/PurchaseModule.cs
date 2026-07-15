using System;
using System.Collections.Generic;
using System.Linq;

public class PurchaseModule : IBill
{
    private List<StationeryItem> items = new List<StationeryItem>();

    public void AddItem(StationeryItem item)
    {
        if (items.Exists(x => x.Id == item.Id))
        {
            throw new DuplicateItemException("Item Id should be unique.");
        }

        if (item.Price <= 0)
        {
            throw new InvalidPriceException("Price must be greater than 0.");
        }

        if (item.Quantity <= 0)
        {
            throw new InvalidQuantityException("Quantity must be greater than 0.");
        }

        items.Add(item);
    }

    public void ShowItems()
    {
        Console.WriteLine("\nItem Details");
        Console.WriteLine("------------");

        foreach (var item in items)
        {
            Console.WriteLine($"ID: {item.Id}");
            Console.WriteLine($"Name: {item.Name}");
            Console.WriteLine($"Category: {item.Category}");
            Console.WriteLine($"Brand: {item.Brand}");
            Console.WriteLine($"Price: {item.Price}");
            Console.WriteLine($"Quantity: {item.Quantity}");
            Console.WriteLine("------------");
        }
    }

    public StationeryItem SearchById(int id)
    {
        var item = items.Find(x => x.Id == id);
        if (item == null)
        {
            throw new ItemNotFoundException("Item not found with the given Id.");
        }

        return item;
    }

    public StationeryItem SearchByName(string name)
    {
        var item = items.Find(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (item == null)
        {
            throw new ItemNotFoundException("Item not found with the given Name.");
        }

        return item;
    }

    public void UpdatePrice(int id, decimal newPrice)
    {
        var item = SearchById(id);
        if (newPrice <= 0)
        {
            throw new InvalidPriceException("Price must be greater than 0.");
        }

        item.Price = newPrice;
    }

    public void UpdateQuantity(int id, int newQuantity)
    {
        var item = SearchById(id);
        if (newQuantity <= 0)
        {
            throw new InvalidQuantityException("Quantity must be greater than 0.");
        }

        item.Quantity = newQuantity;
    }

    public void DeleteItemById(int id)
    {
        var item = SearchById(id);

        Console.WriteLine($"Delete {item.Name}? (Y/N)");
        string confirmation = Console.ReadLine();

        if (confirmation != null && confirmation.Trim().Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            items.Remove(item);
            Console.WriteLine("Item deleted successfully.");
        }
        else
        {
            Console.WriteLine("Deletion cancelled.");
        }
    }

    public void PurchaseItem(int id, int purchaseQuantity)
    {
        var item = SearchById(id);

        if (purchaseQuantity <= 0)
        {
            throw new InvalidQuantityException("Purchase quantity must be greater than 0.");
        }

        if (purchaseQuantity > item.Quantity)
        {
            throw new InsufficientStockException("Insufficient stock available.");
        }

        item.Quantity -= purchaseQuantity;

        Console.WriteLine("Bill");
        Console.WriteLine("----");
        Console.WriteLine($"Item: {item.Name}");
        Console.WriteLine($"Price: {item.Price}");
        Console.WriteLine($"Quantity Purchased: {purchaseQuantity}");
        Console.WriteLine($"Total Amount: {item.Price * purchaseQuantity}");
    }

    public void ShowLowStockItems()
    {
        var lowStockItems = items.Where(x => x.Quantity < 5).ToList();

        if (!lowStockItems.Any())
        {
            Console.WriteLine("No items with quantity less than 5.");
            return;
        }

        Console.WriteLine("\nLow Stock Items");
        Console.WriteLine("---------------");

        foreach (var item in lowStockItems)
        {
            Console.WriteLine($"ID: {item.Id} | Name: {item.Name} | Quantity: {item.Quantity}");
        }
    }

    public void SortItems(int choice)
    {
        switch (choice)
        {
            case 1:
                items.Sort((x, y) => x.Price.CompareTo(y.Price));
                Console.WriteLine("Sorted by Price (List.Sort)");
                break;
            case 2:
                items = items.OrderBy(x => x.Name).ToList();
                Console.WriteLine("Sorted by Name (OrderBy)");
                break;
            case 3:
                items = items.OrderByDescending(x => x.Quantity).ToList();
                Console.WriteLine("Sorted by Quantity Descending (OrderByDescending)");
                break;
            default:
                throw new exception("Invalid sorting option.");
        }

        ShowItems();
    }

    public void GenerateBill()
    {
        Console.WriteLine("Bill generated successfully.");
        ShowItems();
    }
}
