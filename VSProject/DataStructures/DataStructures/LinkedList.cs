﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    using System.Collections;

    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node()
        {
            
        }

        public Node(T value):this()
        {
            this.Value = value;
        }

        public Node(T value, Node<T> next): this(value)
        {
            this.Next = next;
        }

        public override string ToString()
        {
            if (this.Value == null)
                return "";

            var returnValue = this.Value.ToString();
            if (this.Next != null)
                returnValue = returnValue + ",";
            return returnValue;

        }
    }

    public class LinkedList<T>:
        ICollection<T>,
        IEnumerable<Node<T>>
    {
        public Node<T> Head;

        #region Add
        public void AddFirst(T value)
        {
            var node = new Node<T> (value, this.Head );
            this.Head = node;
            this.Count++;
        }
        
        public void AddLast(T value)
        {
            var node = new Node<T> (value);

            if (this.Head == null)
                this.Head = node;
            else
            {
                var temp = this.Head;
                while (temp.Next != null)
                    temp = temp.Next;

                temp.Next = node;
            }
            this.Count++;
        }
        #endregion

        #region Remove
        public void RemoveFirst()
        {
            if (this.Head == null) return;
            this.Head = this.Head.Next;
            this.Count--;
        }

        public void RemoveLast()
        {
            if (this.Head == null || this.Head.Next == null)
            {
                this.Head = null;
                this.Count = 0;
                return;
            }
            var curr = this.Head;
            var next = curr.Next;
            while (next.Next != null)
            {
                curr = next;
                next = next.Next;
            }
            curr.Next = null;
            this.Count--;
        }

        #endregion

        public void PrintList()
        {
            if (this.Head == null)
                Console.WriteLine("List Empty");
            var temp = this.Head;
            while (temp != null)
            {
                Console.Write(temp.ToString());
                temp = temp.Next;
            }
            if (this.Head != null)
                Console.WriteLine($" => Head: {this.Head.Value}, Count: {this.Count}");
        }

        #region ICollection

        IEnumerator<Node<T>> IEnumerable<Node<T>>.GetEnumerator()
        {
            var temp = this.Head;
            while (temp != null)
            {
                Console.Write($"{temp.Value}");
                yield return temp;
                temp = temp.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var temp = this.Head;
            while (temp != null)
            {
                Console.Write($"{temp.Value}");
                yield return temp.Value;
                temp = temp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(T item)
        {
            this.AddFirst(item);
        }

        public void Clear()
        {
            this.Head = null;
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            var temp = this.Head;
            while (temp != null)
            {
                if (temp.Value.Equals(item))
                return true;
                temp = temp.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var temp = this.Head;
            var i = 0;
            while (temp != null)
            {
                array[i++] = temp.Value;
                temp = temp.Next;
            }
        }

        public bool Remove(T item)
        {
            
            var temp = this.Head;
            var prev = temp;
            while (temp != null)
            {
                if (temp.Value.Equals(item))
                {
                    if (temp == this.Head) //1st element matching
                        this.RemoveFirst();
                    else if (temp.Next == null) //last element matching
                        this.RemoveLast();
                    else //in between an element matching
                    {
                        prev.Next = temp.Next;
                        this.Count--;
                    }
                    return true;
                }
                prev = temp;
                temp = temp.Next;
            }
            return false;
        }
        #endregion

        public int Count { get; private set; }
        public bool IsReadOnly => false;
    }

    public class LinkedListDemo
    {
        public static void Start()
        {
            var mylist = new LinkedList<object>();
            mylist.PrintList();
            mylist.AddFirst(1);
            mylist.AddFirst(2);
            mylist.AddFirst(3);
            mylist.AddLast(4);
            mylist.AddLast(6);
            mylist.AddLast("Basant");
            mylist.AddFirst("Agrawal");
            mylist.PrintList();

            var arr = new object[10];
            mylist.CopyTo(arr,arr.Length);

            Console.WriteLine( arr[6]);
            mylist.Remove("Basant");
            mylist.PrintList();
            while (mylist.Count > 0)
            {
                mylist.RemoveLast();
                mylist.PrintList();
            }
        }
    }
}