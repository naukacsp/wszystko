using System;
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

            Console.WriteLine("Please enter a new first name and press enter key:");
            /*
             * In Csharp, strings are immutable, which means that strings are never changed after they have been created. 
             * When using methods which changes a string, the actual string is not changed - a new string is returned instead.
            */
            firstName = Console.ReadLine();

            Console.WriteLine("New name: " + firstName + " " + lastName);

            Console.ReadLine();
        }
    }
}
