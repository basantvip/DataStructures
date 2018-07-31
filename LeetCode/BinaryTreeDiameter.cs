using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace LeetCode
{
    class BinaryTreeDiameter
    {
        //543: https://leetcode.com/problems/diameter-of-binary-tree/description/

        public static void Demo()
        {
            BinaryTree BST = new BinaryTree("100,10,6,5,9,8,7,11,13,12,14,15,21,22");
            //BinaryTree BST = new BinaryTree("10,6,17");
            BST.PrintPreFix();
            Console.WriteLine($"Diameter: {GetBinaryTreeDiameter(BST)}");
        }        

        public static int GetBinaryTreeDiameter(BinaryTree BST)
        {
            int diameter = 0;
            Node diameterRoot = null;
            GetDepth(BST.Root, ref diameter, ref diameterRoot);
            Console.WriteLine($"Root of Diameter: {diameterRoot}");
            return diameter;

        }
        public static int GetDepth(Node root, ref int diameter, ref Node diameterRoot)
        {
            if (root == null)
                return 0;
            var LH = GetDepth(root.Left, ref diameter, ref diameterRoot);
            var RH = GetDepth(root.Right, ref diameter, ref diameterRoot);

            if (diameter < LH + RH)
            {
                diameter = LH + RH;
                diameterRoot = root;
            }
            return Math.Max(LH, RH) + 1;            
        }


    }
        
    
}
