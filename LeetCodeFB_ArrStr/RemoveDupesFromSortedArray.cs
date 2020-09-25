using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB_ArrStr
{
    class RemoveDupesFromSortedArray
    {
        //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3011/
        public static void Demo()
        {
            int[] numbers = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            Console.Write($"input: ");
            foreach (var item in numbers)
            {
                Console.Write($"{item},");
            }

            var result = RemoveDuplicates(numbers);          

            Console.WriteLine($"\noutput:{result} ");  
            for (int i=0; i< result; i++)
                Console.Write($"{numbers[i]},");
            Console.WriteLine();

        }

        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                    nums[++i] = nums[j];
            }
            return i + 1;
        }
    }
}
