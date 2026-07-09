using System;
using System.Linq;

namespace problem_1
{
    public class Problem1
    {
        public static void Run()
        {
            Console.WriteLine("--- Running Problem 1 ---");
            
            int[] sales = new int[6];
        int x = 0;

        for(int i = 0;i<=5;i++ )
        {
           Console.Write("Enter the sales for "+(i+1)+"= ");
           sales[i] = Convert.ToInt32(Console.ReadLine());
  
        }
        Console.WriteLine("Therefore");
        for(int j = 0; j <= 5; j++)
        {
         Console.WriteLine("The sales for "+(j+1)+" = "+sales[j]);
         x=  x+ sales[j];
        }
         Console.WriteLine("Total sales = "+x);
         Console.WriteLine("Average sales = "+x/6);
         Console.WriteLine("Total sales = "+x);
         Console.WriteLine("Maximum sales = "+sales.Max());
         Console.WriteLine("Minimum sales = "+sales.Min());


            
        }
    }
}