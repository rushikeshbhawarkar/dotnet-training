using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
          try
      {
       
         Console.WriteLine("------Welcome to login Page------");
         Console.WriteLine("Enter User name");
         string uname = Console.ReadLine();
         Console.WriteLine("Enter User ID");
         string userId = Console.ReadLine();
         Dictionary<int,Vehicle> VehicleDB= new Dictionary<int, Vehicle>();

        
        
        bool j = true;
        while(j ==true)
        {
            Console.WriteLine("Enter the number to perform the operations");
            Console.WriteLine("1. Add Vehicle");
            Console.WriteLine("2. View all Vehicles");
            Console.WriteLine("3. Search Vehicle");
            Console.WriteLine("4. Update Vehicle Price");
            Console.WriteLine("5. Delete Vehicle");
            Console.WriteLine("6. Vehicle Disscount");
            Console.WriteLine("7. Show Vehicle Details");
            Console.WriteLine("8. Exit");
           int number = Convert.ToInt32(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        {
                            Console.WriteLine("1. Add Vehicle");
                            //-------------------
                            Console.WriteLine("Enter Vehicle ID");
                            int vid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Vehicle Name");
                            string name_ = Console.ReadLine();
                            Console.WriteLine("Enter Vehicle Type");
                            string type_ = Console.ReadLine();
                            Console.WriteLine("Enter Brand of the vehicle");
                            string brand_ = Console.ReadLine();
                            Console.WriteLine("Enter Price of the vehicle");
                            int price_ = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Manufacturing Year of the vehicle");
                            int myear_ = Convert.ToInt32(Console.ReadLine());
                            // VehicleDB.Add(vid, new Vehicle(vid, name_, type_, brand_, price_, myear_));
                            Vehicle v_1 = new Vehicle(vid, name_, type_, brand_, price_, myear_);
                            VehicleDB.Add(vid, v_1);
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("2. View all Vehicles");
                        ;
                            
                            

                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("3. Search Vehicle");
                            Console.WriteLine("Enter Vehicle ID");
                            int num = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Vehicle ID = "+VehicleDB[num].VehicleID);
                            Console.WriteLine("Vehicle Name = "+VehicleDB[num].VehicleName);
                            Console.WriteLine("Vehicle Type = "+VehicleDB[num].VehicleType);
                            Console.WriteLine("Brand of the vehicle = "+VehicleDB[num].Brand);
                            Console.WriteLine("Price of the vehicle = "+VehicleDB[num].Price);
                            Console.WriteLine("Manufacturing Year of the vehicle = "+VehicleDB[num].ManufacturingYear);
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("4. Update Vehicle Price");
                        }   
                        break;
                    case 5:
                        {
                            Console.WriteLine("5. Delete Vehicle");
                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("6. Vehicle Disscount");
                        }
                        break;
                    case 7:
                        {
                            Console.WriteLine("7. Show Vehicle Details");
                        }
                        break;
                    case 8:
                        {
                            Console.WriteLine("8. Exit");
                            j = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please enter the valid number");
                        }
                        break;


                }
                
        }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


    }
}