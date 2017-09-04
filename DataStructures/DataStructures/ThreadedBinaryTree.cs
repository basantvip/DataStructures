using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class ThreadedNode
    {
        public int Value;
        public ThreadedNode Left;
        public ThreadedNode Right;

        public bool IsLeftThreaded;
        public bool IsRightThreaded;

        public ThreadedNode(int value)
        {
            this.Value = value;
            //always add a new element as a leaf node
            IsLeftThreaded = true;
            IsRightThreaded = true;
        }

        public override string ToString()
        {
            var left = Left != null ? Left.Value.ToString() : "";            
            var right = Right != null ? Right.Value.ToString() : "";
            return $"({left},{IsLeftThreaded.ToString().Substring(0,1)}){Value.ToString()}({right},{IsRightThreaded.ToString().Substring(0, 1)}) -> ";
        }

    }

    public class ThreadedBinaryTree
    {
        ThreadedNode Root;
        public int Count;

        public ThreadedBinaryTree()
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

        private static ThreadedNode AddNode(ThreadedNode root, int value)
        {
            if (root == null)
                return new ThreadedNode(value);

            if (root.Value >= value) //is part of left subtree
            {
                if (root.IsLeftThreaded) //reached to the far left end
                {
                    var temp = new ThreadedNode(value);

                    temp.Left = root.Left;
                    temp.Right = root;                    

                    root.Left = temp;
                    root.IsLeftThreaded = false;
                }
                else //need to go further left
                    root.Left = AddNode(root.Left, value);
            }
            else //is part of right subtree
            {
                if (root.IsRightThreaded) //reached to the far right end
                {
                    var temp = new ThreadedNode(value);
                    temp.Left = root;
                    temp.Right = root.Right;

                    root.Right = temp;
                    root.IsRightThreaded = false;
                    
                }
                else //need to go further left
                    root.Right = AddNode(root.Right, value);
            }
            return root;
        }

        public void InOrderTraversal()
        {
            var temp = this.Root;
            if (temp == null)
                return;

            //go to the far left end
            while (temp.IsLeftThreaded == false)
                temp = temp.Left;
                        
            while (temp != null)
            {
                Console.WriteLine(temp);
                temp = FindSuccessor(temp);                
            }
        }

        public ThreadedNode FindSuccessor(ThreadedNode temp)
        {
            if (temp.IsRightThreaded)
                return temp.Right;
            else
            {
                temp = temp.Right;
                while (temp.IsLeftThreaded == false)
                    temp = temp.Left;
                return temp;
            }
        } 

        public static void Demo()
        {
            Console.WriteLine("Threaded Binary Tree and its Inorder traversal");
            ThreadedBinaryTree tbt = new ThreadedBinaryTree();
            tbt.AddNodes();
            tbt.InOrderTraversal();
            Console.ReadLine();

        }
    }
}
