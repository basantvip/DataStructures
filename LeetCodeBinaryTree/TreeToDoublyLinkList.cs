using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace LeetCodeBinaryTree
{
    public class TreeToDoublyLinkList
    {
        //https://leetcode.com/problems/convert-binary-search-tree-to-sorted-doubly-linked-list/
        //no testing for this problem
        //just understand the logic
        public static void Demo()
        {
            BinaryTree binarytree = new BinaryTree("3,9,20,12,18,15,7");
            TreeToDoublyList(binarytree.Root);
        }

        public static TreeNode TreeToDoublyList(TreeNode root)
        {

            helper(root);

            if (last != null && first != null)
            {
                last.right = first;
                first.left = last;
            }

            return first;
        }

        static TreeNode last, first = null;

        //the idea here is to keep two global variable first and last
        //in recursive call (in order traversal) do below
        //--> call recursive left
        //--> set the first variable if not already set (this is required for final connection and return as well)   
        //--> current.left=last
        //--> last.right=current
        //--> set current as last    
        //--> call recursive right
        public static void helper(TreeNode root)
        {
            if (root == null)
                return;
            
            helper(root.left);
            
            if (first == null)
                first = root;
            
            root.left = last;
            
            if (last != null)
                last.right = root;
            
            last = root;
            
            helper(root.right);
        }
    }
}
