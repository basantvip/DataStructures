using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class MinimumLengthSubArraySum
    {
        public static void Demo()
        {
            var s = "1, 4, 45, 6, 0, 19";
            var sum = 0;
            int i;
            var list = s.Split(',').Where(t => int.TryParse(t, out i)).Select(t => int.Parse(t)).ToList();
            Console.WriteLine(GetMinimumLengthSubArraySum(list, sum));
        }

        public static int GetMinimumLengthSubArraySum(List<int> list, int sum)
        {
            if (list == null || list.Count == 0)
                return 0;

            int startIndex = 0, endIndex = 0, currentSum = 0, minLength = list.Count + 1;

            while (startIndex <= endIndex && startIndex < list.Count && endIndex < list.Count)
            {
                while (currentSum < sum && endIndex < list.Count)
                {
                    currentSum = currentSum + list[endIndex++];
                }

                while (currentSum >= sum && startIndex < list.Count)
                {
                    if (minLength > endIndex - startIndex)
                        minLength = endIndex - startIndex;

                    currentSum = currentSum - list[startIndex++];
                }
            }
            return (minLength < list.Count && minLength >0 ? minLength : 0);
        }
    }
}
