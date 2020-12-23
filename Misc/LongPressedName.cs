using System;
using System.Collections.Generic;
using System.Text;

namespace Misc
{
    public class LongPressedName
    {
        //https://leetcode.com/problems/long-pressed-name
        public static void Demo()
        {
            string name = "alex";
            string typed = "aaleex";

            Console.Write($"name: {name} ; typed: {typed}");
            Console.Write($"\nOutput:{IsLongPressedName(name,typed)}");            
        }

        public static bool IsLongPressedName(string name, string typed)
        {

            if (name.Length > typed.Length)
                return false;

            int i = 0, j = 0;
            while (j < typed.Length)
            {
                //characters match in both the arrays
                if (i < name.Length && name[i] == typed[j])
                    i++;

                //first charcteter in typed array or current char does not macth with prev char in typed array
                //return false
                else if (j == 0 || typed[j] != typed[j - 1])
                    return false;

                j++;

            }
            //coming here means 2nd array completed, so the first array must complete as well
            return i == name.Length;
        }
    }
}
