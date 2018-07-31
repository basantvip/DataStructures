using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class TotalHammingDistance
    {
        public static void Demo()
        {
            List<int> list = new List<int>() { 4, 14, 2 };
            foreach (var item in list)
            {                
                HammingDistance.PrintBits(item);
                Console.WriteLine();
            }

            Console.WriteLine($"Total Hamming Distance:{GetTotalHammingDistance(list)}");

        }

        public static int GetTotalHammingDistance(List<int> nums)
        {
            int res = 0, n = nums.Count;
            for (int i = 0; i < 32; ++i)
            {
                int cnt = 0;
                foreach (var num in nums)              
                {   
                    if ((num & i << i) > 0)
                        ++cnt;
                }
                res += cnt * (n - cnt);
            }
            return res;
        }
    }
}
