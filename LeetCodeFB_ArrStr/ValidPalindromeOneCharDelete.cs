using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeFB_ArrStr
{
    using System.Runtime.Serialization.Formatters;

    class ValidPalindromeOneCharDelete
    {
        //https://leetcode.com/problems/valid-palindrome-ii/description/
        public static void Demo()
        {
            var s = "abccbca";
            Console.WriteLine($"input string:{s}");
            Console.WriteLine($"Result:{IsPalindrome(s,0,s.Length-1,1)}");
            Console.WriteLine($"Result:{IsPalindromeWithouRecursion(s)}");
        }

        //Here the parameters are
        //s: input string
        //i, j: left and right indexes
        //d: how many chars deletes allowed. Here it is 1, But this can be anything
        public static bool IsPalindrome(string s, int i, int j, int d)
        {
            if (i > j)
                return true;

            if (s[i] == s[j])
                return IsPalindrome(s, i + 1, j - 1, d);

            if (d == 0)
                return false;
            //if the match is not found and this is the first time when this happened (d still 1)
            //then try both way: skipping left and right
            //we dont know which one will give us successfull result
            return IsPalindrome(s, i + 1, j, d - 1) || IsPalindrome(s, i, j - 1, d - 1);
        }
        public static bool IsPalindromeWithouRecursion(string s)
        {
            int d = 1;
            int i = 0, j = s.Length - 1;
            int saved_i = -1, saved_j = -1;
            bool Palindrome = true;
            while (i < j)
            {
                if (s[i] == s[j])
                {
                    i++;
                    j--;
                    continue;
                }
                if (saved_i>=0)
                {
                    i = saved_i;
                    j = saved_j;
                    saved_i = -1;
                    continue;
                }
                if (d == 0)
                {
                    Palindrome = false;
                    break;
                }
                if (i < j)
                {
                    if (s[i + 1] == s[j])
                    {
                        if (s[i] == s[j - 1])
                        {
                            saved_i = i;
                            saved_j = j - 1;
                        }
                        i++;
                        d--;
                    }
                    else if (s[i] == s[j - 1])
                    {
                        j--;
                        d--;
                    }
                    else
                    {
                        Palindrome = false;
                        break;
                    }
                }
            }
            return Palindrome;
        }
    }    
}
