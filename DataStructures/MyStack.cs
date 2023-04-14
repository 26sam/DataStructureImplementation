using DataStructureImplementation.DSSortingAlgorithms;
using System.Diagnostics;

namespace DataStructureImplementation.DataStructures
{
    internal class MyStack<T> : StackSort<T> 
        where T: IComparable<T>
    {
        private Stopwatch stopWatch = new Stopwatch();
        private int _curIndex, _maxStackSize;
        private T[]? _myStack;
        internal int Count { get; private set; }
        internal MyStack()
        {
            _curIndex = -1;
            _maxStackSize = 60000;
            _myStack = new T[_maxStackSize];
        }
        internal void PushIntoStack(T data)
        {
            if (_curIndex >= _maxStackSize)
            {
                _maxStackSize *= 2;
                Array.Resize(ref _myStack, _maxStackSize);
            }
            Count++;
            _myStack[++_curIndex] = data;
        }
        internal T PopFromStack()
        {
            if (_curIndex == -1)
            {
                Console.WriteLine("Stack is Empty");
                return default;
            }
            T data = _myStack[_curIndex];
            _myStack[_curIndex--] = default;
            Count--;

            return data;
        }
        internal T Top()
        {
            if (_curIndex == -1)
            {
                Console.WriteLine("Stack is Empty");
                return default;
            }
            T record = _myStack[_curIndex];
            return record;
        }
        internal void LoadDataInDataStructure(IEnumerable<T> records)
        {
            foreach(var record in records) 
            {
                PushIntoStack(record);
            }

        }
        internal void PrintDataStructure()
        {
            foreach(var item in _myStack)
            {
                Console.WriteLine(item.ToString());
            }
        }
        internal bool IsEmpty()
        {
            return _curIndex == -1;
        }
        internal void SortDataStructure()
        {
            Sort("Bubble");
            Sort("Insertion");
            Sort("Merge");
            Sort("Quick");
        }
        private void Sort(string type)
        {
            MyStack<T> tempStack = CopyStack();

            switch (type)
            {
                case "Bubble":
                    stopWatch.Start();
                    BubbleSort(tempStack);
                    stopWatch.Stop();
                    Console.WriteLine($"Time taken by Bubble Sort {stopWatch.Elapsed}");
                    break;

                case "Insertion":
                    stopWatch.Start();
                    InsertionSort(tempStack);
                    stopWatch.Stop();
                    Console.WriteLine($"Time taken by Insertion Sort {stopWatch.Elapsed}");
                    break;

                case "Merge":
                    stopWatch.Start();
                    MergeSort(tempStack);
                    Console.WriteLine($"Time taken by Merge Sort {stopWatch.Elapsed}");
                    break;

                case "Quick":
                    stopWatch.Start();
                    QuickSort(tempStack);
                    Console.WriteLine($"Time taken by Quick Sort {stopWatch.Elapsed}");
                    break;

                default:
                    Console.WriteLine("No such Algorithm is Implemented.....");
                    break;
            }

            stopWatch.Reset();
        }
        private MyStack<T> CopyStack()
        {
            MyStack<T> stack = new MyStack<T>();
            foreach(var item in _myStack)
            {
                stack.PushIntoStack(item);
            }
            return stack;
        }
    }
}
