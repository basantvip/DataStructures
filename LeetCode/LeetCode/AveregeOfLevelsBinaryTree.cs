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
        public static void Demo()
        {
            BinaryTree BST = new BinaryTree();
            BST.AddNodes("12,10,9,11,14,13,15,6,17");
            BST.PrintInFix();

            Queue<Node> queue = new Queue<Node>();
            Queue<Node> tempQueue = new Queue<Node>();            

            if (BST.Root == null)
                return;
            queue.Enqueue(BST.Root);
            while (queue.Count > 0)
            {                
                double sum = 0.0;
                int count = 0;                
                while (queue.Count > 0)
                {
                    var s = queue.Dequeue();
                    sum = sum + s.Value;
                    count++;
                    if (s.Left != null)
                        tempQueue.Enqueue(s.Left);
                    if (s.Right != null)
                        tempQueue.Enqueue(s.Right);
                }

                Console.WriteLine($"Sum:{sum}, Count:{count}, Average: {sum/count}");
                
                while (queue.Count > 0)
                    queue.Dequeue();

                while (tempQueue.Count > 0)
                    queue.Enqueue(tempQueue.Dequeue());
                

            }
        }
    }
}
