using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //LongestCommonPrefix.FindLongestCommonPrefixDemo();
            //PhoneNumberLetterCombination.PhoneNumberLetterCombinationDemo();
            //TwoSum();
            AddTwoNumbers();
            Console.ReadLine();
        }

        public static void TwoSum()
        {
            int[] list = new int[5] { 1, 2, 3, 4, 5 };
            List<int> result = new List<int>();
            Dictionary<int, int> hashTable = new Dictionary<int, int>();
            int sum = 9;
            for(int i = 0; i<list.Length; i++)
            {
                int complement = sum - list[i];
                if (hashTable.ContainsKey(list[i]))
                {
                    result.Add(hashTable[list[i]]);
                    result.Add(i);
                    break;
                }
                hashTable.Add(complement, i);
            }
            if (result.Count>0)
                Console.WriteLine($"{result[0]},{result[1]}");
            else
                Console.WriteLine("Not found");

            Console.ReadLine();

        }

        public static void AddTwoNumbers()
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

    }
}
