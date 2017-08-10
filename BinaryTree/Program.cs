using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        public class Node
        {
            public int Value;
            public Node Left;
            public Node Right;

            public Node(int value)
            {
                this.Value = value;
            }
        }

        public class BinaryTree
        {
            public Node Root;
            public int Count;

            public BinaryTree()
            {
                Count = 0; 
            }            

            public void AddNode(int value)
            {
                this.Root = AddNode(this.Root, value);
                this.Count++;
            }

            private static Node AddNode (Node root, int value)
            {
                if (root == null)
                    return new Node(value);
                if (root.Value >= value)
                    root.Left = AddNode(root.Left, value);
                else
                    root.Right = AddNode(root.Right, value);

                return root;
            }

            public void PrintInFix()
            {
                Console.WriteLine($"\nItems Count:{this.Count}");
                PrintInFix(this.Root);
                Console.WriteLine();
            }

            private static void PrintInFix(Node root)
            {
                if (root == null)
                    return;
                PrintInFix(root.Left);
                Console.Write($"{root.Value.ToString()} -> ");
                PrintInFix(root.Right);                
            } 

            public bool Contains(int value)
            {
                return Contains(this.Root, value);
            }

            private bool Contains(Node root, int value)
            {
                if (root == null)
                    return false;
                if (root.Value == value)
                    return true;
                if (root.Value >= value)
                    return Contains(root.Left, value);
                else
                    return Contains(root.Right, value);
            }

            public static Node FindMin(Node root)
            {
                if (root == null)
                    return null;
                if (root.Left == null)
                    return root;
                return FindMin(root.Left);
            }

            public static Node FindMax(Node root)
            {
                if (root == null)
                    return null;
                if (root.Right == null)
                    return root;
                return FindMax(root.Right);
            }

            public void DeleteNode(int value)
            {
                bool IsFound;
                this.Root = DeleteNode(this.Root, value, out IsFound);
                if (IsFound)
                {
                    Console.WriteLine($"Found value {value}");
                    this.Count--;
                }
                else
                    Console.WriteLine($"Not Found value {value}");
            }
            private static Node DeleteNode (Node root, int value, out bool found)
            {
                if (root == null)
                {
                    found = false;
                    return null;
                }

                if (root.Value > value)
                {
                    root.Left = DeleteNode(root.Left, value, out found);
                    return root;
                }

                if (root.Value < value)
                {
                    root.Right = DeleteNode(root.Right, value, out found);
                    return root;
                }
                else //found exact match
                {
                    found = true;

                    //leaf node
                    if (root.Left == null && root.Right == null)
                        return null;

                    //has only left node
                    if (root.Right == null)
                        return root.Left;

                    //has only right node
                    if (root.Left == null)
                        return root.Right;

                    //has both left and right node
                    var temp = FindMin(root.Right);
                    root.Value = temp.Value;
                    root.Right = DeleteNode(root.Right, temp.Value,out found);
                    return root;
                }
            }
            //public int InOrderSuccessor(int value)
            //{
            //    if (Root == null)
            //        return -999;
            //    if (Root.Right <

            //}

            //private static int InOrderSuccessor(Node root, int value)
            //{
            //    if (root == null)
            //        return -999;
            //    if (root.Value >= value)
            //        return InOrderSuccessor(root.Left, value);

            //    if (root.Value < value)
            //        return InOrderSuccessor(root.Right, value);


            //}


        }
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            Random rnd = new Random();
            for (int i = 0; i < 9; i++)
            {
                int value = rnd.Next(1, 10);
                if (tree.Contains(value))
                {
                    i--;
                    continue;
                }
                Console.Write($"{value},");
                tree.AddNode(value);
            }
            tree.PrintInFix();
            Console.WriteLine($"Contains 200: {tree.Contains(200)}");
            Console.WriteLine($"Contains 30: {tree.Contains(30)}");
            Console.WriteLine($"Contains 4: {tree.Contains(4)}");            
            Console.WriteLine($"Minimum: {BinaryTree.FindMin(tree.Root).Value}");
            Console.WriteLine($"Maximum: {BinaryTree.FindMax(tree.Root).Value}");

            while (tree.Root != null)
            {
                int value = rnd.Next(1, 10);
                tree.DeleteNode(value);
                tree.PrintInFix();
            }

            Console.ReadLine();
        }
    }
}
