using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    using System.Runtime.Serialization.Formatters;

    class ValidPalindromeOneCharDelete
    {
        //125. Valid Palindrome II: https://leetcode.com/problems/valid-palindrome-ii/description/
        public static void Demo()
        {
            var s = "enveoryyroevne";
            Console.WriteLine($"input string:{s}");
            Console.WriteLine($"Result:{IsPalindrome(s,0,s.Length-1,1)}");
        }

        public static bool IsPalindrome(string s, int i, int j, int d)
        {
            if (i > j)
                return true;

            if (s[i] == s[j])
                return IsPalindrome(s, i + 1, j - 1, d);

            if (d == 0)
                return false;
            return IsPalindrome(s, i + 1, j, d - 1) || IsPalindrome(s, i, j - 1, d - 1);
        }

    }
}
