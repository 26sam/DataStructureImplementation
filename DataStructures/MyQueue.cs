namespace DataStructureImplementation.DataStructures
{
    internal class MyQueue<T> where T : IComparable<T>
    {
        private int _startIndex, _endIndex, _maxQueueSize;
        private T[] _myQueue;
        public MyQueue()
        {
            _startIndex = 0;
            _endIndex = -1;
            _maxQueueSize = 60000;
            _myQueue = new T[_maxQueueSize];
        }
        private void EnQueue(T element)
        {
            if (_endIndex == _maxQueueSize)
            {
                _maxQueueSize *= 2;
                Array.Resize(ref _myQueue, _maxQueueSize);
            }
            _myQueue[++_endIndex] = element;
            //Console.WriteLine(_myQueue[_endIndex].ToString());
        }
        private void DeQueue()
        {
            if (_startIndex > _endIndex)
            {
                Console.WriteLine("Queue is Empty");
                return;
            }
            _startIndex++;
        }
        private void FrontElementOfQueue()
        {
            if (_startIndex > _endIndex)
            {
                Console.WriteLine("Queue is Empty");
                return;
            }
            else
            {
                Console.WriteLine(_myQueue[_startIndex]);
            }
        }

        public void LoadDataInDataStructure(IEnumerable<T> records)
        {
            foreach(var record in records)
            {
                EnQueue(record);
                
            }
        }

        public void PrintDataStructure()
        {
            foreach(var item in _myQueue)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
