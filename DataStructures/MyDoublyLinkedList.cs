using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureImplementation.DataStructures
{
    internal class MyDoublyLinkedList<T> where T : IComparable<T>
    {
        private DLLNode<T> _head;
        public MyDoublyLinkedList()
        {
            _head = null;
        }
        DLLNode<T> GetLastNode()
        {
            DLLNode<T> tempNode = _head;
            while (tempNode.next != null)
            {
                tempNode = tempNode.next;
            }
            return tempNode;
        }
        private void InsertFront(T data)
        {
            DLLNode<T>? newNode = new DLLNode<T>(data);
            newNode.next = _head;
            newNode.prev = null;
            
            if(_head!=null)
                _head.prev = newNode;

            _head = newNode;
        }

        private void InsertEnd(T data)
        {
            DLLNode<T> newNode = new DLLNode<T>(data);
            if (_head == null)
            {
                newNode.prev = null;
                _head = newNode;
                return;
            }
            DLLNode<T> lastNode = GetLastNode();
            lastNode.next = newNode;
            newNode.prev = lastNode;
        }

        public void LoadDataInDataStructure(IEnumerable<T> records)
        {
            foreach (var record in records)
            {
                InsertEnd(record);
            }
        }

        public void PrintDataInDataStructure()
        {
            DLLNode<T>? tempNode = _head;
            while (tempNode != null)
            {
                Console.WriteLine(tempNode.data.ToString());
                tempNode = tempNode.next;
            }
        }
    }
}
