using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace LeetCodeBinaryTree
{
    //https://leetcode.com/problems/flatten-binary-tree-to-linked-list/
    public class FlattenBinaryTreeToLinkedList
    {

        public static void Demo()
        {
            string s = "1,2,5,3,4,null,6";
            BinaryTree binarytree = new BinaryTree(s);
            new FlattenBinaryTreeToLinkedList().Flatten(binarytree.Root);
            Console.WriteLine("Result:");
            binarytree.print2D(binarytree.Root);            

        }

        public void Flatten(TreeNode root)
        {
            //if null or leaf node do nothing
            //remember if just left is null we still need to flatten the right side
            if (root == null || (root.left == null && root.right == null))
                return;

            //if there is something on left to move to right
            if (root.left != null)
            {
                //attach left to the right
                TreeNode temp = root.right; //hold right side in a temp variable
                //the root.left will be flattened later on in recursive call. 
                //For now - assign it to right side of root
                root.right = root.left;
                root.left = null;
                TreeNode right = root; //keeping it so that later on we can make recursive call
                if (temp != null) //the temp should be attached to the end of right sub tree now. check if there was something in temp
                {
                    while (right.right != null) //keep moving to right and attach at the end
                        right = right.right;
                    right.right = temp;

                }
            }

            //at this point root is already moved to the end of flattended tree. 
            //after this point right side is not flattend.
            if (root.right != null)
                Flatten(root.right);

        }

    }
}
