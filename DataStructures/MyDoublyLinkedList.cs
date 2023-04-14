
using DataStructureImplementation.DSSortingAlgorithms;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace DataStructureImplementation.DataStructures
{
    internal class MyDoublyLinkedList<T> : DLLSort<T> 
        where T : IComparable<T>
    {
        private Stopwatch sw = new Stopwatch();
        private DLLNode<T>? _head;
        internal MyDoublyLinkedList()
        {
            _head = null;
        }
        private DLLNode<T> GetLastNode()
        {
            DLLNode<T> tempNode = _head;
            while (tempNode.next != null)
            {
                tempNode = tempNode.next;
            }
            return tempNode;
        }
        private void InsertFront(T data)
        {
            DLLNode<T>? newNode = new DLLNode<T>(data);
            newNode.next = _head;
            newNode.prev = null;
            
            if(_head!=null)
                _head.prev = newNode;

            _head = newNode;
        }
        private void InsertEnd(T data)
        {
            DLLNode<T> newNode = new DLLNode<T>(data);
            if (_head == null)
            {
                newNode.prev = null;
                _head = newNode;
                return;
            }
            DLLNode<T> lastNode = GetLastNode();
            lastNode.next = newNode;
            newNode.prev = lastNode;
        }
        internal void LoadDataInDataStructure(IEnumerable<T> records)
        {
            foreach (var record in records)
            {
                InsertEnd(record);
            }
        }
        internal void PrintDataInDataStructure(DLLNode<T>? tempNode)
        {
            while (tempNode != null)
            {
                Console.WriteLine(tempNode.data.ToString());
                tempNode = tempNode.next;
            }
        }
        private DLLNode<T>? CopyLinkedList()
        {
            if (_head == null)
                return null;
            if (_head.next == null)
                return new DLLNode<T>(_head.data);
            DLLNode<T> tempHead = new DLLNode<T>(_head.data);
            DLLNode<T> temp1 = tempHead;
            DLLNode<T> temp2 = _head.next;
            DLLNode<T>? prev = null;
            while (temp2 != null)
            {
                temp1.next = new DLLNode<T>(temp2.data);
                temp1.prev = prev;
                prev = temp1;
                temp1 = temp1.next;
                temp2 = temp2.next;
            }

            return tempHead;
        }
        private void Sort(string type)
        {
            DLLNode<T>? tempNode = CopyLinkedList();

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
                    DLLNode<T> tail = GetLastNode();
                    QuickSort(tempNode, tail);
                    Console.WriteLine($"Time taken by Quick Sort {sw.Elapsed}");
                    break;

                default:
                    Console.WriteLine("No such Algorithm is Implemented.....");
                    break;
            }

            sw.Reset();
        }
        public void SortDataStructure()
        {
            Console.WriteLine("Sorting Algorithms on Doubly Linked List.......");
            Sort("Bubble");
            Sort("Insertion");
            Sort("Merge");
            Sort("Quick");
        }

    }
}
