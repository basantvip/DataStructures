using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB_ArrStr
{
    class IntegerToEnglishWords
    {
        public static void Demo()
        {
            int num = 12345;

            Console.WriteLine($"input: {num}");            
            Console.WriteLine($"\noutput: {IntegerToEnglishWords_internal(num)} ");
        }

        public static string IntegerToEnglishWords_internal(int num)
        {
            if (num == 0)
            {
                return "Zero";
            }
            return helper(num);
        }

        public static String helper(int num)
        {
            String[] words = new String[] {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
            String[] LargerWords = new String[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            
            StringBuilder res = new StringBuilder();

            if (num >= 1000000000)
                res.Append(helper(num / 1000000000)).Append(" Billion ").Append(helper(num % 1000000000));            
            else if (num >= 1000000)
                res.Append(helper(num / 1000000)).Append(" Million ").Append(helper(num % 1000000));            
            else if (num >= 1000)
                res.Append(helper(num / 1000)).Append(" Thousand ").Append(helper(num % 1000));            
            else if (num >= 100)
                res.Append(helper(num / 100)).Append(" Hundred ").Append(helper(num % 100));            
            else if (num >= 20)
                res.Append(LargerWords[num / 10]).Append(" ").Append(words[num % 10]);            
            else
            {
                res.Append(words[num]);
            }

            return res.ToString().Trim();

        }
    }
}
