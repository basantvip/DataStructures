﻿using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace LeetCodeBinaryTree
{
    public class BFS
    {
        //In BFS use queue, in DFS use stack
        //In each iteration we dequeue an item from the queue and then put its left and right in queue
        //coninue doing this till queue is empty
        public static void Demo()
        {
            BinaryTree binarytree = new BinaryTree("3,9,20,12,18,15,7");
            Console.WriteLine("BFS Traversal:");
            var queue = new Queue<TreeNode>();
            if (binarytree.Root != null)
                queue.Enqueue(binarytree.Root);
            while (queue.Count > 0)
            {
                var s = queue.Dequeue();
                Console.Write($"{s.ToString()} -> ");
                if (s.left != null)
                    queue.Enqueue(s.left);
                if (s.right != null)
                    queue.Enqueue(s.right);
            }
            Console.WriteLine();
        }
    }
}
