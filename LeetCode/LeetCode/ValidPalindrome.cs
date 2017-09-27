using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    using System.Runtime.Serialization.Formatters;

    class ValidPalindrome
    {
        //125. Valid Palindrome: https://leetcode.com/problems/valid-palindrome/description/
        public static void Demo()
        {
            var s = "a.";
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
            int i;
            return ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || int.TryParse(c.ToString(),out i));
        }
    }
}
