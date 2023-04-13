using DataStructureImplementation.SortInterface;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DataStructureImplementation.DataStructures
{
    internal class MyLinkedList<T> where T: IComparable<T>
    {
        private Stopwatch sw = new Stopwatch();
        private SLLNode<T>? _head;
        internal MyLinkedList()
        {
            _head = null;
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
        public void LoadDataInDataStructure(IEnumerable<T> records)
        {
            foreach(var record in records)
            {
                InsertEnd(record);
            }
        }
        public void PrintDataInDataStructure(SLLNode<T>? tempNode)
        {
            while(tempNode!=null)
            {
                Console.WriteLine(tempNode.data.ToString());
                tempNode = tempNode.next;
            }
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
        private void BubbleSort(SLLNode<T>? node)
        {
            if (node.next == null)
            {
                Console.WriteLine("Empty Linked List");
                return;
            }

            bool swapped;
            int i = 0;
            do
            {
                swapped = false;
                SLLNode<T>? current = node;
                while (current != null && current.next != null)
                {
                    if (current.data.CompareTo(current.next.data) > 0)
                    {
                        T temp = current.data;
                        current.data = current.next.data;
                        current.next.data = temp;
                        swapped = true;
                    }
                    current = current.next;
                }
            } while (swapped);
            //PrintDataInDataStructure(node);
        }
        private void InsertionSort(SLLNode<T>? node)
    {
        if (node == null)
            return;
        SLLNode<T>? sorted = null, current = node;
        while (current != null)
        {
            SLLNode<T>? temp = current.next;
            if (sorted == null || sorted.data.CompareTo(current.data) >= 0)
                {
                    current.next = sorted;
                    sorted = current;
                }
                else
                {
                    SLLNode<T> sortedCurrent = sorted;
                    while (sortedCurrent.next != null && sortedCurrent.next.data.CompareTo(current.data) < 0)
                    {
                        sortedCurrent = sortedCurrent.next;
                    }
                    current.next = sortedCurrent.next;
                    sortedCurrent.next = current;
                }
                current = temp;
            }
        }
        private SLLNode<T>? GetMiddle(SLLNode<T>? node)
        {
            if (node == null)
                return node;
            SLLNode<T>? fastIterator = node.next;
            SLLNode<T>? slowIterator = node;

            while (fastIterator != null)
            {
                fastIterator = fastIterator.next;
                if (fastIterator != null)
                {
                    slowIterator = slowIterator.next;
                    fastIterator = fastIterator.next;
                }
            }
            return slowIterator;
        }
        private SLLNode<T>? Merge(SLLNode<T>? left, SLLNode<T>? right)
        {
            SLLNode<T>? result = null;
            if (left == null)
                return right;
            if (right == null)
                return left;

            if (left.data.CompareTo(right.data) <= 0)
            {
                result = left;
                result.next = Merge(left.next, right);
            }
            else
            {
                result = right;
                result.next = Merge(left, right.next);
            }
            return result;
        }
        private SLLNode<T>? MergeSort(SLLNode<T>? node)
        {
            if (node == null)
                return null;

            SLLNode<T>? mid = GetMiddle(node);
            SLLNode<T>? nextofmiddle = mid.next;

            mid.next = null;

            SLLNode<T>? left = MergeSort(mid);

            SLLNode<T>? right = MergeSort(nextofmiddle);

            SLLNode<T>? sortedlist = Merge(left, right);

            return sortedlist;
        }
        private void QuickSort(SLLNode<T>? head, SLLNode<T>? tail)
        {
            if (head == null || head == tail)
                return;

            SLLNode<T>? pivot = PartitionLast(head, tail);
            QuickSort(head, pivot);

            if (pivot != null && pivot == head)
                QuickSort(pivot.next, tail);

            else if (pivot != null && pivot.next != null)
                QuickSort(pivot.next.next, tail);
        }
        private SLLNode<T>? PartitionLast(SLLNode<T>? head, SLLNode<T>? tail)
        {
            if (head == tail || head == null || tail == null)
                return head;
            SLLNode<T>? pivot = head;
            SLLNode<T>? curr = head;
            T pivotElement = tail.data;
            T temp;
            
            while (head != null && head != tail)
            {
                if (head.data.CompareTo(pivotElement) < 0)
                {
                    pivot = curr;

                    temp = curr.data;
                    curr.data = head.data;
                    head.data = temp;
                    
                    curr = curr.next;
                }
                head = head.next;
            }

            temp = curr.data;
            curr.data = pivotElement;
            tail.data = temp;

            return pivot;
        }
        private void Sort(string type)
        {
            SLLNode<T>? tempNode = CopyLinkedList();
            Console.WriteLine($"{type} Sort.......");

            switch(type)
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
        public void SortDataStructure()
        {
            Console.WriteLine("Sorting Algorithms on LinkedList.......");
            Sort("Bubble");
            Sort("Insertion");
            Sort("Merge");
            Sort("Quick");
        }
    }
}
