using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace LeetCode
{
    public class TwoSumIV_Input_BST
    {
        public static void Demo()
        {
            BinaryTree BST = new BinaryTree();
            BST.AddNodes();
            Console.Write("Enter a Sum:");
            int sum = int.Parse(Console.ReadLine());
            Console.WriteLine(FindTarget(BST.Root, sum));
        }

        public static HashSet<int> hashSet = new HashSet<int>();
        public static bool FindTarget(Node root, int k)
        {
            if (root == null)
                return false;
            if (hashSet.Contains(root.Value))
                return true;
            else
                hashSet.Add(k - root.Value);
            return (FindTarget(root.Left, k) || FindTarget(root.Right, k));
        }
    }
}
