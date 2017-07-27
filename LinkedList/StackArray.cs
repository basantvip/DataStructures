using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class StackArray <T>
    {
        private T[] _array = new T[0];
        private int _size = 0;
        public void Push (T value)
        {
            if (_array.Length == _size)
            {
                int NewLength;
                if (_size == 0)
                    NewLength = 10;
                else
                    NewLength = _size * 2;

                var ArrayTemp = new T[NewLength];
                _array.CopyTo(ArrayTemp, 0);
                _array = ArrayTemp;                
            }
            _array[_size++] = value;
        }

        public T Pop()
        {
            if (_size == 0)
            {
                Console.WriteLine("Empty Stack");
                return default(T);
            }

            return _array[--_size];            
        }

        public T Peek()
        {
            if (_size == 0)
            {
                Console.WriteLine("Empty Stack");
                return default(T);
            }

            return _array[_size-1];
        }

        public int Count()
        {
            return _size;
        }

        public void Clear()
        {
            _size = 0;
            _array = new T[0];
        }

        public void PrintStackItems()
        {
            if (_size == 0)
            {
                Console.WriteLine("Stack Empty");
                return;
            }
            
            for (int i = _size-1; i >= 0; i--)
            {
                Console.Write(_array[i]);
                if (i > 0)
                    Console.Write(",");
                else
                    Console.WriteLine();
            }
        }

        public void PrintStackItemsReverse()
        {
            if (_size == 0)
            {
                Console.WriteLine("Stack Empty");
                return;
            }

            for (int i = 0; i < _size; i++)
            {
                Console.Write(_array[i]);
                if (i < _size - 1)
                    Console.Write(",");
                else
                    Console.WriteLine();
            }            
        }

        public static void Demo()
        {
            var stack = new StackArray<int>();
            //Console.WriteLine(stack.Peek());
            //Console.WriteLine(stack.Pop());
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.PrintStackItems();
            stack.PrintStackItemsReverse();
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            stack.Push(10);
            stack.Push(21);
            stack.Push(31);
            Console.WriteLine(stack.Pop());
            Console.WriteLine($"Count: {stack.Count()}");
            stack.Clear();
            Console.WriteLine(stack.Pop());
        }
    }
}
