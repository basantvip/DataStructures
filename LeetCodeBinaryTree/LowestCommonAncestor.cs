using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace LeetCodeBinaryTree
{
    //https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree
    public class LowestCommonAncestor
    {       
        public static void Demo()
        {
            BinaryTree binaryTree = new BinaryTree("3,5,1,6,2,0,8,null,null,7,4");
            int p = 5, q = 8;
            Console.WriteLine($"p:{p}, q:{q}");
            var p_node = BinaryTree.Find(binaryTree.Root, p);
            var q_node = BinaryTree.Find(binaryTree.Root, q);

            Console.WriteLine($"LowestCommonAncestor:{helper(binaryTree.Root, p_node, q_node)}");
        }

        public static TreeNode helper(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;

            if (root == p || root == q)
                return root;

            var left = helper(root.left, p, q);
            var right = helper(root.right, p, q);

            if (left != null && right != null)
                return root;
            else if (left != null)
                return left;
            else if (right != null)
                return right;
            else
                return null;
        }
    }
}
