using System;

public class Vehicle(int VehicleID, string VehicleName, string VehicleType, string Brand, int Price, int ManufacturingYear)
{
    private int _vehicleid = VehicleID;

    public int VehicleID
    {
        get { return _vehicleid; }
        set { _vehicleid = value; }
    }

    private string _vehiclename = VehicleName;

    public string VehicleName
    {
        get { return _vehiclename; }
        set { _vehiclename = value; }
    }

    private string _vehicletype = VehicleType;

    public string VehicleType
    {
        get { return _vehicletype; }
        set { _vehicletype = value; }
    }

    private string _brand = Brand;

    public string Brand
    {
        get { return _brand; }
        set { _brand = value; }
    }

    private int _price = Price;

    public int Price
    {
        get { return _price; }
        set { _price = value; }
    }

    private int _manufacturingyear = ManufacturingYear;

    public int ManufacturingYear
    {
        get { return _manufacturingyear; }
        set { _manufacturingyear = value; }
    }
}