using System;
using System.Text.RegularExpressions;

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

                if (Regex.IsMatch(firstName, @"^[a-zA-Z]+$"))
                {
                    break;
                }
                Console.WriteLine("Please enter characters value!");
            }

            Console.WriteLine("New name: " + firstName + " " + lastName);

            int number;

            Console.WriteLine("Please enter a number between 0 and 10:");

            while (true)
            {
                Console.Write("Enter the number : ");
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    break;
                }
                Console.WriteLine("Please enter an integer value!");
            }

            if (number > 10 || number < 0)
            {
                Console.WriteLine("Hey! The number should be 0 or more and 10 or less!");
            }
            else
            {
                Console.WriteLine("Good job!");
            }

            Console.ReadLine();
        }
    }
}
