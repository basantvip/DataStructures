using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input list of integers separated by space or comma");
            var list = (Console.ReadLine() ?? "").Replace(',', ' ').Split(' ').Select(int.Parse).ToList();
            Console.Write("Input List: ");
            PrintList(list);
            Console.Write("BubbleSort: ");
            PrintList(BubbleSort(list));
            Console.Write("EffecientBubbleSort: ");
            PrintList(EffecientBubbleSort(list));
            Console.ReadLine();
        }

        public static List<int> BubbleSort(List<int> list)
        {
            var returnList = new List<int>(list);
            var rounds = 0;
            
            for (var i = returnList.Count - 1; i > 0; i--)
            {
                for (var j = 0; j < i; j++)
                {
                    rounds++;
                    if (returnList[j] > returnList[j + 1])
                    {
                        var temp = returnList[j];
                        returnList[j] = returnList[j + 1];
                        returnList[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine($"Rounds: {rounds}");
            return returnList;
        }

        public static List<int> EffecientBubbleSort(List<int> list)
        {
            var returnList = new List<int>(list);
            var rounds = 0;
            var sorted = false;
            for (var i = returnList.Count - 1; i > 0 && sorted == false; i--)
            {
                sorted = true;
                for (var j = 0; j < i; j++)
                {
                    rounds++;
                    if (returnList[j] > returnList[j + 1])
                    {
                        sorted = false;
                        var temp = returnList[j];
                        returnList[j] = returnList[j + 1];
                        returnList[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine($"Rounds: {rounds}");
            return returnList;
        }

        public static void PrintList(List<int> list)
        {
            var s = list.Aggregate("", (current, item) => $"{current},{item}");
            if (s.StartsWith(","))
                s = s.Substring(1, s.Length - 1);
            Console.WriteLine(s);
        }
    }
}
