using System;



    public class Employee{

        public int Id { get; set; }
        public string Empname { get; set; }
        public double MonthySalary { get; set; }

        public Employee(int i , string e,double s)
    {
        Id = i;
        Empname = e;
        MonthySalary = s;
    }


        public void DisplayDetails()
        {
            Console.WriteLine($"Employee Id : {Id}");
            Console.WriteLine($"Name : {Empname}");
            
            Console.WriteLine($"Leave Balance : {MonthySalary} days");
            Console.WriteLine();
        }

    }
    
