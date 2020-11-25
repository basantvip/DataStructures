using System;

namespace LeetCodeBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("\n\t");
                Console.Write("1.BFS Traversal\n\t"); 
                Console.Write("2.BFS Invert Traversal\n\t");
                Console.Write("3.AverageOfLevels\n\t");
                Console.Write("4.BinaryTreePath\n\t");
                Console.Write("5.ValidateBinarySearchTree\n\t");
                Console.Write("6.FlattenBinaryTreeToLinkedList\n\t");
                Console.Write("0:Exit\nEnter Choice: ");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        BFS.Demo();
                        break;
                    case "2":
                        BFS_Invert.Demo();
                        break;
                    case "3":
                        AverageOfLevels.Demo();
                        break;
                    case "4":
                        BinaryTreePath.Demo();
                        break;
                    case "5":
                        ValidateBinarySearchTree.Demo();
                        break;
                    case "6":
                        FlattenBinaryTreeToLinkedList.Demo();
                        break;                        
                    case "0":
                        return;
                }
            }
        }
    }
}
