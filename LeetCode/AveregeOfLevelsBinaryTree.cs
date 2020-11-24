using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace LeetCode
{
    class AveregeOfLevelsBinaryTree
    {
        //637: https://leetcode.com/problems/average-of-levels-in-binary-tree/description/

        public static void Demo()
        {
            BST BST = new BST();
            BST.AddNodes("12,10,9,11,14,13,15,6,17,16,100,2,25");
            BST.PrintInFix();
            foreach (var item in AverageOfLevels(BST.Root))
            {
                Console.WriteLine(item);
            } 
        }

        //Here in each iteration we are covering one level
        //We are starting from root
        //First time only root is at 0 level
        //we put this item in queue Q1
        //in inner loop we deque from queue Q1 and for each dequed item we put left right in another queue Q2
        //basically all nodes for next level we are putting in Q2
        //after end of inner loop we again run a loop to transfer items from Q2 to Q1
        //So that in next iteration of outer loop we can expect all items of next level will be in Q1
        public static IList<double> AverageOfLevels(TreeNode root)
        {

            if (root == null)
                return null;

            IList<double> average = new List<double>();
            var Q1 = new Queue<TreeNode>();
            var Q2 = new Queue<TreeNode>();
            Q1.Enqueue(root);
            while (Q1.Count > 0)
            {
                double sum = 0;
                int count = 0;
                while (Q1.Count > 0)
                {
                    var curr = Q1.Dequeue();
                    sum += curr.val;
                    count++;

                    if (curr.left != null)
                        Q2.Enqueue(curr.left);
                    if (curr.right != null)
                        Q2.Enqueue(curr.right);

                }
                average.Add(sum / count);

                
                Q1 = Q2; //Q2 becomes Q1 for next iteration, istead of copy items one by one, just change the reference
                Q2 = new Queue<TreeNode>(); //reset Q to empty;
            }
            return average;
        }
    }
}
