using System;
using jul_10;

delegate void MessageDelegate(string msg);

class delegateeg
{
    static void Display(string message)
    {
        Console.WriteLine(message);
    
    }

    static void Main()
    {
        MessageDelegate m = Display;
        m("Hello , i m learning dotnet");

        Func<int,int,int,int> mul = (a,b,C) => a*b*C;
        Console.WriteLine(mul(19,20,30));
        linq l_1 = new linq();
        
    }
}