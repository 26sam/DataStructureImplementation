using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureImplementation.DataStructures
{
    internal class MyLinkedList<T> where T: IComparable<T>
    {
        private SLLNode<T> _head;
        public MyLinkedList()
        {
            _head = null;
        }
        SLLNode<T> GetLastNode()
        {
            SLLNode<T> tempNode = _head;
            while(tempNode.next != null)
            {
                tempNode = tempNode.next;
            }
            return tempNode;
        }
        private void InsertFront(T data)
        {
            SLLNode<T>? newNode = new SLLNode<T>(data);
            newNode.next = _head;
            _head = newNode;
        }

        private void InsertEnd(T data)
        {
            if(_head == null)
            {
                _head = new SLLNode<T>(data);
                return;
            }
            SLLNode<T> lastNode = GetLastNode();
            lastNode.next = new SLLNode<T>(data);
        } 

        public void LoadDataInDataStructure(IEnumerable<T> records)
        {
            foreach(var record in records)
            {
                InsertEnd(record);
            }
        }

        public void PrintDataInDataStructure()
        {
            SLLNode<T>? tempNode = _head;
            while(tempNode!=null)
            {
                Console.WriteLine(tempNode.data.ToString());
                tempNode = tempNode.next;
            }
        }
    }
}
