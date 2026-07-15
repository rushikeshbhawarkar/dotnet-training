using System;
class Program
{
    static void Main(string[] args)
    {
        try
      {
        for(int i = 1; i<= 3;i++)
        {
            Console.WriteLine("------Welcome to login Page------");
            Console.WriteLine("Enter User name");
            string uname = Console.ReadLine();
            Console.WriteLine("Enter User Password");
            string password = Console.ReadLine();

         if(uname=="admin"&&password =="admin123")
         {
            Console.WriteLine("Password ==== Correct!!!");
            break;
            }
            else
            {
                Console.WriteLine("##### Invalid Login #####");
                Console.WriteLine("----Attempts Remeaning = "+(3-i)+"----");
                Console.WriteLine("");
                if (i == 3)
                {
                    throw new LoginFailedException("Invalid Login attempt");
                }
            }
        }

        PurchaseModule billService = new PurchaseModule();

        Console.WriteLine("Enter Item Id");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Name");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Category");
        string category = Console.ReadLine();

        Console.WriteLine("Enter Brand");
        string brand = Console.ReadLine();

        Console.WriteLine("Enter Price");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter Quantity");
        int quantity = int.Parse(Console.ReadLine());

        StationeryItem item = new StationeryItem(id, name, category, brand, price, quantity);
        billService.AddItem(item);
        billService.GenerateBill();
      }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}