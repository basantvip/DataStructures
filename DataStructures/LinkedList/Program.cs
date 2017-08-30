using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("\n\t1.Linked List\n\t2.Stack Array\n\t3.Stack Linked List\n\t4.Postfix\n\t5.Infix to Postfix\n\t0:Exit\nEnter Choice: ");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        LinkedList<object>.Demo();
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
                    case "0":
                        return;
                }
            }
        }
    }
}
