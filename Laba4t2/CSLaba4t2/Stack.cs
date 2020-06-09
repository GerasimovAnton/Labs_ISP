using System;

namespace mystack
{
    unsafe public struct Stack
    {
        private const int capacity = 512;
        private fixed int array[capacity];
        private int size;

        public int Size { get => size; }

        public void Push(int data)
        {
            if (size < capacity)
                array[size++] = data;
            else throw new Exception("Stack overflow");
        }


        public int Pop()
        {
            return size == 0 ? 0 : array[size--];
        }


        public int Top()
        {
            return size == 0 ? 0 : array[size - 1];
        }


        public void Clear()
        {
            for (int i = 0;i <capacity;i++)
            Pop();
        }
    }
}
