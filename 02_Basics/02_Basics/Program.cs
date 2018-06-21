using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace _02_Basics
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Jane";
            string lastName = "Doe";

            Console.WriteLine("Name: " + firstName + " " + lastName);
            while (true)
            {
                Console.Write("Enter the new first name and press enter key:: ");
                firstName = Console.ReadLine();

                if (Regex.IsMatch(firstName, @"^[a-zA-Z]+$")) //better way to do this!? this won't work enter value 
                {   

                    break;
                }
                Console.WriteLine("Please enter characters value!");
            }
            /*
             * In Csharp, strings are immutable, which means that strings are never changed after they have been created. 
             * When using methods which changes a string, the actual string is not changed - a new string is returned instead.
            */
            
            //firstName = Console.ReadLine();

            Console.WriteLine("New name: " + firstName + " " + lastName);

            int number;

            Console.WriteLine("Please enter a number between 0 and 10:");
            //line below make bugs? why is that?
            //number = int.Parse(Console.ReadLine());
            //other solution
            while (true)
            {
                Console.Write("Enter the number : ");
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    break;
                }
                Console.WriteLine("Please enter an integer value!");
            }

            if ((number > 10) || (number < 0))
                Console.WriteLine("Hey! The number should be 0 or more and 10 or less!");
            else
                Console.WriteLine("Good job!");

            Console.ReadLine();
        }
    }
}
