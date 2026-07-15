using System;
using System.Runtime.CompilerServices;
abstract class ParentStationary : Product
{
    private int _itemid;
    public int itemid
    {
        get{return _itemid;}
        set{_itemid= value;}
    }
    private string _itemname;
    public string itemname
    {
        get{return _itemname;}
        set{_itemname= value;}
    }
    private int _itemprice;
    public int itemprice
    {
        get{return _itemprice;}
        set{_itemprice= value;}
    }
    private int _itemquantity;
    public int itemquantity
    {
        get{return _itemquantity;}
        set{_itemquantity= value;}
    }
    // private int x;
    // public int y
    // {
    //     get{return x;}
    //     set{x= value;}
    // }
    public virtual void DisplayDetails()
    {
        Console.WriteLine("Item id: "+itemid);
        Console.WriteLine("Item name: "+itemname);
        Console.WriteLine("Item price: "+itemprice);
        Console.WriteLine("Item quantity: "+itemquantity);
    }
    public void UpdateQuantity(int newquantity)
    {
        itemquantity = newquantity;
    }

    public override double CalculateDiscount()
    {
        return 0;
    }
}