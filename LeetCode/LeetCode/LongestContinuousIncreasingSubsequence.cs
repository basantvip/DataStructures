using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class LongestContinuousIncreasingSubsequence
    {
        public static void Demo()
        {
            var s = "-335789,-335773,-335589,-335138,-335111,-335053,-334995,-334995,-334986,-334903,-334895,-334874,-334867,-334674,-334462,-334456,-332956,-332857,-332713,-332627,-332517,-332458,-332241,-332223,-332206";
            int i;
            var list = s.Split(',').Where(t => int.TryParse(t, out i)).Select(int.Parse).ToArray();
            Array.ForEach(list, t => Console.WriteLine($"{t},"));
            Console.WriteLine(FindLengthOfLcis(list));
        }

        public static int FindLengthOfLcis(int[] nums)
        {

            if (nums.Length < 2)
                return nums.Length;

            int maxLen = 0, currLen = 1;

            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    currLen++; //continue incrementing current length if current item is greater than previous
                }
                else
                    currLen = 1; //reset current length if current item is not greater than prev            

                if (currLen > maxLen)
                    maxLen = currLen; //check if this is the max length found so far
            }

            return maxLen;
        }

    }
}
