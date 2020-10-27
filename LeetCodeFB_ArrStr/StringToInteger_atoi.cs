using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB_ArrStr
{
    class StringToInteger_atoi
    {
        //https://leetcode.com/problems/string-to-integer-atoi/
        public static void Demo()
        {
            string str = "4193 with words";
            Console.WriteLine($"input:{str}");
            Console.WriteLine($"output:{GetInteger(str)}");
        }

        public static int GetInteger(string str)
        {
            //check for empty string or null input
            if (str == null || str.Length == 0)
                return 0;
            int i = 0, sign = 1, result = 0;

            //skip leading spaces
            while (i < str.Length && str[i] == ' ')
                i++;

            //get the sign
            sign = (i < str.Length && (str[i] == '+' || str[i] == '-')) ? ((str[i++] == '+') ? 1 : -1) : 1;

            //build the number with taking care of overflow
            while (i < str.Length && str[i] >= '0' && str[i] <= '9')
            {
                int digit = str[i++] - '0';

                //max and min both can be handled with same condition
                if (result > (int.MaxValue / 10) || (result == (int.MaxValue / 10) && digit > int.MaxValue % 10))
                    return (sign == -1) ? int.MinValue : int.MaxValue;

                result = result * 10 + digit;

            }

            return result * sign;
        }
    }
}
