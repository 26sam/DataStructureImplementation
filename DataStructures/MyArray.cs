using System.Diagnostics;
using DataStructureImplementation.DSSortingAlgorithms;

namespace DataStructureImplementation.DataStructures
{
    internal class MyArray<T> : ArraySort<T>
        where T : IComparable<T>
    {
        private Stopwatch stopWatch = new Stopwatch();
        private int arraySize = 60000;
        private readonly T[] array;
        internal MyArray()
        {
            array = new T[arraySize];
        }
        internal MyArray(int arraySize)
        {
            this.arraySize = arraySize;
            array = new T[this.arraySize];
        }
        internal void Insert(int index, T item)
        {
            array[index] = item;
        }
        internal void LoadDataInDataStructure(IEnumerable<T> records)
        {
            int i = 0;
            foreach(var record in records)
            {
                Insert(i++, record);
            }
        }
        private T[] CopyData()
        {
            T[] tempArray = new T[arraySize];
            int i = 0;
            foreach(var item in array)
            {
                tempArray[i++] = item;
            }
            return tempArray;
        }
        private void Sort(string type)
        {
            T[] tempArray = CopyData();

            switch (type)
            {
                case "Bubble":
                    stopWatch.Start();
                    BubbleSort(tempArray);
                    stopWatch.Stop();
                    Console.WriteLine($"Time taken by Bubble Sort {stopWatch.Elapsed}");
                    break;

                case "Insertion":
                    stopWatch.Start();
                    InsertionSort(tempArray);
                    stopWatch.Stop();
                    Console.WriteLine($"Time taken by Insertion Sort {stopWatch.Elapsed}");
                    break;

                case "Merge":
                    stopWatch.Start();
                    MergeSort(tempArray,0,arraySize-1);
                    Console.WriteLine($"Time taken by Merge Sort {stopWatch.Elapsed}");
                    break;

                case "Quick":
                    stopWatch.Start();
                    QuickSort(tempArray,0,arraySize-1);
                    Console.WriteLine($"Time taken by Quick Sort {stopWatch.Elapsed}");
                    break;

                default:
                    Console.WriteLine("No such Algorithm is Implemented.....");
                    break;
            }

            stopWatch.Reset();
        }
        internal void SortStructure()
        {
            Sort("Bubble");
            Sort("Insertion");
            Sort("Merge");
            Sort("Quick");
        }

    }
}
