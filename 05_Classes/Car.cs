using System;

namespace _05_Classes
{
    public class Car : ICar
    {
        private readonly string _color;
        private string _name;

        public string Describe()
        {
            return "Hello, I'm a car and my name is " + Name;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Car(string name)
        {
            Name = name;
            Console.WriteLine("Constructor with name parameter called!");
        }

        public Car(string color, string name)
        {
            Name = name;
            _color = color;
            Console.WriteLine($"Constructor with name and color parameter called! Color is:{0}", _color);
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