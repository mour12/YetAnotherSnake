using System;
using System.Collections;
using System.Collections.Generic;

namespace Snake.Utilities
{
    internal sealed class Deque<T> : IEnumerable<T>, IEnumerator<T>
    {
        private sealed class Node
        {
            public T Data { get; }
            public Node Prev { get; set; }
            public Node Next { get; set; }

            public Node(T data, Node prev = null, Node next = null)
            {
                Data = data;
                Prev = prev;
                Next = next;
            }
        }

        private Node _currentNode;

        private Node _head;
        private Node _tail;

        public void PushFront(T data)
        {
            if (_head == null)
            {
                _head = new Node(data);
                _tail = _head;
            }
            else
            {
                var newHead = new Node(data, next: _head);
                _head.Prev = newHead;
                _head = newHead;
            }
        }

        public T PeekFront()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Deque is empty.");
            }
            return _head.Data;
        }

        public T PopFront()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Deque is empty.");
            }
            
            var data = _head.Data;
            
            _head = _head.Next;
            if (_head != null)
            {
                _head.Prev = null;
            }
            else
            {
                _tail = null;
            }
            
            return data;
        }

        public void PushBack(T data)
        {
            if (_tail == null)
            {
                _tail = new Node(data);
                _head = _tail;
            }
            else
            {
                var newTail = new Node(data, prev: _tail);
                _tail.Next = newTail;
                _tail = newTail;
            }
        }

        public T PeekBack()
        {
            if (_tail == null)
            {
                throw new InvalidOperationException("Deque is empty.");
            }
            return _tail.Data;
        }

        public T PopBack()
        {
            if (_tail == null)
            {
                throw new InvalidOperationException("Deque is empty.");
            }
            
            var data = _tail.Data;
            
            _tail = _tail.Prev;
            if (_tail != null)
            {
                _tail.Next = null;
            }
            else
            {
                _head = null;
            }

            return data;
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            _currentNode = _currentNode == null ? _head : _currentNode.Next;
            return (_currentNode != null);
        }

        public void Reset()
        {
            _currentNode = _head;
        }

        public T Current => _currentNode.Data;

        object IEnumerator.Current => Current;
        
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}