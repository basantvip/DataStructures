using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace LeetCode
{
    class SubTree
    {
        public static void Demo()
        {
            BST MainTree = new BST();
            Console.WriteLine("MainTree");
            MainTree.AddNodes("10,8,6,12,14,11,13");

            Console.WriteLine("SubTree");
            BST SubTree = new BST();
            SubTree.AddNodes();

            Console.WriteLine(IsSubTree(MainTree,SubTree));


        }

        public static bool IsSubTree(BST mainTree, BST subTree)
        {
            return IsSubTree(mainTree.Root,subTree.Root);            
        }

        public static bool IsSubTree(TreeNode mainTree, TreeNode subTree)
        {
            if ((mainTree == null && subTree == null) || subTree == null)
                return true;
            else if (mainTree == null)
                return false;

            if (mainTree.val == subTree.val)
            {
                return (IsSubTree(mainTree.left, subTree.left) && IsSubTree(mainTree.right, subTree.right));
            }
            return (IsSubTree(mainTree.left,subTree) || IsSubTree(mainTree.right,subTree));

        }
    }
}
