using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace LeetCode
{
    class SortedArrayToBalancedBST
    {
        public static void Demo()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8,9 };
            var BST = GetBalancedBinaryTree(list);
            BST.PrintPreFix();            
        }

        public static BinaryTree GetBalancedBinaryTree(List<int> list)
        {
            BinaryTree BST = new BinaryTree();
            BST.Root = GetBalancedBinaryTree(list, 0, list.Count - 1);
            return BST;
        }


        public static Node GetBalancedBinaryTree(List<int> list, int start, int end)
        {
            if (start > end )
                return null;

            int mid = start == end ? start : start + (end - start) / 2;            
            Node root = new Node(list[mid]);
            root.Left = GetBalancedBinaryTree(list, start, mid - 1);
            root.Right = GetBalancedBinaryTree(list, mid + 1, end);
            return root;

        }

    }
}
