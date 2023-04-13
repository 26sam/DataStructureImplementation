
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace DataStructureImplementation.DataStructures
{
    internal class MyDoublyLinkedList<T> where T : IComparable<T>
    {
        private Stopwatch sw = new Stopwatch();
        private DLLNode<T> _head;
        public MyDoublyLinkedList()
        {
            _head = null;
        }
        DLLNode<T> GetLastNode()
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
        public void LoadDataInDataStructure(IEnumerable<T> records)
        {
            foreach (var record in records)
            {
                InsertEnd(record);
            }
        }
        public void PrintDataInDataStructure(DLLNode<T>? tempNode)
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
        private void BubbleSort(DLLNode<T>? node)
        {
            if (node == null)
                return;

            bool swapped;
            DLLNode<T>? curr;
            DLLNode<T>? last = null;
            do
            {
                swapped = false;
                curr = node;
                while (curr.next !=null && curr.next != last)
                {
                    if ((curr.data).CompareTo(curr.next.data) > 0)
                    {
                        T temp = curr.data;
                        curr.data = curr.next.data;
                        curr.next.data = temp;
                        swapped = true;
                    }
                    curr = curr.next;
                }

                last = curr;
            } while (swapped);
        }
        private void InsertionSort(DLLNode<T>? node)
        {
            if (node == null || node.next == null)
                return;

            DLLNode<T>? current = node.next;
            while (current != null)
            {
                DLLNode<T>? nextNode = current.next;

                DLLNode<T>? insertPosition = node;
                while (insertPosition != null && insertPosition != current && (insertPosition.data).CompareTo(current.data) < 0)
                {
                    insertPosition = insertPosition.next;
                }

                if (insertPosition != current)
                {
                    current.prev.next = current.next;
                    if (current.next != null)
                    {
                        current.next.prev = current.prev;
                    }

                    current.prev = insertPosition.prev;
                    current.next = insertPosition;
                    if (insertPosition.prev != null)
                    {
                        insertPosition.prev.next = current;
                    }
                    insertPosition.prev = current;
                }

                current = nextNode;
            }
        }
        private DLLNode<T>? Merge(DLLNode<T>? head, DLLNode<T>? tail)
        {
            DLLNode<T>? result=null;

            if (head == null)
                return tail;
            if (tail == null)
                return head;

            if ((head.data).CompareTo(tail.data) <= 0)
            {
                result = head;
                result.next = Merge(head.next, tail);
            }
            else
            {
                result = tail;
                result.next = Merge(head, tail.next);
                
            }
            result.next.prev = result;
            result.prev = null;

            return result;
        }
        private DLLNode<T> GetMiddle(DLLNode<T> node)
        {
            if (node == null)
                return node;

            DLLNode<T>? slow = node;
            DLLNode<T>? fast = node.next;

            while (fast!=null)
            {
                fast = fast.next;
                if(fast !=null) 
                {
                    slow = slow.next;
                    fast = fast.next;
                }
            }

            return slow;
        }
        private DLLNode<T>? MergeSort(DLLNode<T>? node)
        {
            if (node == null || node.next==null)
                return node;

            DLLNode<T> mid = GetMiddle(node);
            DLLNode<T>? nextToMiddle = mid.next;
            mid.next = null;

            DLLNode<T>? left = MergeSort(mid);
            DLLNode<T>? right = MergeSort(nextToMiddle);
            
            return Merge(left, right);
        }
        private DLLNode<T>? PartitionLast(DLLNode<T> head, DLLNode<T> tail)
        {
            if (head == tail || head == null || tail == null)
                return head;
            DLLNode<T> pivot_prev = head;
            DLLNode<T> curr = head;
            var pivot = tail.data;

            T temp;
            while (head != null && head != tail)
            {
                if (head.data.CompareTo(pivot) < 0)
                {
                    pivot_prev = curr;
                    temp = curr.data;
                    curr.data = head.data;
                    head.data = temp;
                    curr = curr.next;
                }
                head = head.next;
            }
            temp = curr.data;
            curr.data = pivot;
            tail.data = temp;

            return pivot_prev;
        }
        private void QuickSort(DLLNode<T>? head, DLLNode<T>? tail)
        {
            if (head == tail)
                return;
            DLLNode<T>? pivot_prev = PartitionLast(head, tail);
            QuickSort(head, pivot_prev);

            if (pivot_prev != null && pivot_prev == head)
                QuickSort(pivot_prev.next, tail);

            else if (pivot_prev != null && pivot_prev.next != null)
                QuickSort(pivot_prev.next.next, tail);
        }
        private void Sort(string type)
        {
            DLLNode<T>? tempNode = CopyLinkedList();
            Console.WriteLine($"{type} Sort.......");

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
                    //PrintDataInDataStructure(tempNode);
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
            //Sort("Bubble");
            //Sort("Insertion");
            //Sort("Merge");
            Sort("Quick");
        }

    }
}
