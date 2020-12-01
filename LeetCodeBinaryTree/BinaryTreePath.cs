using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace LeetCodeBinaryTree
{
    //https://leetcode.com/problems/binary-tree-paths/
    //Given a binary tree, return all root-to-leaf paths.
    public class BinaryTreePath
    {       
        public static void Demo()
        {
            BinaryTree binarytree = new BinaryTree("3,9,20,12,18,15,7");
            Console.WriteLine("AverageOfLevels:");
            helper(binarytree.Root,"");
            foreach (var item in result)
            {
                Console.Write($"{item},");
            }
        }

        static IList<string> result = new List<string>();

        public static void helper(TreeNode root, string currentPath)
        {
            if (root == null)
                return;
            if (currentPath == "")
                currentPath = root.val.ToString();
            else
                currentPath = currentPath + "->" + root.val.ToString();

            if (root.left == null && root.right == null)
                result.Add(currentPath);
            helper(root.left, currentPath);
            helper(root.right, currentPath);
        }
    }
}
