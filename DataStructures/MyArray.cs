using DataStructureImplementation.Enumerations;
using DataStructureImplementation.SortInterface;
using LinqToExcel;
using System.Diagnostics;

namespace DataStructureImplementation.DataStructures
{
    internal class MyArray<T> where T : IComparable<T>
    {
        private const int arraySize = 60000;
        private readonly T[] array = new T[arraySize];
        public MyArray()
        {
        }
        public void LoadDataInDataStructure(IEnumerable<T> records)
        {
            int i = 0;
            foreach(var record in records)
            {
                array[i++] = record;
            }
        }
        private void PrintDataStructure(T[] array)
        {
            foreach (var row in array)
            {
                Console.WriteLine(row.ToString());
            }
        }
        private void BubbleSort(T[] tempArray)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < arraySize - 1; i++)
            {
                for (int j = 0; j < arraySize - i - 1; j++)
                {
                    if (tempArray[j].CompareTo(tempArray[j + 1]) <= 0)
                    {
                        T temp = tempArray[j];
                        tempArray[j] = tempArray[j + 1];
                        tempArray[j + 1] = temp;
                    }
                }
            }
            //PrintDataStructure(tempArray);
        }
        private void InsertionSort(T[] tempArray)
        {
            for (int i = 1; i < arraySize; i++)
            {
                T key = tempArray[i];
                int j = i - 1;
                while (j >= 0 && key.CompareTo(tempArray[j]) > 0)
                {
                    tempArray[j + 1] = tempArray[j];
                    j--;
                }
                tempArray[j + 1] = key;
            }
            //PrintDataStructure(tempArray);
        }
        private void Merge(T[] tempArray, int left, int mid, int right)
        {
            int leftLength = mid - left + 1;
            int rightLength = right - mid;
            var leftTempArray = new T[leftLength];
            var rightTempArray = new T[rightLength];
            int i, j;

            for (i = 0; i < leftLength; i++)
                leftTempArray[i] = tempArray[i + left];
            for (j = 0; j < rightLength; j++)
                rightTempArray[j] = tempArray[mid + 1 + j];
            i = 0; j = 0;
            int k = left;

            while (i < leftLength && j < rightLength)
            {
                if (leftTempArray[i].CompareTo(rightTempArray[j]) <= 0)
                    tempArray[k++] = leftTempArray[i++];
                else
                    tempArray[k++] = rightTempArray[j++];
            }

            while (i < leftLength)
                tempArray[k++] = leftTempArray[i++];
            while (j < rightLength)
                tempArray[k++] = rightTempArray[j++];

            return;
        }
        private void MergeSort(T[] tempArray, int left, int right)
        {
            if (right <= left)
                return;

            int mid = left + (right - left) / 2;
            MergeSort(tempArray, left, mid);
            MergeSort(tempArray, mid + 1, right);

            Merge(tempArray, left, mid, right);
        }
        private int Pivot(T[] tempArray, int leftIndex, int rightIndex)
        {
            T pivot = tempArray[rightIndex];
            int i = (leftIndex - 1);
            T temp;
            for (int j = leftIndex; j <= rightIndex - 1; j++)
            {
                if (tempArray[j].CompareTo(pivot) <= 0)
                {
                    i++;
                    temp = tempArray[i];
                    tempArray[i] = tempArray[j];
                    tempArray[j] = temp;
                }
            }
            temp = tempArray[i+1];
            tempArray[i+1] = tempArray[rightIndex];
            tempArray[rightIndex] = temp;

            return (i + 1);
        }
        private void QuickSort(T[] tempArray, int leftIndex, int rightIndex)
        {
            if(leftIndex < rightIndex)
            {
                int pivot = Pivot(tempArray, leftIndex, rightIndex);
                QuickSort(tempArray, leftIndex, pivot-1);
                QuickSort(tempArray, pivot+1, rightIndex);
            }
        }
        private void CopyData(T[] tempArray)
        {
            int i = 0;
            foreach(var item in array)
            {
                tempArray[i++] = item;
            }
        }
        public void SortStructure()
        {
            T[] tempArray = new T[arraySize];
            CopyData(tempArray);
            Console.WriteLine("Bubble Sort.........");
            Stopwatch sw = Stopwatch.StartNew();

            BubbleSort(tempArray);
            
            sw.Stop();
            Console.WriteLine($"Time taken for Bubble sort : {sw.Elapsed}");

            CopyData(tempArray);
            sw.Reset();
            Console.WriteLine("Insertion Sort.......");
            sw.Start();
            InsertionSort(tempArray);
            sw.Stop();
            Console.WriteLine($"Time taken for Insertion sort : {sw.Elapsed}");

            CopyData(tempArray);
            sw.Reset();
            Console.WriteLine("Merge Sort.........");
            sw.Start();

            MergeSort(tempArray, 0, arraySize - 1);

            sw.Stop();
            Console.WriteLine($"Time taken for Merge sort : {sw.Elapsed}");

            CopyData(tempArray);
            sw.Reset();
            Console.WriteLine("Quick Sort....");
            sw.Start();
            QuickSort(tempArray, 0, arraySize - 1);
            sw.Stop();
            Console.WriteLine($"Time taken for Quick sort : {sw.Elapsed}");
            //PrintDataStructure(tempArray);
        }

    }
}
