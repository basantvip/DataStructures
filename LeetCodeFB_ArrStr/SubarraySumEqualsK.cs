using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB_ArrStr
{ 

    class SubarraySumEqualsK
    {  
        public static void Demo()
        {
            var nums = new int[] {-1,-1,1};
            int k = 0;

            Console.Write("Input:");
            foreach (var item in nums)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine($"\nk:{k}");

            Console.WriteLine($"Result:{Demo_internal(nums, k)}");            
            Console.WriteLine("");
            
        }
        private static int Demo_internal(int[] nums, int k)
        {
            int result = 0;
            for (int left = 0; left < nums.Length; left++)
            {
                int sum = 0;
                for (int right = left; right < nums.Length; right++)
                {
                    sum = sum + nums[right];
                    if (sum == k)
                        result++;
                }
            }

            return result;
        }
    }
}
