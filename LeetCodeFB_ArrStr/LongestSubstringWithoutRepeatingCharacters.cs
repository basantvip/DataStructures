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
            //https://leetcode.com/problems/longest-substring-without-repeating-characters/
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
                //if this is a new char then keep moving j and update maxlen
                if (!myset.Contains(s[j]))
                {
                    myset.Add(s[j++]);
                    maxlen = Math.Max(maxlen, j - i);
                }
                //when an already found char came move i.
                //in this case since we are not incrementing j this will keep removing char till we find s[j] in myset
                //the idea is to make sure that same char does not remain in hashset more than once
                else
                {
                    myset.Remove(s[i++]);
                }
            }            
            return maxlen;
        }
    }
}
    