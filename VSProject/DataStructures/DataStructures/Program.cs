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
                Console.WriteLine("\nEnter Choice:\n\t1.LinkedList\n\t2.LinkedList\n\t3.LinkedList\n\t4.LinkedList\n\t0:Exit");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        LinkedListDemo.Start();
                        break;
                    case "2":
                        LinkedListDemo.Start();
                        break;
                    case "3":
                        LinkedListDemo.Start();
                        break;
                    case "6":
                        LinkedListDemo.Start();
                        break;
                    case "0":
                        return;
                }
            }
        }
    }
}
