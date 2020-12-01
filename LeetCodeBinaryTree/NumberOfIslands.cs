using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace LeetCodeBinaryTree
{
    //https://leetcode.com/problems/number-of-islands/
    public class NumberOfIslands
    {       
        public static void Demo()
        {
            char[][] grid = new char[][] 
                { 
                    new char[] { '1', '1', '0', '0', '0' },
                    new char[] { '1', '1', '0', '0', '0' },
                    new char[] { '0', '0', '1', '0', '0' },
                    new char[] { '0', '0', '0', '1', '1' } 
                };

            Console.WriteLine($"\nInput Grid: ");
            foreach (var item in grid)
            {
                foreach (var subitem in item)
                {
                    Console.Write($"{subitem},");
                }
                Console.WriteLine("");
            }
            Console.WriteLine($"NumberOfIslands:{helper(grid)}");            
        }

        public static int helper(char[][] grid)
        {
            int islands = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        //the goal here is once you find a '1', make all the neighbour as 0.
                        //so that they are not counted again.
                        DFS(grid, i, j);
                        islands++;
                    }
                }
            }
            return islands;
        }

        private static void DFS(char[][] grid, int i, int j)
        {
            //if the current element is 1 then we have to return 1 
            //but we need to make sure that we set all connected bits to 0
            //so that they are not counted again
            //note that we are not recursively adding the counts
            //we are recursively flipping the 1's to 0
            //and returing only 1 for that entire group (island)
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length || grid[i][j] == '0')
                return;

            grid[i][j] = '0';
            DFS(grid, i + 1, j);
            DFS(grid, i - 1, j);
            DFS(grid, i, j + 1);
            DFS(grid, i, j - 1);
            return;
        }
    }
}
