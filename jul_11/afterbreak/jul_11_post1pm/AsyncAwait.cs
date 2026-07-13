using System;
using System.Threading.Tasks;


public class AsyncAwait
{
    static async Task Main()
    {
        Console.WriteLine("Loading details");
        await LoadEmployee();
        Console.WriteLine("Completed ");

    }
    static async Task LoadEmployee()
    {
        await Task.Delay(3000);
         Console.WriteLine("Employee loaded");

    }
}