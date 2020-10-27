using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB_ArrStr
{
    class GroupAnagrams
    {
        //https://leetcode.com/problems/group-anagrams/
        public static void Demo()
        {
            string[] strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            Console.Write($"input: ");
            foreach (var item in strs)
            {
                Console.Write($"{item},");
            }

            var result = Find(strs);

            Console.WriteLine($"\noutput: ");
            foreach (var item in result)
            {
                Console.Write("{");
                foreach (var subitem in item)
                {                    
                    Console.Write($"{subitem},");
                }
                Console.Write("}\n");
            }

        }

        public static List<List<string>> Find(string[] strs)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            foreach (var item in strs)
            {
                var c_array = item.ToCharArray();
                Array.Sort(c_array);
                var key = new string(c_array);
                if (!dict.ContainsKey(key))
                    dict.Add(key, new List<string>());
                dict[key].Add(item);
            }
            return new List<List<string>>(dict.Values);
        }
    }
}
