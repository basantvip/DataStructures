using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace LeetCode
{
    public class AddTwoNumbers
    {
        public static void Demo()
        {
            //2. https://leetcode.com/problems/add-two-numbers/description/

            LinkedList<int> list1 = new LinkedList<int>(new List<int>() { 2, 4, 3, 5, 1, 2});
            LinkedList<int> list2 = new LinkedList<int>(new List<int>() { 5, 6, 4, 9 });
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

            Console.WriteLine($"List1 :{string.Join(",", list1)}");
            Console.WriteLine($"List2 :{string.Join(",", list2)}");
            Console.WriteLine($"{new string('-', 40)}");
            Console.WriteLine($"Result:{string.Join(",", result)}");
            Console.WriteLine();
            Demo_NotReverse();

        }

        public static void Demo_NotReverse()
        {
            //2. https://leetcode.com/problems/add-two-numbers/description/

            LinkedList<int> list1 = new LinkedList<int>(new List<int>() { 2, 4, 3, 5, 1, 2 });
            LinkedList<int> list2 = new LinkedList<int>(new List<int>() { 9, 9, 5, 6, 4, 9 });
            LinkedList<int> result = new LinkedList<int>();


            if (list1.Count > list2.Count)
                PadLeftZeros(list2, list1.Count - list2.Count);
            else if (list2.Count < list1.Count)
                PadLeftZeros(list1, list2.Count - list1.Count);
            int carry = 0;
            AddTwoList_NotReverse(list1.First, list2.First, result, out carry);

            if (carry > 0)
            {
                result.AddFirst(carry);
            }

            Console.WriteLine($"List1 :{string.Join(",", list1)}");
            Console.WriteLine($"List2 :{string.Join(",", list2)}");
            Console.WriteLine($"{new string('-', 40)}");
            Console.WriteLine($"Result:{string.Join(",", result)}");

        }

        public static void AddTwoList_NotReverse(LinkedListNode<int> list1, LinkedListNode<int> list2, LinkedList<int> ResultList, out int carry)
        {
            //variation of above problem where digits are not stored in reverse order, we need to add from right to left
            carry = 0;
            if (list1 == null)
            {                
                return;
            }

            AddTwoList_NotReverse(list1.Next, list2.Next, ResultList, out carry);

            var sum = list1.Value + list2.Value + carry;            
            ResultList.AddFirst(sum % 10);
            carry = sum / 10;
        }

        public static void PadLeftZeros(LinkedList<int> list, int n)
        {
            while (n-- > 0)
            {
                LinkedListNode<int> resultNode = new LinkedListNode<int>(0);
                list.AddFirst(resultNode);
            }
        }

    }

}
