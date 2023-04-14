namespace DataStructureImplementation.DataStructures
{
    internal class SLLNode<T> where T : IComparable<T>
    {
        internal T data;
        internal SLLNode<T>? next;
        internal SLLNode(T data)
        {
            this.data = data;
            next = null;
        }
    }
    internal class DLLNode<T> where T : IComparable<T>
    {
        internal T data;
        internal DLLNode<T>? prev;
        internal DLLNode<T>? next;
        internal DLLNode(T data)
        {
            this.data = data;
            prev = null;
            next = null;
        }
    }
}