using System;
using System.Collections.Generic;
using System.IO;
class Program
{
    static void Main(string[] args)
        {
                // string empname = "RAHUL";
        // Console.WriteLine(empname.Propercase());
        File.WriteAllText("emp.txt","Name : Rushikesh ");
       string data = File.ReadAllText("emp.txt");
       Console.WriteLine(data);
        }
}


