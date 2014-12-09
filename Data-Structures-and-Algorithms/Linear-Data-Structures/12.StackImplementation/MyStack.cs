namespace _12.StackImplementation
{
    using System;
    using System.Collections.Generic;

    public class MyStack<T> : IEnumerable<T>
    {
        private const int INITIAL_CAPACITY = 4;
        private T[] arr;
        private int pointer;

        public MyStack(int capacity = INITIAL_CAPACITY)
        {
            this.arr = new T[capacity];
            this.pointer = -1;
        }

        public int Count
        {
            get
            {
                return this.pointer + 1;
            }
        }

        public void Push(T value)
        {
            this.pointer++;
            GrowIfArrIsFull();
            this.arr[this.pointer] = value;
        }

        public T Peek()
        {
            if (this.pointer < 0)
            {
                throw new InvalidOperationException("Cannot take values grom empty stack!");
            }

            return this.arr[this.pointer];
        }

        public T Pop()
        {
            if (this.pointer < 0)
            {
                throw new InvalidOperationException("Cannot take values grom empty stack!");
            }

            T value = this.arr[this.pointer];
            this.arr[this.pointer] = default(T);
            this.pointer--;

            return value;
        }

        public void Clear()
        {
            this.arr = new T[INITIAL_CAPACITY];
            this.pointer = -1;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.arr.Length; i++)
            {
                if (object.Equals(item, this.arr[i]))
                {
                    return true;
                }
            }

            return false;
        }

        private void GrowIfArrIsFull()
        {
            if (this.Count + 1 > this.arr.Length)
            {
                T[] extendedArr = new T[this.arr.Length * 2];
                Array.Copy(this.arr, extendedArr, this.Count);
                this.arr = extendedArr;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.arr[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
