using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace LeetCodeBinaryTree
{
    //https://leetcode.com/problems/validate-binary-search-tree/
    public class ValidateBinarySearchTree
    {

        public static void Demo()
        {
            string s = "5,1,4,null,null,3,6";
            BinaryTree binarytree = new BinaryTree(s);
            Console.WriteLine("Result:");
            bool result = new ValidateBinarySearchTree().IsValidBST_recursive(binarytree.Root);
            Console.WriteLine(result.ToString());
            result = new ValidateBinarySearchTree().IsValidBST_Nonrecursive(binarytree.Root);
            Console.WriteLine(result.ToString());

        }
        private TreeNode prev = null;
        public bool IsValidBST_recursive(TreeNode root)
        {
            //Basically we are doing an inorder traversal here
            //and at each step the prev variable is the last element in traversal
            //so all that we need to do is check if current item is not less than equal to last item        

            //reached to the end
            if (root == null) return true;

            //keep traversing the tree to the left
            bool left = IsValidBST_recursive(root.left);

            //optimization to save time if left is already known to be not valid BST
            if (left == false)
                return false;

            //check if current element is less than last element then not BST
            if (prev != null && root.val <= prev.val) return false;

            //Current elelment becomes the last element for next set
            //we already checked left side. Now we must check right side
            //for right side root becomes previous element (remember, in order: L-> N -> R)
            prev = root;

            //check if right subtree is a valid BST
            return IsValidBST_recursive(root.right);
        }

        public bool IsValidBST_Nonrecursive(TreeNode root)
        {
            TreeNode prev = null;
            Stack<TreeNode> stack = new Stack<TreeNode>();

            //1. pick a element, 
            //2. traverse all the way to the left
            //3. pop item from last (the last item in inorder traversal)
            //4. check if current item is less than last item
            //5. make current element as last item
            //6. make right node as current elelment for next iteration
            while (stack.Count > 0 || root != null)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                if (prev != null && root.val <= prev.val)
                    return false;
                prev = root;
                root = root.right;
            }
            return true;
        }
    }
}
