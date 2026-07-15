using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerOrderApp;

class Program
{
    static void Main()
    {
        Console.WriteLine("===== Customer Registration =====");
        Console.Write("Enter Customer ID: ");
        int customerId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Enter Email: ");
        string email = Console.ReadLine() ?? "";
        Console.Write("Enter Password: ");
        string password = Console.ReadLine() ?? "";

        Customer customer = new Customer
        {
            CustomerId = customerId,
            Name = name,
            Email = email,
            Password = password
        };

        Console.WriteLine("\nRegistration Successful\n");

        bool loggedIn = false;
        for (int attempt = 1; attempt <= 3; attempt++)
        {
            Console.WriteLine($"===== Login (Attempt {attempt} of 3) =====");
            Console.Write("Enter Email: ");
            string loginEmail = Console.ReadLine() ?? "";
            Console.Write("Enter Password: ");
            string loginPassword = Console.ReadLine() ?? "";

            if (loginEmail == customer.Email && loginPassword == customer.Password)
            {
                Console.WriteLine($"\nWelcome {customer.Name}\n");
                loggedIn = true;
                break;
            }

            Console.WriteLine("Invalid credentials.\n");
        }

        if (!loggedIn)
        {
            Console.WriteLine("Account Locked");
            return;
        }

        Console.Write("How many products do you want to add? ");
        int productCount = Convert.ToInt32(Console.ReadLine());

        List<Product> products = new List<Product>();
        for (int i = 1; i <= productCount; i++)
        {
            Console.WriteLine($"\n-- Product {i} --");
            Console.Write("Enter Product ID: ");
            int pid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Product Name: ");
            string pname = Console.ReadLine() ?? "";
            Console.Write("Enter Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Stock: ");
            int stock = Convert.ToInt32(Console.ReadLine());

            products.Add(new Product
            {
                ProductId = pid,
                ProductName = pname,
                Price = price,
                Stock = stock
            });
        }

        PrintProducts(products);

        Console.Write("\nEnter product name to search: ");
        string searchName = Console.ReadLine() ?? "";
        Product? found = products.FirstOrDefault(
            p => p.ProductName.Equals(searchName, StringComparison.OrdinalIgnoreCase));

        if (found != null)
        {
            Console.WriteLine("\nProduct Found");
            Console.WriteLine($"Product Id : {found.ProductId}");
            Console.WriteLine($"Product Name : {found.ProductName}");
            Console.WriteLine($"Price : {found.Price}");
            Console.WriteLine($"Stock : {found.Stock}");
        }
        else
        {
            Console.WriteLine("\nProduct Not Found");
        }

        List<CartItem> cart = new List<CartItem>();
        while (true)
        {
            PrintProducts(products);

            Console.Write("\nEnter Product ID: ");
            int cartPid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            int qty = Convert.ToInt32(Console.ReadLine());

            Product? selected = products.FirstOrDefault(p => p.ProductId == cartPid);
            if (selected == null)
            {
                Console.WriteLine("Product not found.");
            }
            else if (selected.Stock < qty)
            {
                Console.WriteLine("Insufficient stock available.");
            }
            else
            {
                selected.Stock -= qty;
                CartItem? existing = cart.FirstOrDefault(c => c.Product.ProductId == selected.ProductId);
                if (existing != null)
                    existing.Quantity += qty;
                else
                    cart.Add(new CartItem { Product = selected, Quantity = qty });

                Console.WriteLine("Added to cart.");
            }

            Console.WriteLine("\nDo you want to add another product?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Console.Write("Choice: ");
            string choice = Console.ReadLine() ?? "";
            if (choice != "1")
                break;
        }

        Console.WriteLine("\nCart");
        decimal totalAmount = 0;
        foreach (var item in cart)
        {
            Console.WriteLine($"{item.Product.ProductName} x{item.Quantity}");
            totalAmount += item.Product.Price * item.Quantity;
        }

        decimal discountPercent;
        if (totalAmount < 1000)
            discountPercent = 0;
        else if (totalAmount <= 4999)
            discountPercent = 10;
        else if (totalAmount <= 9999)
            discountPercent = 20;
        else
            discountPercent = 30;

        decimal discountAmount = totalAmount * discountPercent / 100;
        decimal finalAmount = totalAmount - discountAmount;

        Console.WriteLine($"\nTotal Amount: {totalAmount}");
        Console.WriteLine($"Discount: {discountAmount} ({discountPercent}%)");
        Console.WriteLine($"Final Amount: {finalAmount}");

        Console.WriteLine("\nChoose Payment");
        Console.WriteLine("1. UPI");
        Console.WriteLine("2. Credit Card");
        Console.WriteLine("3. Debit Card");
        Console.WriteLine("4. Cash on Delivery");
        Console.Write("Enter option: ");
        int paymentOption = Convert.ToInt32(Console.ReadLine());

        switch (paymentOption)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                Console.WriteLine("\nPayment Successful");
                break;
            default:
                Console.WriteLine("\nInvalid Option");
                break;
        }
    }

    static void PrintProducts(List<Product> products)
    {
        Console.WriteLine("\n===== Product List =====");
        foreach (var p in products)
        {
            Console.WriteLine($"ID: {p.ProductId}, Name: {p.ProductName}, Price: {p.Price}, Stock: {p.Stock}");
        }
    }
}