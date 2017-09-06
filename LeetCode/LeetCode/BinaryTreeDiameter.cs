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
        
        public static void Demo()
        {
            //BinaryTree BST = new BinaryTree("20,10,6,5,9,8,7,11,13,12,14,15,21,22");
            BinaryTree BST = new BinaryTree("10,6,17");
            BST.PrintPreFix();
            Console.WriteLine(GetBinaryTreeDiameter(BST));
        }        

        public static int GetBinaryTreeDiameter(BinaryTree BST)
        {
            int diameter = 0;
            GetDepth(BST.Root, ref diameter);
            return diameter;

        }
        public static int GetDepth(Node root, ref int diameter)
        {
            if (root == null)
                return 0;
            var LH = GetDepth(root.Left, ref diameter);
            var RH = GetDepth(root.Right, ref diameter);

            if (diameter < LH + RH)
                diameter = LH + RH;
            return Math.Max(LH, RH) + 1;            
        }


    }
        
    
}
