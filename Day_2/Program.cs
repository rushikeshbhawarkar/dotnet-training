using System;

class Program{

static void Main(string []args)
{
    Console.WriteLine("Total number of packages = 20");
int x = 20;
        int a=0;
        int b=0;
        int c=0;

        for(int i = 1;i<=x;i++){
            if(i%4==0){
                Console.WriteLine("Quality Check Required for "+i);
                a++;
            }else if(i%5==0){
                Console.WriteLine("Priority Shipment for "+i);
                b++;
            }else{
                Console.WriteLine("Normal Processing required for "+i);
                c++;
            }
        }
        Console.WriteLine("Total Quality check = "+a);
        Console.WriteLine("Total Priority Shipment = "+b);
        Console.WriteLine("Total Normal processing= "+c);

}

}





// A smart city has 30 street lights numbered 1 to 30. The power consumption (in watts) for each light is calculated using the formula:
// Power = 80 + (Light Number × 5)
// For each street light:
// If power consumption is greater than 180 W, display "Maintenance Required".
// Else if power consumption is between 140 W and 180 W, display "Normal Operation".
// Otherwise, display "Energy Efficient".
// Also calculate and display:
// Total power consumed by all street lights
// Average power consumption
// Number of lights in each category

using System;

class First{

public void Display()
{
    Console.WriteLine("Total number of lights = 20");
int x = 30;
        int a=0;
        int b=0;
        int c=0;
        int power =0;

        for(int i = 1;i<=x;i++){
            int pc= 80 + (i*5);
            Console.Write("Power consumption for "+i+" light = "+pc+" Watt ----");
            power = power +pc;

            if(pc>180){
                Console.WriteLine("Remark - Maintenance Required");
                a++;
            }else if(pc<180 && pc>140){
                Console.WriteLine("Normal operation");
                b++;
            }else{
                Console.WriteLine("Energy Efficient");
                c++;
            }
        }
        Console.WriteLine("Total power consumption = "+power);
        Console.WriteLine("Average power consumption = "+power/30);
        Console.WriteLine("Total maintenance required = "+a);
        Console.WriteLine("Total Normal Operation = "+b);
        Console.WriteLine("Total Energy Efficient = "+c);
        
}

}


