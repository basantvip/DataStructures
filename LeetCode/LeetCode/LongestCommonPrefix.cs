
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class LongestCommonPrefix
    {

        public static void Demo()
        {
            List<string> list = new List<string>() { "ABD", "ABC", "ADEF" };
            var result = FindLongestCommonPrefix(list);
            if (!string.IsNullOrEmpty(result))
                Console.WriteLine(result);
            else
                Console.WriteLine("No common prfix");
            Console.ReadLine();
        }
        public static string FindLongestCommonPrefix(List<string> list)
        {
            if (list.Count == 0)
                return "";
            var lastCommon = list[0];
            for (var i=1;i<list.Count;i++)
            {
                lastCommon = FindLongestCommonPrefix(lastCommon, list[i]);
            }
            return lastCommon;
        }

        private static string FindLongestCommonPrefix(string s1, string s2)
        {
            var commonMaxIndex = 0;
            var len = s1.Length < s2.Length ? s1.Length : s2.Length; 
             
            while (commonMaxIndex < len)
            {
                if (s1[commonMaxIndex] != s2[commonMaxIndex])
                    break;
                commonMaxIndex++;
            }

            return (s1.Substring(0, commonMaxIndex));
        }
    }
}
