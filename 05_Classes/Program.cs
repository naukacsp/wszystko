using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Classes
{
    internal class Program
    {
        private static void Main()
        {
            Car skodaSuperb = new Car("black");
            skodaSuperb.MakeSound();
            Car audiA8 = new Audi();
            audiA8.MakeSound();
            UnusualCar googleCar = new SelfDrivingCar();
            Console.WriteLine(googleCar.Describe());
            //
            //Console.WriteLine(skodaSuperb.Describe);
            Console.Read();
        }
    }
}