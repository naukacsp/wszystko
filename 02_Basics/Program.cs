using System;
using System.Text.RegularExpressions;

namespace _02_Basics
{
    public class Program
    {
        private const int MoreThan = 10;
        private const int LessThan = 0;

        public static void Main()
        {
            string firstName = "Jane";
            string lastName = "Doe";

            Console.WriteLine("Name: " + firstName + " " + lastName);
            firstName = NameLoop();
            Console.WriteLine("New name: " + firstName + " " + lastName);

            int number;

            Console.WriteLine("Please enter a number between 0 and 10:");

            while (true)
            {
                Console.Write("Enter the number : ");

                string readLine = Console.ReadLine();

                if (int.TryParse(readLine, out number))
                {
                    break;
                }

                Console.WriteLine("Please enter an integer value!");
            }

            while (true)
            {
                if (number > MoreThan || number < LessThan)
                {
                    Console.WriteLine("Hey! The number should be 0 or more and 10 or less!");
                }
                else
                {
                    Console.WriteLine("Good job!");
                    break;
                }

                AddFive(ref number); //referencja taka jak w wskazniki

                Console.WriteLine(number);

                TakeFive(number);

                Console.WriteLine("I'm outside of the function" + number);
                Console.WriteLine("number: " + number);
                Console.WriteLine("number: {0}", number);
                Console.WriteLine($"number: {number}");
            }

            Console.ReadLine();
        }

        public static string NameLoop()
        {
            while (true)
            {
                Console.Write("Enter the new first name and press enter key: ");
                string firstName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(firstName) && Regex.IsMatch(firstName, @"^[a-zA-Z]+$"))
                {
                    return firstName;
                }
                Console.WriteLine("Please enter characters value!");
            }
        }

        public static void AddFive(ref int number) //nie uzywac refa!
        {
            number = number + 5;
        }

        public static void TakeFive(int number)
        {
            number = number - 5;
            Console.WriteLine("I'm inside a function: " + number);
        }
    }
}
