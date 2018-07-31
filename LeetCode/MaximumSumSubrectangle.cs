using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class MaximumSumSubrectangle
    {
        public static void Demo()
        {
            int[,] arr = new int[4, 5] 
                { 
                    { 2,  1, -3, -4,  5 }, 
                    { 0,  6,  3,  4,  1 }, 
                    { 2, -2, -1, -1, -5 }, 
                    { 8, 3,  1,  0,  3 }
                };
            int max_left, max_right, max_up, max_down;
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);            

            var max = GetMaximumSumSubrectangle(arr, rows, cols, out max_left, out max_right, out max_up, out max_down);
            Console.WriteLine($"Max Sum:{max}, Left Bound:{max_left}, Right Bound:{max_right}, Upper Bound:{max_up}, Lower Bound:{max_down}");
        }

        public static int GetMaximumSumSubrectangle(int [,] arr, int rows, int cols, out int max_left, out int max_right, out int max_up, out int max_down)
        {
            int[] temp = new int[rows];
            int curr_max, max = arr[0,0];
            max_left = max_right = max_up = max_down = 0;

            int curr_max_up, curr_max_down = 0;

            for (int Left = 0; Left < cols; Left++)
            {
                Array.Clear(temp, 0, rows);
                for (int Right = Left; Right < cols; Right++)
                {
                    for (int row = 0; row < rows; row++)
                    {
                        temp[row] += arr[row, Right];
                    }
                    curr_max = MaxSumSubArray_Kadane.GetMaxSumSubArray_Kadane(temp.ToList(), out curr_max_up, out curr_max_down);
                    if (max < curr_max)
                    {
                        max = curr_max;
                        max_up = curr_max_up;
                        max_down = curr_max_down;
                        max_left = Left;
                        max_right = Right;
                    }
                }
            }
            return max;
        }
        
    }
}
