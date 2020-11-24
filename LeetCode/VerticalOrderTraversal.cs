using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace LeetCode
{
    class VericalOrderTraversal
    {
        //637: https://leetcode.com/problems/average-of-levels-in-binary-tree/description/

        public static void Demo()
        {
            BST BST = new BST();
            BST.AddNodes("12,10,9,11,14,13,15,6,17,16,100,2,25");
            BST.PrintInFix();
            Traverse(BST.Root, 0);


            Console.WriteLine($"\noutput: ");
            foreach (var item in result.Values)
            {
                Console.Write("{");
                foreach (var subitem in item)
                {
                    Console.Write($"{subitem},");
                }
                Console.Write("}\n");
            }
        }

        static SortedDictionary<int, List<TreeNode>> result = new SortedDictionary<int, List<TreeNode>>();

        public static void Traverse(TreeNode root, int width)
        {
            if (root == null)
                return;
            
            if (!result.ContainsKey(width))
                result.Add(width, new List<TreeNode>());

            result[width].Add(root);

            Traverse(root.left, width - 1);
            Traverse(root.right, width + 1);            
        }
    }
}
