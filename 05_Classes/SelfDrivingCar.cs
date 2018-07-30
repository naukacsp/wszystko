using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Classes
{
    internal abstract class UnusualCar
    {
        public virtual string Describe()
        {
            return "It's not a usual car!";
        }
    }

    internal class SelfDrivingCar : UnusualCar
    {
        public override string Describe()
        {
            string result = base.Describe();
            result += " New car on a market. That take from you a great experience of driving.";
            return result;
        }
    }
}