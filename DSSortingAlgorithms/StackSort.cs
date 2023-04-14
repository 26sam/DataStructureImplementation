using DataStructureImplementation.DataStructures;

namespace DataStructureImplementation.DSSortingAlgorithms
{
    internal class StackSort<T> where T : IComparable<T>
    {
        protected void BubbleSort(MyStack<T> myStack)
        {
            MyStack<T> tempStack = new MyStack<T>();
            for (int i = 0; i < myStack.Count; i++)
            {
                for (int j = 0; j < myStack.Count - i - 1; j++)
                {
                    T firstElement = myStack.PopFromStack();
                    T secondElement = myStack.PopFromStack();

                    if (firstElement.CompareTo(secondElement) >= 0)
                    {
                        tempStack.PushIntoStack(firstElement);
                        myStack.PushIntoStack(secondElement);
                    }
                    else
                    {
                        tempStack.PushIntoStack(firstElement);
                        myStack.PushIntoStack(firstElement);
                    }
                }
                while (tempStack.Count > 0)
                {
                    myStack.PushIntoStack(tempStack.PopFromStack());
                }
            }
        }
        protected void InsertionSort(MyStack<T> stack)
        {
            MyStack<T> tempStack = new MyStack<T>();

            while (stack.Count > 0)
            {
                T current = stack.Top();
                stack.PopFromStack();

                while (tempStack.Count > 0 && tempStack.Top().CompareTo(current) > 0)
                {
                    stack.PushIntoStack(tempStack.Top());
                    tempStack.PopFromStack();
                }

                tempStack.PushIntoStack(current);
            }
        }
        protected void MergeSort(MyStack<T> myStack)
        {
            if (myStack.Count <= 1)
                return;

            int mid = myStack.Count / 2;

            MyStack<T> leftStack = new MyStack<T>();
            MyStack<T> right = new MyStack<T>();

            for (int i = 0; i < mid; i++)
                leftStack.PushIntoStack(myStack.PopFromStack());

            while (myStack.Count > 0)
                right.PushIntoStack(myStack.PopFromStack());

            MergeSort(leftStack);
            MergeSort(right);

            while (leftStack.Count > 0 && right.Count > 0)
            {
                if (leftStack.Top().CompareTo(right.Top()) < 0)
                    myStack.PushIntoStack(leftStack.PopFromStack());
                else
                    myStack.PushIntoStack(right.PopFromStack());
            }

            while (leftStack.Count > 0)
                myStack.PushIntoStack(leftStack.PopFromStack());

            while (right.Count > 0)
                myStack.PushIntoStack(right.PopFromStack());
        }
        protected void QuickSort(MyStack<T> myStack)
        {
            if (myStack.Count < 2) 
                return;

            T pivot = myStack.PopFromStack();
            MyStack<T> leftStack = new MyStack<T>();
            MyStack<T> rightStack = new MyStack<T>();

            while (myStack.Count > 0)
            {
                T presentElement = myStack.PopFromStack();
                if (presentElement.CompareTo(pivot) <= 0)
                {
                    leftStack.PushIntoStack(presentElement);
                }
                else
                {
                    rightStack.PushIntoStack(presentElement);
                }
            }

            QuickSort(leftStack);
            QuickSort(rightStack);

            while(myStack.Count > 0)
            {
                myStack.PopFromStack();
            }
            while (rightStack.Count > 0)
            {
                myStack.PushIntoStack(rightStack.PopFromStack());
            }
            myStack.PushIntoStack(pivot);
            while (leftStack.Count > 0)
            {
                myStack.PushIntoStack(leftStack.PopFromStack());
            }
        }
    }
}