using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace LeetCodeBinaryTree
{
    //https://leetcode.com/problems/average-of-levels-in-binary-tree/
    public class AverageOfLevels
    {       
        public static void Demo()
        {
            BinaryTree binarytree = new BinaryTree("3,9,20,12,18,15,7");
            Console.WriteLine("AverageOfLevels:");
            var list = helper(binarytree.Root);
            foreach (var item in list)
            {
                Console.Write($"{item},");
            }
        }


        //its basically a breadth first search (BFS)
        //but the only difference is 
        //in BFS in each iteration we dequeue an item and then put its left and right in queue for next iteration
        //here we have to do 2 iteration.
        //In each iteration of outer loop, we have to empty the queue to make sure we cover all the nodes of a level
        //for each of these nodes put left and right in a separate temp queue, preparing for next itertaion (or level)
        //after the end of inner loop we copy the contents from temp queue to main queue (actually insread of copy just update the pointers)
        public static IList<double> helper(TreeNode root)
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

                Q1 = Q2;
                Q2 = new Queue<TreeNode>();
            }
            return average;
        }
    }
}
