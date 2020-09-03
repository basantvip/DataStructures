using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB
{
    class MoveZeroes
    {
        public static void Demo()
        {
            int[] numbers = new int[] { 0, 1, 0, 3, 12 };

            Console.Write($"input: ");
            foreach (var item in numbers)
            {
                Console.Write($"{item},");
            }
            MoveZeroes_internal(numbers);
            Console.Write($"\noutput: ");
            foreach (var item in numbers)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine("");
        }

        public static void MoveZeroes_internal(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    count++;
                else if (count > 0)
                {
                    nums[i - count] = nums[i];
                    nums[i] = 0;
                }
            }
        }
    }
}
