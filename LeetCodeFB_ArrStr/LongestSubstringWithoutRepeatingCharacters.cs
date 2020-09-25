using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeFB_ArrStr
{
    class LongestSubstringWithoutRepeatingCharacters
    {
        public static void Demo()
        {
            //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3008/
            string s = "abcabcbb";            
            Console.WriteLine($"string:{s}");            
            Console.WriteLine($"Result:{longest(s)}");            
        }

        public static int longest(string s)
        {
            if (s == null || s == String.Empty)
                return 0;
            HashSet<char> myset = new HashSet<char>();
            int i = 0, j = 0, maxlen = 0;
            int n = s.Length;
            while (i < n && j < n)
            {
                if (!myset.Contains(s[j]))
                {
                    myset.Add(s[j++]);
                    maxlen = Math.Max(maxlen, j - i);
                }
                else
                {
                    myset.Remove(s[i++]);
                }
            }            
            return maxlen;
        }
    }
}
    