using System;
using System.Collections.Generic;

namespace DataStructures
{ 
    public class BST
    {
        public int Count { get; set; }

        public TreeNode Root { get; set; }

        public BST()
        {
            Count = 0;
        }

        public BST(string s)
        {
            this.AddNodes(s);
        }

        public void AddNodes()
        {
            Console.Write("\nEnter comma Separated node elements:");
            AddNodes(Console.ReadLine());
        }

        public void AddNodes(string treeString)
        {
            foreach (var item in treeString.Split(','))
            {
                this.Root = AddNode(this.Root, int.Parse(item));
                this.Count++;
            }
        }

        private TreeNode AddNode(TreeNode root, int value)
        {
            if (root == null)
                return new TreeNode(value);
            if (root.val >= value)
                root.left = AddNode(root.left, value);
            else
                root.right = AddNode(root.right, value);

            return root;
        }

        public void PrintInFix()
        {
            Console.Write($"InFix({this.Count} Items):");
            PrintInFix(this.Root);
            Console.WriteLine();
        }

        private static void PrintInFix(TreeNode root)
        {
            if (root == null)
                return;
            PrintInFix(root.left);
            Console.Write($"{root.ToString()} ");
            PrintInFix(root.right);
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

        public void PrintPostFix()
        {
            Console.Write($"PostFix({this.Count} Items):");
            PrintPostFix(this.Root);
            Console.WriteLine();
        }

        private static void PrintPostFix(TreeNode root)
        {
            if (root == null)
                return;
            PrintPostFix(root.left);
            PrintPostFix(root.right);
            Console.Write($"{root.ToString()}");
        }

        public bool Contains()
        {
            Console.WriteLine("Enter value to search");
            var value = int.Parse(Console.ReadLine());
            bool contains = FindNode(this.Root, value) != null ? true : false;
            Console.WriteLine($"Contains {value}: {contains}");
            return contains;
        }

        private static TreeNode FindNode(TreeNode root, int value)
        {
            if (root == null)
                return null;
            if (root.val == value)
                return root;
            if (root.val >= value)
                return FindNode(root.left, value);
            else
                return FindNode(root.right, value);
        }


        public void FindMin()
        {
            Console.WriteLine($"Minimum: {BST.FindMin(this.Root)}");
        }

        public void FindMax()
        {
            Console.WriteLine($"Maximum: {BST.FindMax(this.Root)}");
        }

        public static TreeNode FindMin(TreeNode root)
        {
            if (root == null)
                return null;
            if (root.left == null)
                return root;
            return FindMin(root.left);
        }

        public static TreeNode FindMax(TreeNode root)
        {
            if (root == null)
                return null;
            if (root.right == null)
                return root;
            return FindMax(root.right);
        }

        public void DeleteNode()
        {
            Console.WriteLine("Enter a value to delete");
            var value = int.Parse(Console.ReadLine());
            bool IsFound;
            this.Root = DeleteNode(this.Root, value, out IsFound);
            if (IsFound)
            {
                this.Count--;
                Console.WriteLine($"Deleted value {value}");
                PrintInFix();
            }
            else
                Console.WriteLine($"Not Found value {value}");
        }
        private static TreeNode DeleteNode(TreeNode root, int value, out bool found)
        {
            if (root == null)
            {
                found = false;
                return null;
            }

            if (root.val > value)
            {
                root.left = DeleteNode(root.left, value, out found);
                return root;
            }

            if (root.val < value)
            {
                root.right = DeleteNode(root.right, value, out found);
                return root;
            }
            else //found exact match
            {
                found = true;

                //leaf node
                if (root.left == null && root.right == null)
                    return null;

                //has only left node
                if (root.right == null)
                    return root.left;

                //has only right node
                if (root.left == null)
                    return root.right;

                //has both left and right node
                var temp = FindMin(root.right); //find max in left subtree or mim in right subtree
                root.val = temp.val;
                root.right = DeleteNode(root.right, temp.val, out found);
                return root;
            }
        }

        //done till here on 1/29, again on 2/20
        public TreeNode InOrderSuccessor()
        {
            Console.WriteLine("Enter value to find successor");
            var value = int.Parse(Console.ReadLine());

            TreeNode successorNode;
            TreeNode valueNode = null;
            if (this.Root == null)
                successorNode = null;
            else
                valueNode = FindNode(this.Root, value);

            if (valueNode == null)
                successorNode = null;

            else if (valueNode.right != null)
                successorNode = FindMin(valueNode.right);
            else
            {
                TreeNode current = this.Root;
                TreeNode next = null;
                while (current != valueNode)
                {
                    if (current.val > value)
                    {
                        next = current;
                        current = current.left;
                    }
                    else
                        current = current.right;
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
            var height = BST.Height(this.Root);
            Console.WriteLine($"Tree Height: {height}");
            return height;
        }

        public static int Height(TreeNode root)
        {
            int leftHeight, rightheight;
            if (root == null)
                return -1;

            leftHeight = Height(root.left);
            rightheight = Height(root.right);

            return (leftHeight > rightheight ? leftHeight + 1 : rightheight + 1);

        }
        

        
        public static void Demo()
        {
            BST tree = new BST();

            tree.AddNodes();

            while (true)
            {
                Console.Write("\n\t1.Print Infix, 2.Print Prefix, 3.Print Postfix\n\t4.Show Height\n\t5.Check Contains\n\t6.Find Min\n\t7.Find max\n\t8.InOrder Successor\n\t9.Delete a Node\n\t0:Exit\nEnter Choice: ");
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
                    case "0":
                        return;
                }
            }
        }
    }
}
