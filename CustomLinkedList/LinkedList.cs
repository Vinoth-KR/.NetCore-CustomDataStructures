using System;

namespace CustomLinkedList
{
    public class LinkedList<T>
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        public LinkedList()
        {
            this.m_Count = 0;
            this._head = null;
        }

        public Node<T> Head { get => _head; }
        public Node<T> Last { get => GetLastNode(); }
       
        public int Count {get => m_Count; }

        private int m_Count;
        private Node<T> _head;

        /// <summary>
        /// Getting Last Node of the LinkedList
        /// </summary>
        /// <returns></returns>
        private Node<T> GetLastNode()
        {
            if (_head == null) return null;

            Node<T> node = _head;
            while(node.Next != null)
            {
              node = node.Next;     
            }

            return node;
        }

        #region BasicMethods
        /// <summary>
        /// Adding new node after the specified node
        /// </summary>
        /// <param name="node">Node after which the new node to be added</param>
        /// <param name="value">Value of the new node to be added</param>
        /// <returns>Returns the new node added</returns>
        public Node<T> AddAfter(Node<T> node, T value)
        {
            var valueNode = new Node<T>(value);
            node.Next = valueNode;
            m_Count++;

            return valueNode;
        }

        /// <summary>
        /// Adding new node after the specified node
        /// </summary>
        /// <param name="node">Node after which the new node to be added</param>
        /// <param name="valueNode">New node to be added</param>
        /// <returns>Returns the new node added to the LinkedList</returns>
        public Node<T> AddAfter(Node<T> node, Node<T> valueNode)
        {
            valueNode.Next = node.Next;
            node.Next = valueNode;
            m_Count++;

            return valueNode;
        }

        /// <summary>
        /// Adding the node at the end of the LinkedList
        /// </summary>
        /// <param name="value">Value of the node to be added</param>
        /// <returns>Returns the newly added node</returns>
        public Node<T> AddLast(T value)
        {
            var valueNode = new Node<T>(value);

            if (null == _head) _head = valueNode;

            else
            {
                var node = GetLastNode();
                node.Next = valueNode;
            }

            m_Count++;
            return valueNode;
        }

        /// <summary>
        /// Adding the node at the end of the LinkedList
        /// </summary>
        /// <param name="valueNode">New Node to be added</param>
        /// <returns>Returns the newly added node</returns>
        public Node<T> AddLast(Node<T> valueNode)
        {
            if (null == _head) _head = valueNode;

            else
            {
                var node = GetLastNode();
                node.Next = valueNode;
            }

            m_Count++;
            return valueNode;
        }

        /// <summary>
        /// Deletes the node after specified node
        /// </summary>
        /// <param name="node">Node after which the deletion to be performed</param>
        /// <returns>Returns true if deletion is successful, false if no node to delete</returns>
        public bool DeleteAfter(Node<T> node)
        {
            var nextNode = node.Next;
            if (null == nextNode) return false; // nothing to delete

            node.Next = nextNode.Next;
            m_Count--;
            return true;
        }

        /// <summary>
        /// Returns the First node which contains the specified value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node<T> Find(T value)
        {
            Node<T> previous = null;
            Node<T> current = _head;

            if (current == null) return null;
            if (current.Value.Equals(value)) return _head;

            do
            {
                previous = current;
                current = current.Next;

                if (current.Value.Equals(value)) return (current);

            } while (current.Next != null);

            return null;
        }

        /// <summary>
        /// Returns Boolean based on the whether the value is available in the LinkedList
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if value is found in the LinkedList otherwise,
        //     false.</returns>
        public bool Contains(T value)
        {
            var node = _head;
            while (node != null)
            {
                if (node.Value.Equals(value)) return true;
            }
            return false;
        }

        /// <summary>
        /// Clears the LinkedList Nodes
        /// </summary>
        public void Clear()
        {
            _head = null;
            m_Count = 0;
        }
        #endregion

        #region AdvancedAlgorithms
        
        /// <summary>
        /// Reverses the LinkedList inline - without use of any data structure
        /// </summary>
        /// <returns>Returns the head of the LinkedList after reversal</returns>
        public Node<T> Reverse()
        {
            Node<T> previous = null;
            Node<T> current = _head;
            Node<T> next = null;

            while(current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;                               
            }
            _head = previous;

            return _head;
        }
        
        /// <summary>
        /// Used to find if the LinkedList is having a cyclic loop
        /// </summary>
        /// <returns>Returns true if the LinkedList have cycles, false otherwise</returns>
        public bool HasCycle()
        {
            return GetNodeInCycle() != null;
        }
        
        /// <summary>
        /// Gets the Node in the Loop Cycle.
        /// </summary>
        /// <returns>Returns the node where the Loop is identified</returns>
        private Node<T> GetNodeInCycle()
        {
            var fastPointer = _head;
            var slowPointer = _head;

            while (null != fastPointer.Next && null != fastPointer.Next.Next)
            {
                fastPointer = fastPointer.Next.Next;

                slowPointer = slowPointer.Next;
                if (fastPointer == slowPointer) return slowPointer;
            }

            return null;
        }

        /// <summary>
        /// Getting the Cyclic Nodes in the LinkedList
        /// </summary>
        /// <returns>Returns a tuple of two Node<T>, the Node causing the Loop and the Node which starts the Loop</T></returns>
        public (Node<T> previous, Node<T> cycle) GetCycleNodes() 
        {
            Node<T> node = GetNodeInCycle();

            if (null == node) return (null, null);

            //get the size of the loop
            int size = 1;
            Node<T> slidingNode = node;

            while (slidingNode.Next != node)
            {
                slidingNode = slidingNode.Next;
                size++;
            }

            Node<T> first = _head;
            Node<T> previous = _head;
            Node<T> second = _head;

            for (int i = 0; i < size; i++)
            {
                if (i != 0) previous = previous.Next;
                second = second.Next;
            }

            while (first != second)
            {
                first = first.Next;
                second = second.Next;
                previous = previous.Next;
            }

            return (previous, second);
        }

        /// <summary>
        /// Returns the Middle Element of the LinkedList
        /// </summary>
        /// <returns>Returns the Middle Node</returns>
        public Node<T> FindMiddleElement()
        {
            Node<T> fast = _head;
            Node<T> slow = _head;

            while (fast.Next != null && fast.Next.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }

            return slow;
        }
        #endregion
    }



    public class Node<T>
    {
        public Node<T> Next { get; set; }

        public T Value { get; set; }

        public Node(T value, Node<T> next = null)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}
