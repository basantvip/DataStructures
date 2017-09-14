using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class MinimumWindowSubstring
    {
        public static void Demo()
        {
            string S = "ADOBECODEBANC";
            string T = "OABC";
            int start, end;
            Console.WriteLine($"String:{S}");
            Console.WriteLine($"Term to Search:{T}");
            Console.WriteLine($"Result:{GetMinimumWindowSubstring(S, T, out start, out end)}");
            if (end >0 && start >=0)
                Console.WriteLine($"Substring:{S.Substring(start, end - start + 1)}");

        }

        public static int GetMinimumWindowSubstring(string S, string T, out int start, out int end)
        {
            start = end = -1;
            
            var ToBeFound = new HashSet<int>();
            var Min_Length = S.Length+1;

            foreach (var ch in T)
            {
                if (!ToBeFound.Contains(ch))
                    ToBeFound.Add(ch);
            }

            for (int i = 0; i < S.Length; i++)
            {
                var AlreadyFound = new HashSet<int>();
                if (!ToBeFound.Contains(S[i]))
                    continue;
                AlreadyFound.Add(S[i]);
                for (int j = i + 1; j < S.Length; j++)
                {   
                    if (AlreadyFound.Contains(S[j]))
                        continue;

                    if (!ToBeFound.Contains(S[j]))
                        continue;

                    AlreadyFound.Add(S[j]);

                    if (AlreadyFound.Count == ToBeFound.Count)
                    {
                        if (Min_Length > j - i + 1)
                        {
                            start = i;
                            end = j;
                            Min_Length = j - i + 1;
                            break;
                        }
                    }
                }
            }

            return Min_Length;






        }
    }
}
