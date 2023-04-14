using DataStructureImplementation.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureImplementation.DSSortingAlgorithms
{
    internal class DLLSort<T> where T : IComparable<T>
    {
        protected void BubbleSort(DLLNode<T>? node)
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
                while (curr.next != null && curr.next != last)
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
        protected void InsertionSort(DLLNode<T>? node)
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
            DLLNode<T>? result = null;

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

            while (fast != null)
            {
                fast = fast.next;
                if (fast != null)
                {
                    slow = slow.next;
                    fast = fast.next;
                }
            }

            return slow;
        }
        protected DLLNode<T>? MergeSort(DLLNode<T>? node)
        {
            if (node == null || node.next == null)
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
        protected void QuickSort(DLLNode<T>? head, DLLNode<T>? tail)
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
    }
}
