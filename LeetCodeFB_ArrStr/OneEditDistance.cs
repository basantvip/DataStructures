using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeFB_ArrStr
{
    class OneEditDistance
    {
        //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3013/
        public static void Demo()
        {
            
            string s = "cd";
            string t = "e";
            Console.WriteLine($"string1:{s}");
            Console.WriteLine($"string2:{t}");
            Console.WriteLine($"Result:{IsOneEditDistance(s, t)}");           
        }

        public static bool IsOneEditDistance(string s, string t)
        {
            int s_len = s.Length, t_len = t.Length;
            
            //to simply make sure s is not greater than t 
            //which means we dont need to worry about delete a char from s
            //so only two scenarios: replace or insert in s
            if (s_len > t_len)
                return IsOneEditDistance(t, s);

            //differ more than 1 char or exactly equal
            if (t_len - s_len > 1 || s == t)
                return false;

            bool OneEditDistance = false;
            for (int i = 0, j = 0; i < s_len; i++, j++)
            {
                if (s[i] != t[j])
                {
                    //already OneEditDistance found before
                    if (OneEditDistance)
                        return false;
                    
                    //flip the bit to mark that 1st diff found
                    OneEditDistance = true;

                    //for replacement scenarion nothing special need to be done, just regular i and j pointer increment
                    //for insert scenario, instead of inserting just move the s pointer to 1 back, 
                    //so that in next interation we can check currenr char of s with next char of t
                    if (t_len > s_len)
                        i--;
                }
            }

            //coming here means all 
            return true;
        }
    }
}
    