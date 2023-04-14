using DataStructureImplementation.Enumerations;
using DataStructureImplementation.DataStructures;

namespace DataStructureImplementation
{
    internal static class App
    {
        internal static int SortingParameter {get; private set; }
        private static void DisplayOptions()
        {
            Console.WriteLine("Sorting Parameters......\n");
            Console.WriteLine("1. First Name");
            Console.WriteLine("2. Last Name");
            Console.WriteLine("3. City");
            Console.WriteLine("4. State\n");
        }
        private static void SelectSortingParameter()
        {
            do
            {
                Console.WriteLine("Sorting on the multiple data structures.........");
                DisplayOptions();
                Console.Write("Your Sorting Parameter: ");
                try
                {
                    SortingParameter = Convert.ToInt32(Console.ReadLine());
                    if (SortingParameter >= 1 && SortingParameter <= 4)
                        break;
                }
                catch
                {
                    Console.WriteLine("Invalid Input. Try Again");
                }
                Console.Clear();

            } while (true);
        }
        internal static void AppStart()
        {
            Console.WriteLine("FetchingData........");
            IEnumerable<Person> records = Records.FetchData();
            Console.Clear();
            
            SelectSortingParameter();
            
            int iterator = 1;

            MyDoublyLinkedList<Person> myDoublyLinkedList = new MyDoublyLinkedList<Person>();

            Console.WriteLine("Binding Data in Doubly Linked List..........");
            myDoublyLinkedList.LoadDataInDataStructure(records);
            Console.Clear();
            Console.WriteLine("DOUBLY LINKED LIST...............");
            myDoublyLinkedList.SortDataStructure();

            /*while (iterator < 5)
            {
                switch ((DS)iterator)
                {
                    case DS.Array:
                        MyArray<Person> myArray = new MyArray<Person>();

                        Console.WriteLine("Binding Data in Array..........");
                        myArray.LoadDataInDataStructure(records);
                        Console.Clear();
                        Console.WriteLine("ARRAY............");
                        myArray.SortStructure();

                        iterator++;
                        break;

                    case DS.Queue:
                        MyQueue<Person> myQueue = new MyQueue<Person>();

                        Console.WriteLine("Binding Data in Queue..........");
                        myQueue.LoadDataInDataStructure(records);
                        Console.Clear();
                        Console.WriteLine("QUEUE.............");
                        myQueue.SortDataStructure();

                        iterator++;
                        break;

                    case DS.Stack:
                        MyStack<Person> myStack = new MyStack<Person>();

                        Console.WriteLine("Binding Data in Stack..........");
                        myStack.LoadDataInDataStructure(records);
                        Console.Clear();
                        Console.WriteLine("STACK...............");
                        myStack.SortDataStructure();

                        iterator++;
                        break;

                    case DS.LinkedList:
                        MyLinkedList<Person> myLinkedList = new MyLinkedList<Person>();

                        Console.WriteLine("Binding Data in Singly Linked List..........");
                        myLinkedList.LoadDataInDataStructure(records);
                        Console.Clear();
                        Console.WriteLine("LinkedList............");
                        myLinkedList.SortDataStructure();

                        iterator++;

                        break;

                    case DS.DoublyLinkedList:
                        MyDoublyLinkedList<Person> myDoublyLinkedList = new MyDoublyLinkedList<Person>();

                        Console.WriteLine("Binding Data in Doubly Linked List..........");
                        myDoublyLinkedList.LoadDataInDataStructure(records);
                        Console.Clear();
                        Console.WriteLine("DOUBLY LINKED LIST...............");
                        myDoublyLinkedList.SortDataStructure();

                        break;

                    default:
                        Console.WriteLine("Implemented All Data Structures");
                        break;
                }
            }*/
        }

    }
}
