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
            BST BST = new BST();
            BST.AddNodes();
            Console.Write("Enter a Sum:");
            int sum = int.Parse(Console.ReadLine());
            Console.WriteLine(FindTarget(BST.Root, sum));
        }

        public static HashSet<int> hashSet = new HashSet<int>();
        public static bool FindTarget(TreeNode root, int k)
        {
            if (root == null)
                return false;
            if (hashSet.Contains(root.val))
                return true;
            else
                hashSet.Add(k - root.val);
            return (FindTarget(root.left, k) || FindTarget(root.right, k));
        }
    }
}
