using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures;

namespace LC_Recursion
{
    //https://leetcode.com/problems/permutations/
    public class PermutationIIClass
    {       
        public static void Demo()
        {

            var nums = new int[] { 1,2,1 };            
            var result = new PermutationIIClass().PermuteUnique(nums);            
            Console.Write("Input:");
            foreach (var item in nums)
            {
                Console.Write($"{item},");
            }

            Console.Write("\nPermutations:{");            
            foreach (var item in result)
            {
                Console.Write("{");
                foreach (var subItem in item)
                {                    
                    Console.Write($"{subItem},");
                }
                
                if (item == result[result.Count - 1])
                    Console.Write("}");
                else
                    Console.Write("},");
            }
            Console.Write("}");
            Console.WriteLine();
        }

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            Array.Sort(nums);

            IList<IList<int>> result = new List<IList<int>>();
            bool[] used = new bool[nums.Length];
            IList<int> current = new List<int>();
            //dfs(nums, used, current, result);
            PermuteIIUsingReplacement(nums, 0, result);
            return result;
        }

        private void dfs(int[] nums, bool[] used, IList<int> current, IList<IList<int>> result)
        {
            if (current.Count == nums.Length)
            {
                IList<int> list = new List<int>();
                foreach (var c in current)
                {
                    list.Add(c);
                }
                result.Add(list);
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i] == true) continue;
                if (i > 0 && nums[i - 1] == nums[i] && !used[i - 1]) continue;
                used[i] = true;
                current.Add(nums[i]);
                dfs(nums, used, current, result);
                used[i] = false;
                current.RemoveAt(current.Count - 1);
            }
        }
        private void PermuteIIUsingReplacement(int[] nums, int startIndex, IList<IList<int>> result)
        {
            if (nums.Length == 0)
                return;

            //if (startIndex == nums.Length - 1)
            //{
            //    result.Add(new List<int>(nums.ToList()));
            //    return;
            //}
            //here in each iteration of the recursion we are pinning one position called startIndex. 
            //in a loop we swap values of startindex with all index after startIndex
            //after swapping each time we call recursion for next startIndex (current startIndex + 1)
            //note here the 2nd parameter to recursive call in not i, but startIndex +1
            for (int i = startIndex; i < nums.Length; i++)
            {

                //if repeated element found, skip the current iteration 
                if (i > startIndex && nums[i] == nums[startIndex])
                    continue;
                
                SwapElements(startIndex, i, nums);
                if (i == nums.Length - 1)
                    result.Add(new List<int>(nums.ToList()));
                else
                    PermuteIIUsingReplacement(nums, startIndex + 1, result);
                SwapElements(startIndex, i, nums);                               
            }
        }

        private void SwapElements(int i, int j, int[] nums)
        {
            if (i >= nums.Length || j >= nums.Length || i == j)
                return;
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
