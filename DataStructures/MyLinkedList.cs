using System.Diagnostics;
using DataStructureImplementation.DSSortingAlgorithms;

namespace DataStructureImplementation.DataStructures
{
    internal class MyLinkedList<T> : LinkListSort<T> 
        where T: IComparable<T>
    {
        private Stopwatch sw = new Stopwatch();
        private SLLNode<T>? _head;
        internal MyLinkedList()
        {
            _head = null;
        }
        internal void LoadDataInDataStructure(IEnumerable<T> records)
        {
            foreach (var record in records)
            {
                InsertEnd(record);
            }
        }
        internal void PrintDataInDataStructure(SLLNode<T>? tempNode)
        {
            while (tempNode != null)
            {
                Console.WriteLine(tempNode.data.ToString());
                tempNode = tempNode.next;
            }
        }
        internal void SortDataStructure()
        {
            Console.WriteLine("Sorting Algorithms on LinkedList.......");
            Sort("Bubble");
            Sort("Insertion");
            Sort("Merge");
            Sort("Quick");
        }
        private void Sort(string type)
        {
            SLLNode<T>? tempNode = CopyLinkedList();

            switch (type)
            {
                case "Bubble":
                    sw.Start();
                    BubbleSort(tempNode);
                    sw.Stop();
                    Console.WriteLine($"Time taken by Bubble sort {sw.Elapsed}");

                    break;

                case "Insertion":
                    sw.Start();
                    InsertionSort(tempNode);
                    sw.Stop();
                    Console.WriteLine($"Time taken by Insertion Sort {sw.Elapsed}");
                    break;

                case "Merge":
                    sw.Start();
                    MergeSort(tempNode);
                    Console.WriteLine($"Time taken by Merge Sort {sw.Elapsed}");
                    break;

                case "Quick":
                    sw.Start();
                    SLLNode<T>? tail = GetLastNode();
                    QuickSort(tempNode, tail);
                    Console.WriteLine($"Time taken by Quick Sort {sw.Elapsed}");
                    break;

                default:
                    Console.WriteLine("No such Algorithm is Implemented.....");
                    break;
            }

            sw.Reset();
        }
        private SLLNode<T>? GetLastNode()
        {
            SLLNode<T>? tempNode = _head;
            while(tempNode?.next != null)
            {
                tempNode = tempNode.next;
            }
            return tempNode;
        }
        private void InsertFront(T data)
        {
            SLLNode<T>? newNode = new SLLNode<T>(data);
            newNode.next = _head;
            _head = newNode;
        }
        private void InsertEnd(T data)
        {
            if(_head == null)
            {
                _head = new SLLNode<T>(data);
                return;
            }
            SLLNode<T>? lastNode = GetLastNode();
            if(lastNode != null)
                lastNode.next = new SLLNode<T>(data);
        } 
        private SLLNode<T>? CopyLinkedList()
        {
            if (_head == null)
                return null;
            if(_head.next == null)
                return new SLLNode<T> (_head.data);
            SLLNode <T> tempHead = new SLLNode<T>(_head.data);
            SLLNode<T> temp1 = tempHead;
            SLLNode<T> temp2 = _head.next;
            while(temp2 != null)
            {
                temp1.next = new SLLNode<T> (temp2.data);
                temp1 = temp1.next;
                temp2 = temp2.next;
            }

            return tempHead;
        }
        
    }
}
