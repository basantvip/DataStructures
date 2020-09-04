using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeFB
{
    using System.Runtime.Serialization.Formatters;

    class ValidPalindrome
    {
        //125. Valid Palindrome: https://leetcode.com/problems/valid-palindrome/description/
        public static void Demo()
        {
            var s = "A man, a plan, a canal: Panama";
            Console.WriteLine($"input string:{s}");
            Console.WriteLine($"Result:{IsPalindrome(s)}");
        }

        public static bool IsPalindrome(string s)
        {
            s = s.ToUpper();
            var palindrome = true;
            int i = 0, j = s.Length - 1;
            while (i <= j)
            {
                if (!IsAlphaNumeric(s[i]))
                {
                    i++;
                    continue;
                }

                if (!IsAlphaNumeric(s[j]))
                {
                    j--;
                    continue;
                }
                if (s[i] != s[j])
                {
                    palindrome = false;
                    break;
                }
                i++;
                j--;

            }
            return palindrome;
        }

        public static bool IsAlphaNumeric(char c)
        {
            return (c >= '0' && c <= '9') || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }
    }
}
