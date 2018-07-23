using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;


namespace _04_Collections
{
    internal class Program
    {
        static void Main()
        {

            ExampleArrayOperations();

            /* Operation on list */
            List<string> listOfNames = new List<string>()
            {
                "Adrianna Bielicz",
                "Maciej Walus"
            };

            ListActionMenuItems(listOfNames);

            string[] arrayWithElementsFromList = listOfNames.ToArray();
            ShowArray(arrayWithElementsFromList);

            Dictionary<string, int> howOld = new Dictionary<string, int>()
            {
                {"Jerry Doe", 11 },
                {"Jenny Doe", 6 },
                {"Jane Doe", 48 },
                {"John Doe", 47 }
            };
            string name = "Jezebel Doe";
            int age = 22;
            var whatHold = !howOld.ContainsKey(name);
            CheckIfKeyInDictonary(howOld, name, age);
            CheckIfValueInDictonary(howOld, age);
            //ShowDictionaryByAge(howOld);
            //ShowDictionaryByName(howOld);


            Queue queue = new Queue();
            queue.Enqueue(3);
            queue.Enqueue(2);
            queue.Enqueue(1);
            queue.Enqueue("Four");
            ShowQueque(queue);

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

        private static void ShowQueque(Queue queue)
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
            /* Operations on array */
            Console.Write("Enter the number : ");
            string readLine = Console.ReadLine();
            int howMany;
            int.TryParse(readLine, out howMany); //todo: surround with IF
            //howMany = int.Parse(readLine);

            int[] userArray = new int[howMany];
            userArray = CreateArrayOfRandomNumbers(userArray); //todo: rename to "CreateArrayOfRandomNumbers    (prawdopodobnie, argumentem bzie teraz how many

            Array.Sort(userArray);

            foreach (int number in userArray)
            {
                Console.WriteLine(number);
            }
        }


        private static int[] CreateArrayOfRandomNumbers(int[] userArray)
        {
            Random randomNumbers = new Random();
            for (int i = 0; i < userArray.Length; i++)
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

        private static void ListActionMenuItems(List<string> listOfNames) //todo: rename listOfNames
        {
            bool endOfLoop = true;

            while (endOfLoop)
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

                var readLine = Console.ReadLine();
                int chose;
                bool isNumerical = int.TryParse(readLine, out chose);

                switch (chose)      //todo: this switch breaks SRP becuase is operates on the list and manages break of the loop
                {
                    case 1:     //todo: magic number, make const as strings
                        ReadList(listOfNames);
                        break;
                    case 2:
                        AddRecordOnTheTopOfList(listOfNames); //todo: without 
                        break;
                    case 3:
                        AddRecordOnTheBootomOfList(listOfNames);
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
                        ShowList(listOfNames);
                        break;
                    case 7: //if for this outside
                        endOfLoop = false;
                        break;
                    default:
                        Console.WriteLine("I don't understand you. Please chose from numbers 1-7");
                        break;

                }


            }
        }

        private static void ShowList(List<string> listOfNames)
        {
            foreach (string name in listOfNames)
            {
                Console.WriteLine(name);
            }
        }

        private static void AddRecordOnTheBootomOfList(List<string> listOfNames)
        {
            Console.WriteLine("Give me a name and surname and press enter.");
            string userGiveAName = Console.ReadLine();
            listOfNames.Add(userGiveAName);
        }

        private static void AddRecordOnTheTopOfList(List<string> listOfNames)
        {
            Console.WriteLine("Give me a name and surname and press enter.");
            string userGiveAName = Console.ReadLine();
            listOfNames.Insert(0, userGiveAName);
        }

        private static void ShowArray(string[] tableStrings) //todo: not show, print for console
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
            foreach (KeyValuePair<string, int> person in howOld.OrderBy(person => person.Value))        //todo: order by move to separate variable
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

    }

}
