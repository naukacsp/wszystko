using System;
using System.Text;
namespace _03_DataTypes
{
    class Program
    {
        private static readonly Random Random = new Random();

        static void Main()
        {
            int? nullable = null; // Just fine - it's nullable!
            int randomInt = Random.Next(0, 1);

            if (randomInt == 1)
            {
                Console.WriteLine("You are simply normal person!");
            }
            else
            {
                Console.WriteLine("What on the Earth?! You are totally crazy!");
            }

            ConversionExamples();

            Console.ReadKey();

            StringBuilder numbers = new StringBuilder();

            for (int i = 0; i < 1000; i++)
            {
                numbers.Append(i);
            }

            Console.WriteLine(numbers.ToString());
        }

        private static void ConversionExamples()
        {
            int sampleValueToConvert = 1;

            bool checkConversionIntToBool = Convert.ToBoolean(sampleValueToConvert);

            Console.WriteLine("Bool: " + checkConversionIntToBool);
            Console.WriteLine("Int:  " + Convert.ToInt32(checkConversionIntToBool));

            Console.WriteLine("Bool v2: " + sampleValueToConvert == "1");

            try
            {
                Console.WriteLine("convert to null = {0}", Convert.ToInt32("a"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            int parseResult;

            if (int.TryParse("aa", out parseResult))
            {
                Console.WriteLine("parsing success, " + parseResult);
            }
            else
            {
                Console.WriteLine("parse failure");
            }

            //int parseResult2 = int.Parse("33");
        }
    }
}
