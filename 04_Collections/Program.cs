using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;


namespace _04_Collections
{
    internal class Program
    {

        private static int[] FillArray(int[] userArray)
        {
            Random randomNumbers = new Random();
            for (int i = 0; i< userArray.Length; i++)
            {
                userArray[i] = randomNumbers.Next(0, 101);
            }

            return userArray;
        }

        private static void ReadList(List<string> listOfNames)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            foreach (string name in listOfNames)
            {
                Console.WriteLine(name);
                synth.Speak(name);
            }
        }

        private static void ListMenu(List<string> listOfNames)
        {
            bool endOfLoop = false;
            string readLine;
            while (true)
            {
                Console.Write("\n***\n" +
                              "If you want to hear list of names press 1 and enter,\n" +
                              "if you want to add record on the top press 2 and enter, \n" +
                              "if you want to add record on the bottom press 3 and enter, \n" +
                              "if you want to delete record on the top press 4 and enter, \n" +
                              "if you want to delete record on the bottom press 5 and enter, \n" +
                              "if you want to read list of names press 6 and enter \n" +
                              "if you want to end press 0 and enter: \n" +
                              "***\n");
                readLine = Console.ReadLine();
                int chose;
                int.TryParse(readLine, out chose);
                switch (chose)
                {
                    case 1:
                        ReadList(listOfNames);
                        break;
                    case 2:
                        Console.WriteLine("Give me a name and surname and press enter.");
                        string userGiveAName = Console.ReadLine();
                        listOfNames.Insert(0, userGiveAName);
                        break;
                    case 3:
                        Console.WriteLine("Give me a name and surname and press enter.");
                        userGiveAName = Console.ReadLine();
                        listOfNames.Insert(listOfNames.Count, userGiveAName);
                        break;
                    case 4:
                        Console.WriteLine("\nYou deleted item from the top of the list " + listOfNames[listOfNames.Count - 1] + "!\n");
                        listOfNames.RemoveAt(0);
                        break;
                    case 5:
                        Console.WriteLine("\nYou deleted item from the bottom of the list: " + listOfNames[listOfNames.Count - 1] + "!\n");
                        listOfNames.RemoveAt(listOfNames.Count - 1);
                        break;
                    case 6:
                        foreach (string name in listOfNames)
                        {
                            Console.WriteLine(name);
                        }
                        break;
                    default:
                        endOfLoop = true;
                        break;

                }
                if (endOfLoop) break;


            }
        }

        private static void ShowArray(string[] tableStrings)
        {
            Console.WriteLine("Look, it is your table:");
            foreach (string dataRecord in tableStrings)
            {
                Console.WriteLine(dataRecord);
            }
        }

        private static void ShowDictionaryByAge(Dictionary<string, int> howOld)
        {
            Console.WriteLine("From the youngest to the oldest in Doe family:");
            foreach (KeyValuePair<string, int> person in howOld.OrderBy(person => person.Value))
            {
                Console.WriteLine(person.Key + " is " + person.Value + " years old");
            }
        }

        private static void ShowDictionaryByName(Dictionary<string, int> howOld)
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

        static void Main()
        {

           /* Operations on array */ 
            Console.Write("Enter the number : ");
            string readLine = Console.ReadLine();
            int howMany;
            int.TryParse(readLine, out howMany);


            int[] userArray = new int[howMany];
            userArray = FillArray(userArray);
            Array.Sort(userArray);

            foreach(int number in userArray)
            {
                Console.WriteLine(number);
            }
            /* Operation on list */
            List<string> listOfNames = new List<string>()
            {
                "Adrianna Bielicz",
                "Maciej Walus"
            };

            ListMenu(listOfNames);

            string[] arrayWithElementsFromList = listOfNames.ToArray();
            ShowArray(arrayWithElementsFromList);

            Dictionary<string, int> howOld = new Dictionary<string, int>()
            {
                {"Jerry Doe", 11 },
                {"Jenny Doe", 6 },
                {"Jane Doe", 48 },
                {"John Doe", 47 }
            };
           howOld.Add("Jezebel Doe", 22);
            AddRecordToDictionary(howOld);
            ShowDictionaryByAge(howOld);
            ShowDictionaryByName(howOld);
            Queue queue = new Queue();
            queue.Enqueue(3);
            queue.Enqueue(2);
            queue.Enqueue(1);
            queue.Enqueue("Four");
            foreach (var value in queue)
            {
                Console.WriteLine(value);
            }

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            Stack<int> stackOfInts = new Stack<int>();
            stackOfInts.Push(1);
            stackOfInts.Push(2);
            stackOfInts.Push(3);

            Console.ReadKey();
        }
    }

}
