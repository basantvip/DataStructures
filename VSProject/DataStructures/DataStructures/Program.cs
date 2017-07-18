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
                Console.Write("\n\t1.LinkedList\n\t2.StackArray\n\t3.LinkedList\n\t4.LinkedList\n\t0:Exit\nEnter Choice: ");
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
                        LinkedList<object>.Demo();
                        break;
                    case "6":
                        LinkedList<object>.Demo();
                        break;
                    case "0":
                        return;
                }
            }
        }
    }
}
