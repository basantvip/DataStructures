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
            //Console.WriteLine("Enter input list of integers separated by space or comma");
            //var list = (Console.ReadLine() ?? "").Replace(',', ' ').Split(' ').Select(int.Parse).ToList();

            var list = new List<int>() { 1, 2, 10, 4, 3 };
            Console.Write("Input List: ");
            PrintList(list);

            Console.Write("Bubble Sort: ");
            PrintList(BubbleSort(list));

            Console.Write("Effecient Bubble Sort: ");
            PrintList(EffecientBubbleSort(list));

            Console.Write("Selection Sort: ");
            PrintList(SelectionSort(list));

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
                        Swap(returnList, j, j + 1);
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
                        Swap(returnList, j, j + 1);
                    }
                }
            }
            Console.WriteLine($"Rounds: {rounds}");
            return returnList;
        }

        public static List<int> SelectionSort(List<int> list)
        {
            var returnList = new List<int>(list);
            var rounds = 0;

            for (var i = 0; i < returnList.Count - 1; i++)
            {
                rounds++;
                var minIndex = GetMinIndex(returnList, i, ref rounds);
                if (minIndex > i)
                {
                    Swap(returnList,i,minIndex);
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

        public static int GetMinIndex(List<int> list,int startIndex,ref int rounds)
        {
            var minIndex = startIndex;
            var minValue = list[startIndex];
            for (var i = startIndex + 1; i < list.Count; i++)
            {
                rounds++;
                if (minValue > list[i])
                {
                    minValue = list[i];
                    minIndex = i;
                }
            }
            return minIndex;

        }

        public static void Swap(List<int> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
            
        }
    }
}
