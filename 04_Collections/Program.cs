using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;

namespace _04_Collections
{
    internal class Program
    {
        private const string MenuItemFirst = "1";
        private const string MenuItemOptionAddToTopOfList = "2";    //itd.
        private const string ConstForMenuThird = "3";
        private const string ConstForMenuFourth = "4";
        private const string ConstForMenuFifth = "5";
        private const string ConstForMenuSixth = "6";

        private static readonly Random RandomNumbers = new Random();

        private static void Main()
        {
            ExampleArrayOperations();

            /* Operation on list */
            List<string> names = new List<string>()
            {
                "Adrianna Bielicz",
                "Maciej Walus"
            };

            ListActionMenuItems(names);

            string[] arrayWithElementsFromList = names.ToArray();
            PrintArray(arrayWithElementsFromList);

            Dictionary<string, int> howOld = new Dictionary<string, int>()
            {
                {"Jerry Doe", 11 },
                {"Jenny Doe", 6 },
                {"Jane Doe", 48 },
                {"John Doe", 47 }
            };
            string name = "Jezebel Doe";
            int age = 22;
            CheckIfKeyInDictonary(howOld, name, age);
            CheckIfValueInDictonary(howOld, age);
            PrintDictionaryByAge(howOld);
            PrintDictionaryByName(howOld);
            AddRecordToDictionary(howOld);

            Queue queue = new Queue();
            queue.Enqueue(3);
            queue.Enqueue(2);
            queue.Enqueue(1);
            queue.Enqueue("Four");
            PrintQueque(queue);

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            Stack<int> stackOfInts = new Stack<int>();
            stackOfInts.Push(1);
            stackOfInts.Push(2);
            stackOfInts.Push(3);
            int peek = stackOfInts.Peek();
            Console.WriteLine("Element at the top:");
            Console.WriteLine(peek);
            int pop = stackOfInts.Pop();
            Console.WriteLine("Element popped from top of Stack:");
            Console.WriteLine(pop);
            peek = stackOfInts.Peek();
            Console.WriteLine("Element now at the top:");
            Console.WriteLine(peek);

            Console.ReadKey();
        }

        private static void PrintQueque(Queue queue)
        {
            foreach (var value in queue)
            {
                Console.WriteLine(value);
            }
        }

        private static void CheckIfValueInDictonary(Dictionary<string, int> howOld, int age)
        {
            if (howOld.ContainsValue(age))
            {
                Console.WriteLine("In Doe family is at least one person who is {0} years old.", age);
            }
        }

        private static void CheckIfKeyInDictonary(Dictionary<string, int> howOld, string name, int age)
        {
            if (!howOld.ContainsKey(name))
            {
                howOld.Add(name, age);
                Console.WriteLine("Jezebel added!");
            }
        }

        private static void ExampleArrayOperations()
        {
            bool endOfLoop = true;

            while (endOfLoop)
            {
                Console.Write("Enter the number : ");
                string readLine = Console.ReadLine();

                try
                {
                    int howMany = int.Parse(readLine);

                    int[] sortedRandomNumbers = CreateSortedRandomNumbers(howMany);

                    foreach (int number in sortedRandomNumbers)
                    {
                        Console.WriteLine(number);
                    }

                    endOfLoop = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("{0}: Not accepted value", readLine);
                }
            }
        }

        private static int[] CreateSortedRandomNumbers(int howMany)
        {
            int[] userArray = new int[howMany];

            for (int i = 0; i < userArray.Length; i++)
            {
                userArray[i] = RandomNumbers.Next(0, 101);
            }

            Array.Sort(userArray);

            return userArray;
        }

        private static void ReadList(List<string> names)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            foreach (string name in names)
            {
                Console.WriteLine(name);
                synth.Speak(name);
            }
        }

        private static void ListActionMenuItems(List<string> names) //todo: rename names
        {
            while (true)
            {
                Console.Write("\n***\n" +
                              "If you want to hear list of names press 1 and enter,\n" +
                              "if you want to add record on the top press 2 and enter, \n" +
                              "if you want to add record on the bottom press 3 and enter, \n" +
                              "if you want to delete record on the top press 4 and enter, \n" +
                              "if you want to delete record on the bottom press 5 and enter, \n" +
                              "if you want to read list of names press 6 and enter \n" +
                              "if you want to end press 7 and enter: \n" +
                              "***\n");

                string readLine = Console.ReadLine();

                if (string.Equals(readLine, "7", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }

                switch (readLine)
                {
                    case MenuItemFirst:
                        ReadList(names);
                        break;

                    case MenuItemOptionAddToTopOfList:
                        AddRecordOnTopOfList(names);
                        break;

                    case ConstForMenuThird:
                        AddRecordOnBootomOfList(names);
                        break;

                    case ConstForMenuFourth:
                        Console.WriteLine("\nYou deleted item from the top of the list " + names[names.Count - 1] + "!\n");
                        names.RemoveAt(0);
                        break;

                    case ConstForMenuFifth:
                        Console.WriteLine("\nYou deleted item from the bottom of the list: " + names[names.Count - 1] + "!\n");
                        names.RemoveAt(names.Count - 1);
                        break;

                    case ConstForMenuSixth:
                        PrintList(names);
                        break;

                    default:
                        Console.WriteLine("I don't understand you. Please chose from numbers 1-7");
                        break;
                }
            }
        }

        private static void PrintList(List<string> names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }

        private static void AddRecordOnBootomOfList(List<string> names)
        {
            Console.WriteLine("Give me a name and surname and press enter.");
            string userGiveAName = Console.ReadLine();
            names.Add(userGiveAName);
        }

        private static void AddRecordOnTopOfList(List<string> names)
        {
            Console.WriteLine("Give me a name and surname and press enter.");
            string userGiveAName = Console.ReadLine();
            names.Insert(0, userGiveAName);
        }

        private static void PrintArray(string[] items)
        {
            PrintArrayV2(items);
        }

        private static void PrintArrayV2(IEnumerable<string> items)
        {
            Console.WriteLine("Look, it is your table:");
            foreach (string item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void PrintDictionaryByAge(Dictionary<string, int> howOld)
        {
            Console.WriteLine("From the youngest to the oldest in Doe family:");

            IEnumerable<KeyValuePair<string, int>> orderedItems = howOld.OrderBy(person => person.Value).ToArray();

            foreach (KeyValuePair<string, int> person in orderedItems)
            {
                Console.WriteLine(person.Key + " is " + person.Value + " years old");
            }
        }

        private static void PrintDictionaryByName(Dictionary<string, int> howOld)
        {
            Console.WriteLine("Sorted by Name in Doe family:");
            foreach (KeyValuePair<string, int> person in howOld.OrderBy(person => person.Key))
            {
                Console.WriteLine(person.Key + " is " + person.Value + " years old");
            }
        }

        private static void AddRecordToDictionary(Dictionary<string, int> howOld)
        {
            Console.WriteLine("What is the name of the person you want add?");
            string readName = Console.ReadLine();
            if (readName == null)
            {
                readName = "Noname";
            }
            Console.WriteLine("What is the age of the person you want add?");
            string readAge = Console.ReadLine();
            int age;
            int.TryParse(readAge, out age);
            howOld.Add(readName, age);
        }
    }
}