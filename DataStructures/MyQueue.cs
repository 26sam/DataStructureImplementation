using System.Diagnostics;
using System.Drawing;
using DataStructureImplementation.DSSortingAlgorithms;

namespace DataStructureImplementation.DataStructures
{
    internal class MyQueue<T> : QueueSort<T>
        where T : IComparable<T>
    {
        private Stopwatch stopWatch = new Stopwatch();
        private int _startIndex, _endIndex, _maxQueueSize;
        private T[] _myQueue;
        public int Count { get; private set; }
        internal MyQueue()
        {
            _startIndex = 0;
            _endIndex = -1;
            _maxQueueSize = 60000;
            _myQueue = new T[_maxQueueSize];
        }
        internal void EnQueue(T element)
        {
            if (_endIndex == _maxQueueSize)
            {
                _maxQueueSize *= 2;
                Array.Resize(ref _myQueue, _maxQueueSize);
            }
            Count++;
            _myQueue[++_endIndex] = element;
        }
        internal T DeQueue()
        {
            if (_startIndex < _endIndex)
            {
                Count--;
                T front = _myQueue[_startIndex];
                _myQueue[_startIndex++] = default;
                return front;
            }
            else if(_startIndex == _endIndex)
            {
                Count--;
                T front = _myQueue[_startIndex];
                _myQueue[_startIndex] = default;

                _startIndex = 0;
                _endIndex = -1;
                return front;
            }
            Console.WriteLine("Queue is Empty");
            return default;
        }
        internal T Front()
        {
            if (_startIndex > _endIndex)
            {
                return default;
            }
            return _myQueue[_startIndex];
        }
        internal void LoadDataInDataStructure(IEnumerable<T> records)
        {
            foreach(var record in records)
            {
                EnQueue(record);
            }
        }
        internal void PrintDataStructure()
        {
            foreach(var item in _myQueue)
            {
                Console.WriteLine(item.ToString());
            }
        }
        private MyQueue<T> CopyQueue()
        {
            MyQueue<T> queue = new MyQueue<T>();
            foreach(var item in _myQueue)
                queue.EnQueue(item);
            return queue;
        }
        private void Sort(string type)
        {
            MyQueue<T> tempQueue = CopyQueue();

            switch (type)
            {
                case "Bubble":
                    stopWatch.Start();
                    BubbleSort(tempQueue);
                    stopWatch.Stop();
                    Console.WriteLine($"Time taken by Bubble Sort {stopWatch.Elapsed}");
                    break;

                case "Insertion":
                    stopWatch.Start();
                    InsertionSort(tempQueue);
                    stopWatch.Stop();
                    Console.WriteLine($"Time taken by Insertion Sort {stopWatch.Elapsed}");
                    break;

                case "Merge":
                    stopWatch.Start();
                    MergeSort(tempQueue);
                    Console.WriteLine($"Time taken by Merge Sort {stopWatch.Elapsed}");
                    break;

                case "Quick":
                    stopWatch.Start();
                    QuickSort(tempQueue);
                    Console.WriteLine($"Time taken by Quick Sort {stopWatch.Elapsed}");
                    break;

                default:
                    Console.WriteLine("No such Algorithm is Implemented.....");
                    break;
            }

            stopWatch.Reset();
        }
        internal void SortDataStructure()
        {
            Sort("Bubble");
            Sort("Insertion");
            Sort("Merge");
            Sort("Quick");
        }
    }
}
