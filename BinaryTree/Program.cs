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

            public override string ToString()
            {
                return $"{Value.ToString()} -> ";
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

            public void AddNodes()
            {
                Console.Write("\nEnter comma Separated node elements:");
                var binaryTreeString = Console.ReadLine();                
                var binaryTreeElements = binaryTreeString.Split(',');
                foreach (var item in binaryTreeElements)
                {
                    this.Root = AddNode(this.Root, int.Parse(item));
                    this.Count++;
                }                
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
                Console.Write($"InFix({this.Count} Items):");                
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

            public void PrintPreFix()
            {
                Console.Write($"PreFix({this.Count} Items):");
                PrintPreFix(this.Root);
                Console.WriteLine();
            }

            private static void PrintPreFix(Node root)
            {
                if (root == null)
                    return;
                Console.Write($"{root.Value.ToString()} -> ");
                PrintPreFix(root.Left);                
                PrintPreFix(root.Right);
            }

            public void PrintPostFix()
            {
                Console.Write($"PostFix({this.Count} Items):");
                PrintPostFix(this.Root);
                Console.WriteLine();
            }

            private static void PrintPostFix(Node root)
            {
                if (root == null)
                    return;                
                PrintPostFix(root.Left);
                PrintPostFix(root.Right);
                Console.Write($"{root.Value.ToString()} -> ");
            } 

            public bool Contains()
            {
                Console.WriteLine("Enter value to search");
                var value = int.Parse(Console.ReadLine());
                bool contains = FindNode(this.Root, value) != null ? true: false;                
                Console.WriteLine($"Contains {value}: {contains}");
                return contains;
            }

            private static Node FindNode(Node root, int value)
            {
                if (root == null)
                    return null;
                if (root.Value == value)
                    return root;
                if (root.Value >= value)
                    return FindNode(root.Left, value);
                else
                    return FindNode(root.Right, value);
            }
            
            
            public void FindMin()
            {
                Console.WriteLine($"Minimum: {BinaryTree.FindMin(this.Root).Value}");
            }

            public void FindMax()
            {
                Console.WriteLine($"Maximum: {BinaryTree.FindMax(this.Root).Value}");
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

            public void DeleteNode()
            {
                Console.WriteLine("Enter a value to delete");
                var value = int.Parse(Console.ReadLine());
                bool IsFound;
                this.Root = DeleteNode(this.Root, value, out IsFound);
                if (IsFound)
                {
                    Console.WriteLine($"Deleted value {value}");
                    PrintInFix();
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
                    var temp = FindMin(root.Right); //find max in left subtree or mim in right subtree
                    root.Value = temp.Value;
                    root.Right = DeleteNode(root.Right, temp.Value,out found);
                    return root;
                }
            }
            public Node InOrderSuccessor()
            {
                Console.WriteLine("Enter value to find successor");
                var value = int.Parse(Console.ReadLine());

                Node successorNode;
                Node valueNode = null;
                if (this.Root == null)
                    successorNode = null;
                else 
                    valueNode = FindNode(this.Root, value);

                if (valueNode == null)
                    successorNode = null;

                else if (valueNode.Right != null)
                    successorNode = FindMin(valueNode.Right);
                else
                {
                    Node current = this.Root;
                    Node next = null;
                    while (current != valueNode)
                    {
                        if (current.Value > value)
                        {
                            next = current;
                            current = current.Left;
                        }
                        else
                            current = current.Right;
                    }

                    successorNode = next;
                }
                var nodevalue = successorNode != null ? successorNode.ToString() : "None";
                Console.WriteLine($"Successor of {value} is {nodevalue}");
                return successorNode;
            }

            public int Height()
            {
                if (this.Root == null)
                    return 0;
                var height = BinaryTree.Height(this.Root);
                Console.WriteLine($"Tree Height: {height}");
                return height;
            }

            public static int Height(Node root)
            {
                int leftHeight, rightheight;
                if (root == null)
                    return - 1;

                leftHeight = Height(root.Left);
                rightheight = Height(root.Right);

                return (leftHeight > rightheight ? leftHeight + 1: rightheight + 1);

            }
            public void BFS()
            {
                var queue = new Queue<Node>();
                if (this.Root != null)
                    queue.Enqueue(Root);
                while (queue.Count > 0)
                {
                    var s = queue.Dequeue();
                    Console.Write($"{s.ToString()} -> ");
                    if (s.Left != null)
                        queue.Enqueue(s.Left);
                    if (s.Right != null)
                        queue.Enqueue(s.Right);
                }
                Console.WriteLine();

            }

            public void BFS_Invert()
            {
                var queue = new Queue<Node>();
                var stack = new Stack<Node>();
                if (this.Root != null)
                    queue.Enqueue(Root);
                while (queue.Count > 0)
                {
                    var s = queue.Dequeue();
                    stack.Push(s);
                    if (s.Right != null)
                        queue.Enqueue(s.Right);
                    if (s.Left != null)
                        queue.Enqueue(s.Left);                    
                }
                while(stack.Count > 0)
                {
                    Console.Write($"{stack.Pop().ToString()} -> ");
                }
                
                Console.WriteLine();

            }

        }
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            
            tree.AddNodes();

            while (true)
            {
                Console.Write("\n\t1.Print Infix, 2.Print Prefix, 3.Print Postfix\n\t4.Show Height\n\t5.Check Contains\n\t6.Find Min\n\t7.Find max\n\t8.InOrder Successor\n\t9.Delete a Node\n\t10.BFS, 11. BFS Invert\n\t0:Exit\nEnter Choice: ");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        tree.PrintInFix();
                        break;
                    case "2":
                        tree.PrintPreFix();
                        break;
                    case "3":
                        tree.PrintPostFix();
                        break;
                    case "4":
                        tree.Height();
                        break;
                    case "5":
                        tree.Contains();
                        break;
                    case "6":
                        tree.FindMin();
                        break;
                    case "7":
                        tree.FindMax();
                        break;
                    case "8":
                        tree.InOrderSuccessor();
                        break;
                    case "9":
                        tree.DeleteNode();
                        break;
                    case "10":
                        tree.BFS();
                        break;
                    case "11":
                        tree.BFS_Invert();
                        break;
                    case "0":
                        return;
                }
            }            
        }
    }
}
