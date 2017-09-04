using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using DataStructures;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //LongestCommonPrefix.FindLongestCommonPrefixDemo();
            //PhoneNumberLetterCombination.PhoneNumberLetterCombinationDemo();

            //Program p = new Program();
            //p.TwoSum();
            //p.AddTwoNumbers();
            //p.TwoSumIV_Input_BST_Demo();

            //SearchAutoComplete s = new SearchAutoComplete();
            //s.Demo();
            Subtree s = new Subtree();
            s.Demo();
            Console.ReadLine();
        }

        public void TwoSum()
        {
            int[] list = new int[5] { 1, 2, 3, 4, 5 };
            List<int> result = new List<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int sum = 9;
            for(int i = 0; i<list.Length; i++)
            {
                int complement = sum - list[i];
                if (dict.ContainsKey(list[i]))
                {
                    result.Add(dict[list[i]]);
                    result.Add(i);
                    break;
                }
                dict.Add(complement, i);
            }
            if (result.Count>0)
                Console.WriteLine($"{result[0]},{result[1]}");
            else
                Console.WriteLine("Not found");

            Console.ReadLine();

        }

        public void AddTwoNumbers()
        {
            
            LinkedList<int> list1 = new LinkedList<int>(new List<int>() { 2, 4, 3, 5});
            LinkedList<int> list2 = new LinkedList<int>(new List<int>() { 5, 6, 4, 9});
            LinkedList<int> result = new LinkedList<int>();

            var l1 = list1.First;
            var l2 = list2.First;            
            int carry = 0;
            while (l1 != null || l2 != null || carry > 0)
            {
                int sum = (l1 != null ? l1.Value : 0) + (l2 != null ? l2.Value : 0) + carry;
                int currentDigit = sum % 10;                
                result.AddLast(currentDigit);
                if (l1 != null)
                    l1 = l1.Next;
                if (l2 != null)
                    l2 = l2.Next;
                carry = sum / 10;
            }            

            foreach (var item in result)
            {
                Console.Write($"{item},");
            }

        }

        public void TwoSumIV_Input_BST_Demo()
        {
            BinaryTree BST = new BinaryTree();
            BST.AddNodes();
            Console.Write("Enter a Sum:");
            int sum = int.Parse(Console.ReadLine());
            Console.WriteLine(FindTarget(BST.Root, sum));

        }

        public HashSet<int> hashSet = new HashSet<int>();
        public bool FindTarget(Node root, int k)
        {
            if (root == null)
                return false;
            if (hashSet.Contains(root.Value))
                return true;
            else
                hashSet.Add(k - root.Value);
            return (FindTarget(root.Left, k) || FindTarget(root.Right, k));
        }

    }
}
