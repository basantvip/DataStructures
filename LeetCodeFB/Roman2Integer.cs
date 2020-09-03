using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB
{
    class Roman2Integer
    {
        public static void Demo()
        {
            string str = "MCMXCIV";
            Console.WriteLine($"input:{str}");
            Console.WriteLine($"output:{RomanToInt(str)}");
        }

        public static int RomanToInt(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>()
                {
                    {'I',1},
                    {'V',5},
                    {'X',10},
                    {'L',50},
                    {'C',100},
                    {'D',500},
                    {'M',1000}
                };

            int Result = 0;
            int LastDigit = 0;
            foreach (var curr in s)
            {
                var CurrDigit = map[curr];

                //If not First Character and previous char is less than curr char, update current digit
                if (LastDigit > 0 && LastDigit < CurrDigit)
                    CurrDigit = CurrDigit - LastDigit;
                else
                    Result += LastDigit;

                LastDigit = CurrDigit;

            }

            //Here since we are moving one char ahead, the last one will be remaining
            return Result + LastDigit;
        }
    }
}
