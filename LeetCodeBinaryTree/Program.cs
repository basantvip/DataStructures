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
                Console.Write("7.MaximumPathSum\n\t");
                Console.Write("8.DiameterOfBinaryTree\n\t");
                Console.Write("9.AccountsMerge\n\t");
                Console.Write("10.BinaryTreeRightSideView\n\t");
                Console.Write("11.NumberOfIslands\n\t");
                Console.Write("12.LowestCommonAncestor\n\t");                
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
                    case "7":
                        MaximumPathSum.Demo();
                        break;
                    case "8":
                        DiameterOfBinaryTree.Demo();
                        break;
                    case "9":
                        AccountsMerge.Demo();
                        break;
                    case "10":
                        BinaryTreeRightSideView.Demo();
                        break;
                    case "11":
                        NumberOfIslands.Demo();
                        break;
                    case "12":
                        LowestCommonAncestor.Demo();
                        break;
                    case "0":
                        return;
                }
            }
        }
    }
}
