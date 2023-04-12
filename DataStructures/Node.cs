namespace DataStructureImplementation.DataStructures
{
    internal class SLLNode<T> where T : IComparable<T>
    {
        public T data;
        public SLLNode<T>? next;
        public SLLNode(T data)
        {
            this.data = data;
            next = null;
        }
    }
    internal class DLLNode<T> where T : IComparable<T>
    {
        public T data;
        public DLLNode<T>? prev;
        public DLLNode<T>? next;
        public DLLNode(T data)
        {
            this.data = data;
            prev = null;
            next = null;
        }
    }
}