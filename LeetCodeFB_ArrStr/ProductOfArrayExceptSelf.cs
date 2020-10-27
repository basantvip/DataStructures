using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB_ArrStr
{
    class ProductOfArrayExceptSelf
    {
        //https://leetcode.com/problems/product-of-array-except-self
        //one solution would be to build two temp arrays with left and right product of each index
        //taking this idea further if we have to do this in O(1) space complexity (constant space)
        //then we can use the output array for storing the right product
        //and then we can build the left product list of fly and multiply with left product list to update in place output array
        //brilliant solution
        public static void Demo()
        {
            int[] numbers = new int[] { 4, 5, 1, 8, 2 };

            Console.Write($"input: ");
            foreach (var item in numbers)
            {
                Console.Write($"{item},");
            }
           
            Console.Write($"\noutput: ");
            foreach (var item in Demo_internal(numbers))
            {
                Console.Write($"{item},");
            }
            Console.WriteLine("");
        }

        public static int[] Demo_internal(int[] nums)
        {            
            int[] result = new int[nums.Length];

            //building the right product list into the output array itself
            for (int i=nums.Length-1; i>=0; i--)
            {
                if (i == nums.Length - 1)
                    result[i] = 1;
                else
                    result[i] = result[i + 1] * nums[i + 1];

            }

            //calculate the left product on the fly and multiply with output array which has the left production
            //update the same output array with left*right
            int leftsum = 1;
            for (int i = 0; i < nums.Length; i++)
            {

                if (i > 0)
                    leftsum*=nums[i - 1];

                result[i] *= leftsum;                

            }

            return result;
        }
    }
}
