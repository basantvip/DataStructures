using System;
using System.Collections.Generic;
using System.Text;

namespace Misc
{
    public class HeightChecker
    {
        //https://leetcode.com/problems/height-checker
        public static void Demo()
        {
            int[] heights = new int[] { 1, 1, 4, 2, 1, 3 };

            Console.Write($"input: ");
            foreach (var item in heights)
            {
                Console.Write($"{item},");
            }

            Console.Write($"\nOutput:{HeightCheckerDemo(heights)}");            
        }

        public static int HeightCheckerDemo(int[] heights)
        {
            if (heights.Length <= 1)
                return heights.Length;

            int[] sortedHeights = new int[heights.Length];
            Array.Copy(heights, sortedHeights, heights.Length);
            Array.Sort(sortedHeights);
            int moves = 0;
            
            for (int i = 0; i < heights.Length; i++)
                if (heights[i] != sortedHeights[i])
                    moves++;
            return moves;
        }
    }
}
