using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class TwoSum
    {
        //this is O(n) better than O(n log n)
        public static void Demo()
        {
            int[] list = new int[8] { 2, 2, 3, 4, 5, 11, 15, 15 };
            List<int> result = new List<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int sum = 9;
            for (int i = 0; i < list.Length; i++)
            {
                int complement = sum - list[i];
                if (dict.ContainsKey(list[i]))
                {
                    result.Add(dict[list[i]]);
                    result.Add(i);
                    break;
                }
                if (!dict.ContainsKey(complement)) 
                    dict.Add(complement, i);
            }
            if (result.Count > 0)
                Console.WriteLine($"{result[0]},{result[1]}");
            else
                Console.WriteLine("Not found");

            Console.ReadLine();

        }


        //this is O(n log n)
        //this will only work if sorted
        public static void Demo1()
        {
            int[] numbers = new int[] { 2, 7, 11, 15, 15 };
            List<int> result = new List<int>();            
            int target = 9;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int complementIndex = binarySearchGetIndex(numbers, target - numbers[i], i + 1);
                if (complementIndex > -1)
                {
                    result.Add(i);
                    result.Add(complementIndex);
                    break;
                }
            }
            if (result.Count > 0)
                Console.WriteLine($"{result[0]},{result[1]}");
            else
                Console.WriteLine("Not found");

            Console.ReadLine();

        }

        public static int binarySearchGetIndex(int[] numbers, int target, int startIndex)
        {
            int i = startIndex, j = numbers.Length-1;
            while (i <= j)
            {
                int mid = i + (j - i) / 2;
                if (numbers[mid] == target)
                    return mid;
                if (numbers[mid] < target)
                    i = mid + 1;
                else
                    j = mid - 1;
            }
            return -1;
        }

        //two pointer approach O(n), and is best of all
        //this will only work if sorted
        public static void Demo2()
        {
            int[] numbers = new int[] { 2, 7, 11, 15, 15 };
            List<int> result = new List<int>();
            int target = 9;
            int i = 0, j = numbers.Length - 1;
            while (i < j)
            {
                if (numbers[i] + numbers[j] == target)
                {
                    result.Add(i);
                    result.Add(j);
                    break;
                }
                if (numbers[i] + numbers[j] < target)
                    i++;
                else
                    j--;
            }
            if (result.Count > 0)
                Console.WriteLine($"{result[0]},{result[1]}");
            else
                Console.WriteLine("Not found");

            Console.ReadLine();

        }
    }
}
