using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class MultiplyStrings
    {
        public static void Demo()
        {
            //43. https://leetcode.com/problems/multiply-strings/description/
            string s1 = "9369162965141127216164882458728854782080715827760307787224298083754";
            string s2 = "7204554941577564438";
            Console.WriteLine($"string1:{s1}");
            Console.WriteLine($"string2:{s2}");
            Console.WriteLine($"Result:{Multiply(s1,s2)}");
        }

        public static string Multiply(string n1, string n2)
        {
            var result = "";
            for (int j = n2.Length - 1; j >= 0; j--)
            {
                var curr_result = "";
                var carry = 0;
                for (int i = n1.Length - 1; i >= 0; i--)
                {
                    int product = int.Parse(n1[i].ToString()) * int.Parse(n2[j].ToString()) + carry;
                    carry = product / 10;
                    curr_result = $"{(product % 10).ToString()}{curr_result}";
                }
                if (carry > 0)
                    curr_result = $"{carry.ToString()}{curr_result}";
                if (result == "")
                    result = curr_result;
                else
                    result = AddTwoStringWithPadding(result, curr_result, n2.Length - 1 - j);
            }

            while (result.Length > 1)
            {
                if (result[0] != '0')
                    break;
                else
                    result = result.Substring(1);                
            }

            return result;
        }

        public static string AddTwoStringWithPadding(string n1, string n2, int pad)
        {
            n2 = $"{n2}{new string('0', pad)}";
            var carry = 0;
            string result = "";
            for (int i = n1.Length - 1, j = n2.Length - 1; i >= 0 || j >= 0 ; i--, j--)
            {
                int sum = (i >= 0 ? int.Parse(n1[i].ToString()) : 0) + (j >= 0 ? int.Parse(n2[j].ToString()) : 0) + carry;
                result = $"{(sum % 10).ToString()}{result}";
                carry = sum / 10;
            }
            if (carry > 0)
                result = $"{carry.ToString()}{result}";            

            return result;

        }
    }
}
    