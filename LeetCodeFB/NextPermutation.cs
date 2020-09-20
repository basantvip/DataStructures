using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB
{
    class NextPermutation
    {
        //https://www.nayuki.io/page/next-lexicographical-permutation-algorithm
        //https://leetcode.com/problems/next-permutation/
        public static void Demo()
        {
            int[] numbers = new int[] { 5, 1, 1 };

            Console.Write($"input: ");
            foreach (var item in numbers)
            {
                Console.Write($"{item},");
            }
            NextPermutation_internal(numbers);
            Console.Write($"\noutput: ");
            foreach (var item in numbers)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine("");
        }

        public static void NextPermutation_internal(int[] nums)
        {
            //start with 2nd to last element and compare with its next element
            int i = nums.Length - 2;

            while (i >= 0 && nums[i] >= nums[i + 1]) //continue until decreasing sequence is broken, called pivot element 
                i--;

            //at this point either we found the pivot element or list ran out
            if (i >= 0) //pivot element found, swap with just larger
            {
                int j = nums.Length - 1;
                while (j > i && nums[j] <= nums[i])
                    j--;
                swap(nums, i, j);
            }

            //reverse items after i+1
            for (int j = nums.Length - 1; ++i < j; j--)
            {
                swap(nums, i, j);
            }

        }

        public static void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
