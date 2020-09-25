using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeFB_LL
{
    public class LLReorderList
    {
        public static ListNode CreateList(int[] list)
        {
            ListNode curr = new ListNode();
            ListNode head = curr;
            foreach (var item in list)
            {
                curr.next = new ListNode(item);
                curr = curr.next;
            }
            return head.next;
        }

        public static void PrintList(ListNode head)
        {
            while (head != null)
            {
                Console.Write(head.ToString());
                head = head.next;
            }
            Console.WriteLine();
        }


        public static void Demo()
        {
            //https://leetcode.com/explore/interview/card/facebook/6/linked-list/3021/

            var head = CreateList(new int[] {1,2,3,4,5});
            Console.Write("Input:");
            PrintList(head);
            Console.Write("Output:");
            PrintList(ReorderList_Internal(head));
            Console.Write("-----------------------\n");
            head = CreateList(new int[] { 1, 2, 3, 4, 5, 6 });
            Console.Write("Input:");
            PrintList(head);            
            Console.Write("Output:");
            PrintList(ReorderList_Internal(head));
            Console.Write("-----------------------\n");
            head = CreateList(new int[] { });
            Console.Write("Input:");
            PrintList(head);
            Console.Write("Output:");
            PrintList(ReorderList_Internal(head));
            Console.Write("-----------------------\n");
            head = CreateList(new int[] { 1 });
            Console.Write("Input:");
            PrintList(head);
            Console.Write("Output:");
            PrintList(ReorderList_Internal(head));
        }

        public static ListNode ReorderList_Internal(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            AttachOppositeNodes(head, head.next);
            return head;
        }

        public static ListNode AttachOppositeNodes(ListNode left, ListNode right)
        {
            
            if (right == null)
                return left;
            
            left = AttachOppositeNodes(left, right.next);
            
            if (left == null)
                return null;
            
            if (left == right)
            {
                left.next = null;
                return null;
            }

            if (left.next == right)
            {
                right.next = null;
                return null;
            }

            ListNode temp = left.next;
            left.next = right;
            right.next = temp;
            return temp;
        }



    }

}
