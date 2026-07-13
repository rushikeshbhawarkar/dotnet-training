//-----> Convert an object into form eg - hson so thet it can be shared

using System;
using System.Text.Json;
class SearializeEg
{
    static void Main()
    {
        Employee e = new Employee(101,"abc",4500);

        string json = JsonSerializer.Serialize(e);
        Console.WriteLine(json);

        
    }
}