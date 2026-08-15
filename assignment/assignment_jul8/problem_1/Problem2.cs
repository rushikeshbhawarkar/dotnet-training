using System;

namespace problem_1
{
    public class Problem2
    {
        public static void Run()
        {
            Console.WriteLine("--- Running Problem 2 ---");
            List<string> book = new List<string>()
            {
                "C Sharp Programming",
                "JAVA Programming",
                "C Programming"
            };
            Console.WriteLine("Books are ");

            for(int i =0;i<book.Count;i++)
            {
                Console.WriteLine(book[i]);
            }

            book.Add("Python Programming");


            Console.WriteLine(" ");
            Console.WriteLine("============================= ");
            Console.WriteLine(" ");
            Console.WriteLine("Books after adding are ");

            for(int i =0;i<book.Count;i++)
            {
                Console.WriteLine(book[i]);
            }
            
            book.Remove("JAVA Programming");

            Console.WriteLine(" ");
            Console.WriteLine("============================= ");
            Console.WriteLine(" ");
            Console.WriteLine("Books after removing are ");
           
            for(int i =0;i<book.Count;i++)
            {
                Console.WriteLine(book[i]);
            }



            
        }
    }
}