using System;

namespace _05_Classes
{
    internal class Program
    {
        private static void Main()
        {
            Car skodaSuperb = new Car("Mruczuś", "black");
            skodaSuperb.MakeSound();
            Car audiA8 = new Audi("Red Lady");
            audiA8.MakeSound();
            UnusualCar googleCar = new SelfDrivingCar();
            Console.WriteLine(googleCar.Describe());
            //
            //Console.WriteLine(skodaSuperb.Describe);
            Console.Read();
        }
    }

    internal interface ICar
    {
        string Describe();

        string Name
        {
            get;
            set;
        }
    }
}