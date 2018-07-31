using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class TwoSum
    {
        public static void Demo()
        {
            int[] list = new int[5] { 1, 2, 3, 4, 5 };
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
                dict.Add(complement, i);
            }
            if (result.Count > 0)
                Console.WriteLine($"{result[0]},{result[1]}");
            else
                Console.WriteLine("Not found");

            Console.ReadLine();

        }
    }
}
