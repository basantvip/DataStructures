using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class MaxSumSubArray_Kadane
    {
        public static void Demo()
        {
            var s = "1, -2, 3, 4, -1, 6, -2";            
            int i;
            var list = s.Split(',').Where(t => int.TryParse(t, out i)).Select(t => int.Parse(t)).ToList();
            int left, right;
            Console.WriteLine(GetMaxSumSubArray_Kadane(list, out left, out right));
            Console.WriteLine($"Left:{left}, Right:{right}");
        }

        public static int GetMaxSumSubArray_Kadane(List<int> list)
        {
            int left, right;
            return GetMaxSumSubArray_Kadane(list, out left, out right);            
        }

        public static int GetMaxSumSubArray_Kadane(List<int> list, out int left, out int right)
        {
            int max = 0, curr_max = 0;
            left = right = 0;
            for (int i = 0; i < list.Count; i++)
            {
                curr_max = Math.Max(list[i], curr_max + list[i]);

                if (max < curr_max)
                {
                    max = curr_max;

                    right = i;
                    if (curr_max == list[i])
                        left = i;
                }
            }
            return max;
        }
    }
}
