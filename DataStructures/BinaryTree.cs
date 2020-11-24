using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{ 
    public class BinaryTree
    {
        public int Count { get; set; }

        public TreeNode Root { get; set; }

        public BinaryTree()
        {
            Count = 0;
        }

        public BinaryTree(string s)
        {
            s = s.Trim();
            Console.WriteLine($"Input String:{s}");
            List<string> list = s.Split(',').Select(t => t.ToUpper()).ToList();
            if (list.Count == 0 || list[0]=="NULL")
                return;
            Queue<TreeNode> Q1 = new Queue<TreeNode>();
            Root = new TreeNode(Convert.ToInt32(list[0]));
            Count++;
            Q1.Enqueue(Root);
            for(int i=0 ; i<list.Count;)
            {
                var currNode = Q1.Dequeue();
                if (++i < list.Count && list[i] != "NULL")
                {
                    currNode.left = new TreeNode(Convert.ToInt32(list[i]));
                    Q1.Enqueue(currNode.left);
                    Count++;
                }
                if (++i < list.Count && list[i] != "NULL")
                {
                    currNode.right = new TreeNode(Convert.ToInt32(list[i]));
                    Q1.Enqueue(currNode.right);
                    Count++;
                }               
            }
            print2D(Root);
        }

        public static void Demo()
        {
            string s = "3,9,20,12,18,15,7";
            BinaryTree tree = new BinaryTree(s);

            while (true)
            {                
                Console.Write("\n\t1.Print Prefix\n\t0:Exit\nEnter Choice: ");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        tree.PrintPreFix();
                        break;
                    case "0":
                        return;
                }
            }
        }        

        public void PrintPreFix()
        {
            Console.Write($"PreFix({this.Count} Items):");
            PrintPreFix(this.Root);
            Console.WriteLine();
        }

        private static void PrintPreFix(TreeNode root)
        {
            if (root == null)
                return;
            Console.Write($"{root.ToString()}");
            PrintPreFix(root.left);
            PrintPreFix(root.right);
        }        

        public int COUNT = 5;

        public void print2DUtil(TreeNode root, int space)
        {
            // Base case  
            if (root == null)
                return;

            // Increase distance between levels  
            space += COUNT;

            // Process right child first  
            print2DUtil(root.right, space);

            // Print current node after space  
            // count  
            Console.Write("\n");
            for (int i = COUNT; i < space; i++)
                Console.Write(" ");
            Console.Write(root.val + "\n");

            // Process left child  
            print2DUtil(root.left, space);
        }

        // Wrapper over print2DUtil()  
        public void print2D(TreeNode root)
        {
            // Pass initial space count as 0  
            print2DUtil(root, 0);
        }
    }
}
