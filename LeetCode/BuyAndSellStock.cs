using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class BuyAndSellStock
    {
        public static void Demo()
        {
            List<int> PriceList = new List<int>() { 7, 1, 5, 0, 3, 6, 4, 17 };
            Console.WriteLine(maxProfit(PriceList));
            Console.WriteLine(maxProfitV1(PriceList));

        }

        public static int maxProfit(List<int> prices)
        {
            int maxCur = 0, maxSoFar = 0;
            for (int i = 1; i < prices.Count; i++)
            {
                maxCur = Math.Max(0, maxCur += prices[i] - prices[i - 1]);
                maxSoFar = Math.Max(maxCur, maxSoFar);
            }
            return maxSoFar;
        }

        public static int maxProfitV1(List<int> prices)
        {
            int max = 0, min = int.MaxValue, minIndex=0, maxIndex = 0;
            for (int i = 1; i < prices.Count; i++)
            {
                if (prices[i] < min)
                {
                    min = prices[i];
                    minIndex = i;
                }
                else if (prices[i] > min)
                {
                    if (max < prices[i] - min)
                        maxIndex = i;
                    max = Math.Max(max, prices[i] - min);

                }                

            }

            Console.WriteLine($"MinIndex:{minIndex}, MaxIndex{maxIndex}");
            return max;
            
        }
    }
}
