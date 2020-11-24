using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("\n\t1.Linked List\n\t2.Stack Array\n\t3.Stack Linked List\n\t4.Postfix\n\t5.Infix to Postfix\n\t6.Hash Table\n\t7.Binary Tree\n\t8.Sorting\n\t9.Threaded Binary Tree\n\t10.Binary Tree\n\t0:Exit\nEnter Choice: ");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        MyLinkedList<object>.Demo();
                        break;
                    case "2":
                        StackArray<int>.Demo();
                        break;
                    case "3":
                        StackLinkList<object>.Demo();
                        break;
                    case "4":
                        Postfix.Demo();
                        break;
                    case "5":
                        Postfix.InfixToPostfix();
                        break;
                    case "6":
                        HashTable.Demo();
                        break;
                    case "7":
                        BST.Demo();
                        break;
                    case "8":
                        Sorting.Demo();
                        break;
                    case "9":
                        ThreadedBinaryTree.Demo();
                        break;
                    case "10":
                        BinaryTree.Demo();
                        break;
                    case "0":
                        return;
                }
            }
        }
    }
}
