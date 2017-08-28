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
            //var list = new List<int>() { 1, 2, 10, 4, 3 };

            var list = new List<int>();
            var r = new Random();
            while (list.Count < 10)
            {
                var next = r.Next(10);
                if (list.Contains(next))
                    continue;
                list.Add(next);
            }

            Console.Write("Input List: ");
            PrintList(list);

            Console.Write("Bubble Sort: ");
            PrintList(BubbleSort(list));

            Console.Write("Effecient Bubble Sort: ");
            PrintList(EffecientBubbleSort(list));

            Console.Write("Selection Sort: ");
            PrintList(SelectionSort(list));

            Console.Write("Selection Sort Variation: ");
            PrintList(SelectionSort_AnotherVariation(list));

            Console.Write("Insertion Sort: ");
            var newList = InsertionSort(list);
            PrintList(newList);

            Console.Write("Insertion Sort on a Sorted List: ");
            PrintList(InsertionSort(newList));

            Console.Write("Merge Sort: ");
            PrintList(MergeSort(list));

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
                    Swap(returnList, i, minIndex);
                }

            }
            Console.WriteLine($"Rounds: {rounds}");
            return returnList;
        }

        public static List<int> SelectionSort_AnotherVariation(List<int> list)
        {
            var returnList = new List<int>(list);
            var rounds = 0;

            for (var i = 0; i < returnList.Count - 1; i++)
            {
                var minIndex = i;
                for (var j = i + 1; j < returnList.Count; j++)
                {
                    if (returnList[minIndex] > returnList[j])
                    {
                        minIndex = j;
                        rounds++;
                    }
                }

                if (minIndex > i)
                    Swap(returnList, i, minIndex);
            }
            Console.WriteLine($"Rounds: {rounds}");
            return returnList;
        }

        public static List<int> InsertionSort(List<int> list)
        {
            var returnList = new List<int>(list);
            var rounds = 0;
            for (var i = 1; i < returnList.Count; i++)
            {
                var CurrentInsValue = returnList[i];
                var j = i; //rightmost boundary of sorted list
                //PrintList(returnList);                
                while (j > 0 && returnList[j - 1] > CurrentInsValue)
                {
                    rounds++;
                    returnList[j] = returnList[j - 1];
                    j--;
                }
                returnList[j] = CurrentInsValue;

            }
            Console.WriteLine($"Rounds: {rounds}");
            return returnList;

        }

        public static List<int> MergeSort(List<int> list)
        {
            var returnList = new List<int>(list);
            int rounds = 0;
            MergeSort(returnList, 0, returnList.Count - 1,ref rounds);
            Console.WriteLine($"Rounds: {rounds}");
            return returnList;
        }

        public static void MergeSort(List<int> list, int lower, int upper,ref int rounds)
        {
            if (lower < upper)
            {
                int middle = lower + (upper - lower) / 2;

                MergeSort(list, lower, middle, ref rounds);
                MergeSort(list, middle + 1, upper, ref rounds);
                MergeLists(list, lower, middle, upper, ref rounds);

            }
        }
        public static void MergeLists(List<int> list, int lower, int middle, int upper, ref int rounds)
        {
            var tempList = new List<int>();

            int i = lower, j = middle+1;
            while (i <= middle && j <= upper)
            {
                rounds++;
                if (list[i] < list[j])
                    tempList.Add(list[i++]);
                else
                    tempList.Add(list[j++]);
            }

            while (i <= middle)
            {
                tempList.Add(list[i++]);
                rounds++;
            }
            while (j <= upper)
            {
                tempList.Add(list[j++]);
                rounds++;
            }
            for (int k = 0; k < tempList.Count; k++)
                list[lower + k] = tempList[k];
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
