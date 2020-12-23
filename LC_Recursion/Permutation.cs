using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures;

namespace LC_Recursion
{
    //https://leetcode.com/problems/permutations/
    public class PermutationClass
    {       
        public static void Demo()
        {

            var nums = new int[] { 1,2,3 };
            var result = new List<IList<int>>();
            //result = new PermutationClass().Permute(nums);
            new PermutationClass().PermuteUsingHashSet(nums, new HashSet<int>(), result);            
            Console.Write("Input:");
            foreach (var item in nums)
            {
                if (item == nums[nums.Length - 1])
                    Console.Write($"{item}");
                else
                    Console.Write($"{item},");
            }

            Console.Write("\nPermutations:{");            
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

        public IList<IList<int>> Permute(int[] nums, int index = 0)
        {

            if (nums.Length == 0 || index >= nums.Length)
                return null;

            IList<IList<int>> result = new List<IList<int>>();
            //when reached to last element no need to call recursion
            //just add all elements as single element list
            //like {1,2,3} -> {{1},{2},{3}}
            if (nums.Length == index + 1)
            {
                foreach (var t in nums)
                    result.Add(new List<int>() { t });
            }
            else
            {
                var prevResult = Permute(nums, ++index);
                
                //for each list retrurned by next recursive call
                //add all items from the list                
                foreach (var prevList in prevResult)
                { 
                    foreach (var current in nums)
                    {
                        //in permutation same element does not appear twice in the list
                        if (prevList.Contains(current))
                            continue;
                        //add all the items from next recursion output and add current element
                        //for example, 
                        //current = 1, prevResult: {{1},{2},{3}} -> {{2,1},{3,1}}
                        //current = 2, prevResult: {{1},{2},{3}} -> {{1,2},{3,2}}
                        //current = 3, prevResult: {{1},{2},{3}} -> {{1,3},{2,3}}
                        var t = new List<int>(prevList){current};
                        result.Add(t);
                    }                    
                }
            }

            return result;
        }

        public void PermuteUsingHashSet(int[] nums, HashSet<int> hashset, IList<IList<int>> result)
        {
            if (nums.Length == 0)
                return;

            //Iteration 1: {1}
            //Iteration 2: try adding 1, already exist, try adding 2 -> {1,2}
            //Iteration 3: {1,2,3} and copy to result; also remove current element (3) from hashset, so {1,2}
            //Iteration and then empty
            //coming back to Iteration 2, remove current element (2), and add next element (3) -> {1,3}
            //again call Iteration 3; try 1,2,3; 1 and 3 already exist so add 2 -> {1,3,2} -> copy to result
            //repeat same for //Iteration 1: {1} and //Iteration 1: {2}
            for (int i=0;i<nums.Length;i++)
            {
                if (!hashset.Contains(nums[i]))
                {
                    hashset.Add(nums[i]);
                    if (hashset.Count == nums.Length)
                        result.Add(hashset.ToList<int>());
                    else
                        PermuteUsingHashSet(nums, hashset, result);                    
                    hashset.Remove(nums[i]);
                }
            }
        }
    }
}
