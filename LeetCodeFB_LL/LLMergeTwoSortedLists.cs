using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeFB_LL
{
    
    public class LLMergeTwoSortedLists
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
            var l1 = CreateList(new int[] { 2, 3, 6, 9, 10, 12});
            var l2 = CreateList(new int[] { 5, 6, 8, 30 });
            Console.Write("Input L1:");
            PrintList(l1);
            Console.Write("Input L1:");
            PrintList(l2);
            Console.Write("-----------------------\n");
            Console.Write("Output:  ");
            PrintList(Merge(l1,l2));
        }

        public static ListNode Merge(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode();
            ListNode current = head;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                }
                current = current.next;
            }

            if (l1 != null)
                current.next = l1;
            if (l2 != null)
                current.next = l2;
            return head.next;

        }

    }

}
