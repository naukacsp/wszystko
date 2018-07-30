using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Classes
{
    public class Audi : Car
    {
        public override void MakeSound()
        {
            base.MakeSound();
            Console.WriteLine("Mrrrrr!");
        }
    }
}