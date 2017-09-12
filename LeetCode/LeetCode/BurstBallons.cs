using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class BurstBallons
    {

        public static void Demo()
        {
            var s = "3,1,5,8";
            int i;
            var list = s.Split(',').Where(t => int.TryParse(t, out i)).Select(int.Parse).ToArray();
            Array.ForEach(list, t => Console.WriteLine($"{t},"));
            Console.WriteLine(MaxCoins(list));
        }
        public static int MaxCoins(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            var n = nums.Length;
            var num = new int[n + 2];
            num[0] = 1;
            for (var i = 0; i < n; i++)
                num[i + 1] = nums[i];
            num[n + 1] = 1;

            return DfsCache(num, 1, n);
        }

        private static int DfsCache(int[] num, int left, int right)
        {
            var n = right - left + 1 + 2;
            var cache = new int[n,n];

            return DfsCache(num, left, right, cache);
        }
        private static int DfsCache(int[] num, int left, int right, int[,] cache)
        {
            if (cache[left,right] != 0)
                return cache[left,right];
            var coins = 0;
            for (var i = left; i <= right; i++)
            {
                var l = 0;
                if (i > left)
                    l = DfsCache(num, left, i - 1, cache);

                var r = DfsCache(num, i + 1, right, cache);
                var val = num[left - 1] * num[i] * num[right + 1] + l + r;
                coins = Math.Max(coins, val);
            }
            cache[left,right] = coins;
            return coins;
        }

        public static string GetArrayString(int[] arr,int left, int right)
        {
            return string.Join(",", arr.Skip(left).Reverse().Skip(arr.Length-right-1).Reverse().ToArray());
        }
    }
}
