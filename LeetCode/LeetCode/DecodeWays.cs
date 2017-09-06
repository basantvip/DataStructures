using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class DecodeWays
    {
        public static void Demo()
        {
            Console.WriteLine("Enter input string of digits");
            var inputString = Console.ReadLine();
            Console.WriteLine($"Number of ways: {Ways(inputString)}");
        }
        public static int Ways(string s)
        {
            if (s == null || s.Length == 0)
            {
                return 0;
            }
            int n = s.Length;
            int[] ways = new int[n + 1];
            ways[n] = 1;
            ways[n - 1] = s[n - 1] == '0' ? 0 : 1;

            for (int i = n - 2; i >= 0; i--)
            {
                Console.WriteLine($"Before: i:{i},ways:{string.Concat(ways)}");
                if (s[i] == '0')
                    continue;
                ways[i] = int.Parse(s[i].ToString()) * 10 + int.Parse(s[i + 1].ToString()) <= 26
                    ? ways[i + 1] + ways[i + 2]
                    : ways[i + 1];
                Console.WriteLine($"After: i:{i},ways:{string.Concat(ways)}");
            }
            return ways[0];
        }
    }
}
