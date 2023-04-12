namespace DataStructureImplementation.DataStructures
{
    internal class MyStack<T> where T: IComparable<T>
    {
        private int _curIndex, _maxStackSize;
        private T[]? _myStack;
        public MyStack()
        {
            _curIndex = -1;
            _maxStackSize = 60000;
            _myStack = new T[_maxStackSize];
        }
        private void PushIntoStack(T element)
        {
            if (_curIndex == _maxStackSize)
            {
                _maxStackSize *= 2;
                Array.Resize(ref _myStack, _maxStackSize);
            }
            _myStack[++_curIndex] = element;
        }
        private void PopFromStack()
        {
            if (_curIndex == -1)
            {
                Console.WriteLine("Your Stack is Empty");
                return;
            }
            if (_curIndex >= 0)
            {
                _curIndex--;
            }
        }
        private void TopOfStack()
        {
            if (_curIndex == -1)
            {
                Console.WriteLine("Your Stack is Empty");
                return;
            }
            else
            {
                Console.WriteLine(_myStack[_curIndex]);
            }
        }

        public void LoadDataInDataStructure(IEnumerable<T> records)
        {
            foreach(var record in records) 
            {
                PushIntoStack(record);
            }

        }
        public void PrintDataStructure()
        {
            foreach(var item in _myStack)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
