using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class BrickWall
    {
        //554: https://leetcode.com/problems/brick-wall/description/

        public static void Demo()
        {
            List<List<int>> wall = new List<List<int>>();
            wall.Add(new List<int>() { 1, 2, 2, 1 });
            wall.Add(new List<int>() { 3, 1, 2 });
            wall.Add(new List<int>() { 1, 3, 2 });
            wall.Add(new List<int>() { 2, 4 });
            wall.Add(new List<int>() { 3, 1, 2 });
            wall.Add(new List<int>() { 1, 3, 1, 1 });
            Console.WriteLine(leastBricks(wall));
            Console.WriteLine(leastBricks_v1(wall));
        }

        public static int leastBricks(List<List<int>> wall)
        {
            var edgesPerColumn = new Dictionary<int, int>();
            var maxEdgeCount = 0;
            foreach (var row in wall)
            {
                var currentEdge = 0;
                for (var i = 0; i < row.Count - 1; i++)
                {
                    currentEdge = currentEdge + row[i];
                    int currentEdgeCount = 0;
                    edgesPerColumn.TryGetValue(currentEdge, out currentEdgeCount);
                    edgesPerColumn[currentEdge] = ++currentEdgeCount;
                    if (currentEdgeCount > maxEdgeCount)
                    {
                        maxEdgeCount = currentEdgeCount;
                    }
                }
            }
            return wall.Count - maxEdgeCount;
        }

        public static int leastBricks_v1(List<List<int>> wall)
        {
            var edgeList = new Dictionary<int, int>();
            
            foreach (var row in wall)
            {
                var currentEdge = 0;
                for (var i = 0; i < row.Count - 1; i++)
                {
                    currentEdge = currentEdge + row[i];
                    if (edgeList.ContainsKey(currentEdge))
                        edgeList[currentEdge]++;
                    else
                        edgeList.Add(currentEdge, 1);
                }
            }
            foreach (var item in edgeList)
            {
                Console.WriteLine($"key:{item.Key}, Value: {item.Value}");
            }

            return wall.Count - edgeList.OrderByDescending(t => t.Value).First().Key;

        }

    }
}
