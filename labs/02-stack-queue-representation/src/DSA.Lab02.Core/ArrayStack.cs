using System;
using System.Linq;

namespace DSA.Lab02
{
    public sealed class ArrayStack<T>
    {
        private readonly T[] _items;
        private int _count;

        public ArrayStack(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = new T[capacity];
        }

        public int Count => _count;
        public int Capacity => _items.Length;

        public void Push(T item)
        {
            // TODO: place the item at the logical top and update the state.
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (_items.Length == _count)
            {
                throw new InvalidOperationException();
            }

            int arraySize = _items.Length;
            _items[_count] = item;
            _count++;
        }
        
        public T Peek()
        {
            // TODO: return the logical top without removing it.
            if (_items.Length == 0 | _count == 0)
            {
                throw new InvalidOperationException();
            }
            
            return _items[_count - 1];
        }

        public T Pop()
        {
            // TODO: remove and return the logical top.
            if (_items.Length == 0 | _count == 0)
            {
                throw new InvalidOperationException();
            }

            var top = _items[_count - 1];
            _items [_count] = default(T);
            _count--;
            return top;
        }
    }
}
