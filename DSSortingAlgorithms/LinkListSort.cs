using DataStructureImplementation.DataStructures;

namespace DataStructureImplementation.DSSortingAlgorithms
{
    internal class LinkListSort<T> where T : IComparable<T>
    {
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
        protected void BubbleSort(SLLNode<T>? node)
        {
            if (node == null)
            {
                Console.WriteLine("Empty Linked List");
                return;
            }

            bool IsSwapped;
            do
            {
                IsSwapped = false;
                SLLNode<T>? current = node;
                while (current != null && current.next != null)
                {
                    if (current.data.CompareTo(current.next.data) > 0)
                    {
                        T temp = current.data;
                        current.data = current.next.data;
                        current.next.data = temp;
                        IsSwapped = true;
                    }
                    current = current.next;
                }
            } while (IsSwapped);
        }
        protected void InsertionSort(SLLNode<T>? node)
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
        protected SLLNode<T>? MergeSort(SLLNode<T>? node)
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
        protected void QuickSort(SLLNode<T>? head, SLLNode<T>? tail)
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
       
    }
}
