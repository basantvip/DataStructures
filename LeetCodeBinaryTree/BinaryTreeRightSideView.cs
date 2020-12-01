using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace LeetCodeBinaryTree
{
    //https://leetcode.com/problems/binary-tree-right-side-view/
    public class BinaryTreeRightSideView
    {       
        public static void Demo()
        {
            BinaryTree binarytree = new BinaryTree("3,9,20,null,null,12,18,15,7");
            Console.WriteLine("BinaryTreeRightSideView:");
            var list = helper(binarytree.Root);
            foreach (var item in list)
            {
                Console.Write($"{item},");
            }
        }

        public static List<int> list = new List<int>();

        public static IList<int> helper(TreeNode root)
        {
            helper(root, 0);
            return list;
        }

        //Here the logic is we are always traversing right side first
        //the first element found for a depth is the right side view
        //how do we find if this is the first element at nth level ?
        //by checking if we have added nth item in the output list
        public static void helper(TreeNode root, int depth)
        {
            if (root == null)
                return;

            //we started adding from depth 0
            //this is to make sure that we haven't already added rightmost element as this level
            if (depth >= list.Count)
                list.Add(root.val);

            helper(root.right, depth + 1); //start from right side
            //note that we still need to do left because we dont know if deep down this path there will be a node with right side view
            helper(root.left, depth + 1);  //and then left

        }
    }
}
