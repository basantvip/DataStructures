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
            BinaryTree MainTree = new BinaryTree();
            Console.WriteLine("MainTree");
            MainTree.AddNodes("10,8,6,12,14,11,13");

            Console.WriteLine("SubTree");
            BinaryTree SubTree = new BinaryTree();
            SubTree.AddNodes();

            Console.WriteLine(IsSubTree(MainTree,SubTree));


        }

        public static bool IsSubTree(BinaryTree mainTree, BinaryTree subTree)
        {
            return IsSubTree(mainTree.Root,subTree.Root);            
        }

        public static bool IsSubTree(Node mainTree, Node subTree)
        {
            if ((mainTree == null && subTree == null) || subTree == null)
                return true;
            else if (mainTree == null)
                return false;

            if (mainTree.Value == subTree.Value)
            {
                return (IsSubTree(mainTree.Left, subTree.Left) && IsSubTree(mainTree.Right, subTree.Right));
            }
            return (IsSubTree(mainTree.Left,subTree) || IsSubTree(mainTree.Right,subTree));

        }
    }
}
