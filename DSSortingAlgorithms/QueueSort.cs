using DataStructureImplementation.DataStructures;

namespace DataStructureImplementation.DSSortingAlgorithms
{
    internal class QueueSort<T> where T : IComparable<T>
    {
        protected MyQueue<T> BubbleSort(MyQueue<T> myQueue)
        {
            int n = myQueue.Count;
            T[] tempArray = new T[n];

            for (int i = 0; i < n; i++)
            {
                tempArray[i] = myQueue.Front(); 
                myQueue.DeQueue();
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (tempArray[j].CompareTo(tempArray[j + 1]) > 0)
                    {
                        T temp = tempArray[j];
                        tempArray[j] = tempArray[j + 1];
                        tempArray[j + 1] = temp;
                    }
                }
            }

            MyQueue<T> sortedQueue = new MyQueue<T>();

            for (int i = 0; i < n; i++)
            {
                sortedQueue.EnQueue(tempArray[i]);
            }

            return sortedQueue;
        }
        protected MyQueue<T> InsertionSort(MyQueue<T> myQueue)
        {
            int n = myQueue.Count;
            T[] tempArray = new T[n];

            for (int i = 0; i < n; i++)
            {
                tempArray[i] = myQueue.Front();
                myQueue.DeQueue();
            }

            for (int i = 1; i < n; i++)
            {
                T key = tempArray[i];
                int j = i - 1;

                while (j >= 0 && tempArray[j].CompareTo(key) > 0)
                {
                    tempArray[j + 1] = tempArray[j];
                    j--;
                }

                tempArray[j + 1] = key;
            }

            MyQueue<T> sortedQueue = new MyQueue<T>();

            for (int i = 0; i < n; i++)
            {
                sortedQueue.EnQueue(tempArray[i]);
            }

            return sortedQueue;
        }
        protected MyQueue<T> MergeSort(MyQueue<T> myQueue)
        {
            if (myQueue.Count <= 1)
            {
                return myQueue;
            }

            MyQueue<T> leftQueue = new MyQueue<T>();
            MyQueue<T> rightQueue = new MyQueue<T>();
            int middle = myQueue.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                leftQueue.EnQueue(myQueue.DeQueue());
            }

            while (myQueue.Count > 0)
            {
                rightQueue.EnQueue(myQueue.DeQueue());
            }

            leftQueue = MergeSort(leftQueue);
            rightQueue = MergeSort(rightQueue);

            return Merge(leftQueue, rightQueue);
        }
        private MyQueue<T> Merge(MyQueue<T> leftQueue, MyQueue<T> rightQueue)
        {
            MyQueue<T> tempQueue = new MyQueue<T>();

            while (leftQueue.Count > 0 && rightQueue.Count > 0)
            {
                if (leftQueue.Front()?.CompareTo(rightQueue.Front()) < 0)
                {
                    tempQueue.EnQueue(leftQueue.DeQueue());
                }
                else
                {
                    tempQueue.EnQueue(leftQueue.DeQueue());
                }
            }

            while (leftQueue.Count > 0)
            {
                tempQueue.EnQueue(leftQueue.DeQueue());
            }

            while (rightQueue.Count > 0)
            {
                tempQueue.EnQueue(rightQueue.DeQueue());
            }

            return tempQueue;
        }
        protected void QuickSort(MyQueue<T> myQueue)
        {
            if (myQueue.Count <= 1)
            {
                return ;
            }

            T pivot = myQueue.DeQueue();
            MyQueue<T> left = new MyQueue<T>();
            MyQueue<T> right = new MyQueue<T>();

            while (myQueue.Count > 0)
            {
                T currentElement = myQueue.DeQueue();
                if (currentElement.CompareTo(pivot) < 0)
                {
                    left.EnQueue(currentElement);
                }
                else
                {
                    right.EnQueue(currentElement);
                }
            }

            QuickSort(left);
            QuickSort(right);

            myQueue.EnQueue(pivot);

            while (left.Count > 0)
            {
                myQueue.EnQueue(left.DeQueue());
            }
            while (right.Count > 0)
            {
                myQueue.EnQueue(right.DeQueue());
            }
        }

    }
}
