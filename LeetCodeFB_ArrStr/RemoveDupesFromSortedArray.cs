using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB_ArrStr
{
    class RemoveDupesFromSortedArray
    {
        //https://leetcode.com/problems/remove-duplicates-from-sorted-array/
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
            //since its a soretd array if the dupes are present they will be adjacent
            //keep moving to the right starting from 2nd element
            //when current element is dupe of last then just increment dupes counter
            //when current element is not dupe copy it to (current index - # of dupes found)
            //and also update last found element
            //return total number of elements - # of dupes found
            if (nums.Length == 0)
                return 0;
            int last = nums[0], dupes = 0, j;
            for (j = 1; j < nums.Length; j++)
            {
                if (last == nums[j])
                    dupes++;
                else
                {
                    nums[j - dupes] = nums[j];
                    last = nums[j];
                }
            }
            return j - dupes;
        }
    }
}
