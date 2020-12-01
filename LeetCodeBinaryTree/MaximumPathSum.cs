using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace LeetCodeBinaryTree
{
    //https://leetcode.com/problems/binary-tree-maximum-path-sum/
    public class MaximumPathSum
    {       
        public static void Demo()
        {
            BinaryTree binarytree = new BinaryTree("3,9,20,12,18,15,7");            
            helper(binarytree.Root);
            Console.WriteLine($"MaximumPathSum:{max_path}");
        }

        static int max_path = int.MinValue;

        public static int helper(TreeNode root)
        {
            if (root == null)
                return 0;

            //dont need to include left or right side if they are negative
            int left = helper(root.left);
            int right = helper(root.right);

            //if neagtive, dont pickup
            if (left < 0)
                left = 0;

            if (right < 0)
                right = 0;

            //check if current node gives max
            int current_path = left + right + root.val;
            max_path = Math.Max(max_path, current_path);

            //need to return the max value from current node
            //this must include the node, otherwise chain will be broken
            //This can not include both left and right as that will close the path
            return root.val + Math.Max(left, right);
        }
    }
}
