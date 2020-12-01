using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace LeetCodeBinaryTree
{
    //https://leetcode.com/problems/clone-graph/
    //no testing for this problem
    //just understand the logic
    public class CloneGraph
    {       
        public static void Demo()
        {
            GraphNode node = new GraphNode();
            helper(node);
        }

        public static Dictionary<GraphNode, GraphNode> map = new Dictionary<GraphNode, GraphNode>();
        public static GraphNode helper(GraphNode node)
        {
            if (node == null)
                return null;

            //to avoid circular loop get the clone if it was already visited
            if (map.ContainsKey(node))
                return map[node];

            //create a clone with empty neighbors 
            var clone = new GraphNode(node.val,new List<GraphNode>());

            //add to the list so that we dont clone this node again
            map.Add(node, clone);

            //now lets populate neighbors of clone
            foreach (var neighbor in node.neighbors)
                clone.neighbors.Add(helper(neighbor));

            return clone;

        }
    }
}
