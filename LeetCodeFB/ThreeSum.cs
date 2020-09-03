using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB
{
    class ThreeSum
    {
        public static void Demo()
        {
            int[] numbers = new int[] { -1, 0, 1, 2, -1, -4 };
            Console.Write($"input: ");
            foreach (var item in numbers)
            {
                Console.Write($"{item},");
            }

            var result =  Find(numbers);          

            Console.WriteLine($"\noutput: ");
            foreach (var item in result)
            {
                foreach (var subitem in item)
                {
                    Console.Write($"{subitem},");
                }
                Console.WriteLine("");
            }

        }

        //two pointer method in a loop O(n square)
        public static IList<IList<int>> Find(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length-2; i++)
            {
                int twoSumTarget = 0 - nums[i];
                int left = i + 1, right = nums.Length - 1;
                while (left < right)
                {
                    if (nums[left] + nums[right] == twoSumTarget)
                    {
                        result.Add(new List<int>() { nums[i], nums[left], nums[right] });
                        
                        //skip dupes for 2nd and third elememts
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;

                        left++;
                        right--;
                    }
                    else if (nums[left] + nums[right] < twoSumTarget)
                        left++;
                    else
                        right--;
                }

                //skip dupes for 1st element
                while (i < nums.Length - 1 && nums[i] == nums[i + 1]) i++;

            }
            return result;
        }      
    }
}
