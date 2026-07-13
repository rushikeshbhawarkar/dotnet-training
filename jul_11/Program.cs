using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        

        List<Employee> employee = new List<Employee>();
        List<Manager> managers = new List<Manager>();

        while (true)
        {
            Console.WriteLine("Welcome to Employee System");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Add Manager");
            Console.WriteLine("3. View Employee");
            Console.WriteLine("4. View Managers ");
            Console.WriteLine("5. Search Employee");
            Console.WriteLine("6. Exit");

            Console.Write("Enter a choice 1-6");
        

        try
        {
            int choice = Convert.ToInt32(Console.ReadLine());
           
            switch (choice)
            {   //case 1
                case 1:
                    Console.WriteLine("Enter id =");
                    int id = Convert.ToInt32(Console.ReadLine());
                    bool exists = false;
                    foreach(Employee emp in employee)
                    {
                        if(emp.Id== id)
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (exists)
                    {
                        Console.WriteLine("Employee already Exist");
                        break;
                    }
                    Console.WriteLine("Enter name =");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter salary =");
                    double salary = Convert.ToInt32(Console.ReadLine());
                    Employee employees = new Employee(id,name,salary);

                    //add in collection
                    employee.Add(employees);
                    Console.WriteLine("Employee added successfully");
                    break;


                //case 2
                case 2:
                    Console.WriteLine("Enter Manager ID =");
                    int mid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter name =");
                    string mname = Console.ReadLine();
                    Console.WriteLine("Enter salary =");
                    double msalary = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter department =");
                    string mdept = Console.ReadLine();

                    Manager manager = new Manager(mid,mname,msalary,mdept);
                    managers.Add(manager);
                    Console.WriteLine("Manager added succesfully");
                    break;


                    //case 3
                case 3:
                    if (employee.Count == 0)
                    {
                        Console.WriteLine("No employees in the system");
                    }
                    else
                    {
                        foreach(Manager mag in managers)
                        {
                            mag.DisplayManager();
                        }
                    }
                    break;

                    case 4:
                    if (managers.Count == 0)
                    {
                        Console.WriteLine("No Manager in the system");
                    }
                    else
                    {
                        foreach(Employee emp in employee)
                        {
                            emp.DisplayDetails();
                        }
                    }
                    break;

                    //case 5
                case 5:
                    Console.WriteLine("Enter Empoyee id =");
                    int searchId =Convert.ToInt32(Console.ReadLine());
                    bool found = false;
                     foreach(Employee emp in employee)
                    {
                        if(emp.Id== searchId)
                        {
                            emp.DisplayDetails();
                            found= true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Employee not found");
                        break;
                    }
                    break;

                    //case 6
                case 6:
                  return;

                default:
                  Console.WriteLine("Invalid choice");
                  break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Please a number only");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        }
    }
}