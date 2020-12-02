using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace LeetCodeBinaryTree
{
    //https://leetcode.com/problems/binary-tree-vertical-order-traversal
    public class BinaryTreeVerticalOrderTraversal
    {       
        public static void Demo()
        {
            BinaryTree binarytree = new BinaryTree("3,9,8,4,0,1,7,null,null,null,2,5");
            Console.WriteLine("VerticalOrder:");
            var list = helper(binarytree.Root);            
            foreach (var item in list)
            {
                foreach (var subitem in item)
                {
                    Console.Write($"{subitem},");
                }
                Console.WriteLine("");
            }

            list = helper_SortedDictionary(binarytree.Root);
            foreach (var item in list)
            {
                foreach (var subitem in item)
                {
                    Console.Write($"{subitem},");
                }
                Console.WriteLine("");
            }
        }
        
        public static IList<IList<int>> helper(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null)
                return result;

            //dictionary to hold horizontal level and the list of items in that level
            //here horizontal level means root(0), left (-1), right(+1); 
            var dict = new Dictionary<int, IList<int>>();

            //Queue to traverse BFS
            //note here we also need to store the level information in the queue
            //so that we know where to add in ther dictionary
            var queue = new Queue<Tuple<int, TreeNode>>();

            queue.Enqueue(new Tuple<int, TreeNode> (0, root));

            int min = int.MaxValue;
            int max = int.MinValue;

            while (queue.Count > 0)
            {
                //dequeue
                var currentTuple = queue.Dequeue();

                //process current element
                var level = currentTuple.Item1;
                var node = currentTuple.Item2;

                min = Math.Min(min, level);
                max = Math.Max(max, level);

                //if level does not exist in dict, add an entry with empty list
                if (!dict.ContainsKey(level))
                    dict.Add(level, new List<int>());
                
                //Add current node to the dictionary in its appropriate level
                dict[level].Add(node.val);

                //queue left and right for next iteration
                if (node.left!=null)
                    queue.Enqueue(new Tuple<int, TreeNode>(level - 1, node.left));
                if (node.right != null)
                    queue.Enqueue(new Tuple<int, TreeNode>(level + 1, node.right));
            }           

            //this is to make sure that we return the result in ascending order of level
            while (min <= max)
                result.Add(dict[min++]);

            return result;            
        }

        //Note: We can also use a sorted dictionary instead of dictionary so that keys (levels) are always sorted
        //with that approach we dont need to use min and max variable and we dont need to copy at the end
        //but sorted dictionary does not exist outside C#.Net. So not recommended
        public static IList<IList<int>> helper_SortedDictionary(TreeNode root)
        {
            if (root == null)
                return new List<IList<int>>();

            SortedDictionary<int, IList<int>> result = new SortedDictionary<int, IList<int>>();

            Queue<Tuple<int, TreeNode>> Q1 = new Queue<Tuple<int, TreeNode>>();

            Q1.Enqueue(Tuple.Create(0, root));
            while (Q1.Count > 0)
            {
                var temp = Q1.Dequeue();
                if (!result.ContainsKey(temp.Item1))
                    result.Add(temp.Item1, new List<int>());
                result[temp.Item1].Add(temp.Item2.val);

                if (temp.Item2.left != null)
                    Q1.Enqueue(Tuple.Create(temp.Item1 - 1, temp.Item2.left));
                if (temp.Item2.right != null)
                    Q1.Enqueue(Tuple.Create(temp.Item1 + 1, temp.Item2.right));

            }
            return new List<IList<int>>(result.Values);
        }
    }
}
