using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Classes
{
    public class Car
    {
        private string color;

        public Car()
        {
            Console.WriteLine("Constructor with no parameters called!");
        }

        public Car(string color) : this()
        {
            this.color = color;
            Console.WriteLine("Constructor with color parameter called!");
        }

        ~Car()
        {
            Console.WriteLine("Out..");
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Wrrrrrr!");
        }
    }
}