using DataStructureImplementation.Enumerations;
using DataStructureImplementation.DataStructures;

namespace DataStructureImplementation
{
    internal static class App
    {
        private static int _sortingParameter;
        public static int SortingParameter { get { return _sortingParameter; }set { _sortingParameter = value; } }

        private static void DisplayOptions()
        {
            Console.WriteLine("Sorting Parameters......\n");
            Console.WriteLine("1. First Name");
            Console.WriteLine("2. Last Name");
            Console.WriteLine("3. City");
            Console.WriteLine("4. State\n");
        }
        public static void AppStart()
        {
            Console.WriteLine("FetchingData........");
            IEnumerable<Person> records = Records.FetchData();
            Console.Clear();

            MyArray<Person> myArray = new MyArray<Person>();
            MyLinkedList<Person> myLinkedList = new MyLinkedList<Person>();
            MyStack<Person> myStack = new MyStack<Person>();
            MyQueue<Person> myQueue = new MyQueue<Person>();
            MyDoublyLinkedList<Person> myDoublyLinkedList = new MyDoublyLinkedList<Person>();

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

            /*Console.WriteLine("Binding Data in Array..........");
            myArray.LoadDataInDataStructure(records);
            Console.Clear();
            myArray.SortStructure();*/

            //Console.WriteLine("Binding Data in Stack..........");
            //myStack.LoadDataInDataStructure(records);
            //Console.Clear();
            //myStack.PrintDataStructure();

            //Console.WriteLine("Binding Data in Queue..........");
            //myQueue.LoadDataInDataStructure(records);
            //Console.Clear();
            //myQueue.PrintDataStructure();

            //Console.WriteLine("Binding Data in Singly Linked List..........");
            //myLinkedList.LoadDataInDataStructure(records);
            //Console.Clear();
            //myLinkedList.SortDataStructure();
            //myLinkedList.PrintDataInDataStructure();

            Console.WriteLine("Binding Data in Doubly Linked List..........");
            myDoublyLinkedList.LoadDataInDataStructure(records);
            Console.Clear();
            myDoublyLinkedList.SortDataStructure();
            //myDoublyLinkedList.PrintDataInDataStructure();

        }

    }
}
