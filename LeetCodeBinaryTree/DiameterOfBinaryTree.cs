using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace LeetCodeBinaryTree
{
    //https://leetcode.com/problems/diameter-of-binary-tree/
    public class DiameterOfBinaryTree
    {       
        public static void Demo()
        {
            BinaryTree binaryTree = new BinaryTree("3,9,20,12,18,15,7");
            helper(binaryTree.Root);            
            Console.WriteLine($"Diameter:{diameter}");
        }

        static int diameter = 0;

        public static int helper(TreeNode root)
        {
            //if null element, nothing gets added to the parent
            if (root == null)
                return 0;

            //if leaf element, return one to its parent
            //note that this also covers the edge condition where only 1 element present in the tree
            //in that case even though we are returning 1 to caller but we are not updating max
            //so the result will still be 0
            if (root.left == null && root.right == null)
                return 1;

            //get the left and child sub tree length
            int left = helper(root.left);
            int right = helper(root.right);

            //check if current nodes gives the max length
            diameter = Math.Max(diameter, left + right);

            //return to parent the max of (left or right subtree length) + 1
            //note here we cannot select both left and right because that will close the path
            return Math.Max(left, right) + 1;
        }
    }
}
