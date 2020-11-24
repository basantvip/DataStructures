using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace LeetCodeBinaryTree
{
    public class BFS_Invert
    {       
        public static void Demo()
        {
            BinaryTree binarytree = new BinaryTree("3,9,20,12,18,15,7");
            Console.WriteLine("BFS Invert Traversal:");
            var queue = new Queue<TreeNode>();
            var stack = new Stack<TreeNode>();
            if (binarytree.Root != null)
                queue.Enqueue(binarytree.Root);
            while (queue.Count > 0)
            {
                var s = queue.Dequeue();
                stack.Push(s);
                if (s.right != null)
                    queue.Enqueue(s.right);
                if (s.left != null)
                    queue.Enqueue(s.left);
            }
            while (stack.Count > 0)
            {
                Console.Write($"{stack.Pop().ToString()} -> ");
            }

            Console.WriteLine();
        }        
    }
}
