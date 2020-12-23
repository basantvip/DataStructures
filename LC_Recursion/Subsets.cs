using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures;

namespace LC_Recursion
{
    //https://leetcode.com/problems/subsets
    public class SubsetsClass
    {       
        public static void Demo()
        {

            var nums = new int[] { 1,2,3 };
            var result = new List<IList<int>>();            
            result.Add(new List<int>());
            new SubsetsClass().SubsetsUsingHashSet(nums, 0, new HashSet<int>(), result);
            
            Console.Write("Input:");
            foreach (var item in nums)
            {
                if (item == nums[nums.Length - 1])
                    Console.Write($"{item}");
                else
                    Console.Write($"{item},");
            }
            
            Console.Write("\nSubsets:{");            
            foreach (var item in result)
            {
                Console.Write("{");
                foreach (var subItem in item)
                {
                    if (subItem == item[item.Count - 1])
                        Console.Write($"{subItem}");
                    else
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

        public void SubsetsUsingHashSet(int[] nums, int index, HashSet<int> hashset, IList<IList<int>> result)
        {
            if (nums.Length == 0 || index >= nums.Length)
                return;

            //the only difference between this problem annd permutation problem is 
            //here we always need to add to result irresepective of the length of hashset
            //also since this is a combination problem means if 1,2,3 is done we cannot add 3,2,1 or 3,1,2 or 2,3,1
            //ordering of element in the list is not important
            //which means I cannot start from same index in next recursive call
            //so in each recursive call instead of starting from 0 we start from next index
            //that's why we are passing additional parameter index
            //sample output: [[],[1],[1,2],[1,2,3],[1,3],[2],[2,3],[3]]
            while (index < nums.Length)
            {
                if (!hashset.Contains(nums[index]))
                {
                    hashset.Add(nums[index]);
                    result.Add(hashset.ToList<int>());
                    SubsetsUsingHashSet(nums, index, hashset, result);
                    hashset.Remove(nums[index]);
                }
                index++;
            }
        }

    }
}
