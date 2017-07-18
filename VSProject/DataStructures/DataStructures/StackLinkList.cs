using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class StackLinkList <T>
    {
        private LinkedList<T> _stack = new LinkedList<T>();
        
        public void Push (T value)
        {
            _stack.AddFirst(value);           
        }

        public T Pop()
        {
            return _stack.RemoveFirst();          
        }

        public T Peek()
        {
            if (_stack.Head == null)
            { 
                Console.WriteLine("Empty Stack");
                return default(T);
            }

            return _stack.Head.Value;
        }

        public int Count()
        {
            return _stack.Count;
        }

        public void Clear()
        {
            _stack.Clear();
        }

        public void PrintStackItems()
        {
            _stack.PrintList();
        }        

        public void PrintStackItemsReverse()
        {
            if (_stack.Head == null)
            {
                Console.WriteLine("Stack Empty");
                return;
            }         

                //for (int i = 0; i < _size; i++)
                //{
                //    Console.Write(_array[i]);
                //    if (i < _size - 1)
                //        Console.Write(",");
                //    else
                //        Console.WriteLine();
                //}     

                LinkedList<T>.PrintListReverse(_stack.Head);
        }

        public static void Demo()
        {
            var stack = new StackLinkList<object>();
            //Console.WriteLine(stack.Peek());
            //Console.WriteLine(stack.Pop());
            stack.Push(1);
            stack.Push("Basant");
            stack.Push(3);
            stack.Push(4);
            stack.PrintStackItems();
            Console.WriteLine("printing reverse");
            stack.PrintStackItemsReverse();
            Console.WriteLine("printing reverse completed");
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
