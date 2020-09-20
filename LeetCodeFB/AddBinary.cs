using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB
{
    class AddBinary
    {
        //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/263/
        public static void Demo()
        {
            string a = "11", b = "1";
            Console.WriteLine($"Input strings {a},{b}");            
            var result = AddBinary_Internal(a,b);
            Console.WriteLine($"Output:{result}");           

        }

        public static string AddBinary_Internal(string a, string b)
        {
            StringBuilder result = new StringBuilder();
            int carry = 0;
            if (a.Length < b.Length)
                return AddBinary_Internal(b, a);
            for (int i = a.Length - 1, j = b.Length - 1; (i >= 0) || (carry > 0); i--, j--)
            {
                var curr_result = (i >= 0 ? a[i] - '0' : 0) + (j >= 0 ? b[j] - '0' : 0) + carry;
                result.Insert(0, curr_result & 1);
                carry = curr_result >> 1;
            }
            return result.ToString();
        }
    }
}
