using System;
using System.Runtime.CompilerServices;

class Notebook : ParentStationary
{
    private int _pages;
    public int pages
    {
        get{return _pages;}
        set{_pages= value;}
    }
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Item pages: "+pages);
    }

    public override double CalculateDiscount()
    {
        return 0.10;
    }
}

class Pen : ParentStationary
{
    private string _inkColor;
    public string inkcolor
    {
        get{return _inkColor;}
        set{_inkColor= value;}
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Ink color: "+inkcolor);
    }

    public override double CalculateDiscount()
    {
        return 0.05;
    }
}