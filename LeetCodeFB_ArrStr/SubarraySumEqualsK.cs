using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB_ArrStr
{ 
    //https://leetcode.com/problems/subarray-sum-equals-k/
    //Facebook: screening Q2. The first question was postfix (polish notation)
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

            Console.WriteLine($"Result:{SubarraySumUsingCumSum(nums, k)}");            
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

        //here we are creating a dictionary which will have key at as sum at each index and the value as how many times that sum appreared
        //in a loop we calculate the cummulative sum at each index and then try to find if last N elements add up to k
        //to find that one way would be
        // find in a subloop all elements in the dictionary find (currsum-sum) == k
        // but that will be ineffecient, since we have a dict we can dop something effecient
        //(currsum-sum)==k is same as (currsum-k)==sum
        //since sum is index in dictionary we can find this element using TryGetValue
        //if found it means there existed atleast an index where sum was currsum-k. 
        //which means if we add all elements after that index we will get k
        //for example if u r looking for k=2, currsum is 10 and you find 8 in dictionary
        //it means wherever the sum was 8 if you add all elements AFTER that element, up element of currsum u get 2
        //extremely effienct solution !!!
        public static int SubarraySumUsingCumSum(int[] nums, int k)
        {
            int CurrSum = 0, result = 0;
            
            //we need to add first item so that if first element itself is equal to K then our generic logic holds good
            var leftSumsFreq = new Dictionary<int, int> { { 0, 1 } };

            foreach (var num in nums)
            {
                CurrSum += num;
                if (leftSumsFreq.TryGetValue(CurrSum - k, out var freq)) 
                    result += freq;

                //if condition will be satisfied when there were 0's or negative number causing prev sum to appear again
                if (leftSumsFreq.ContainsKey(CurrSum))
                    leftSumsFreq[CurrSum]++;
                else //this sum hasn't come before
                    leftSumsFreq.Add(CurrSum, 1);
            }
            return result;
        }
    }
}
