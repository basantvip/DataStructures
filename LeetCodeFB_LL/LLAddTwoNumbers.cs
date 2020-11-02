using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeFB_LL
{
    //https://leetcode.com/problems/add-two-numbers/
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next= null)
        {
            this.val = val;
            this.next = next;
        }

        public override string ToString()
        {
            if (next != null)
                return ($"{val},");
            else
                return ($"{val}");
        }
    }
    public class LLAddTwoNumbers
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
            //2. https://leetcode.com/problems/add-two-numbers/description/

            var l1 = CreateList(new int[] { 2, 4, 3, 5, 1, 2});
            var l2 = CreateList(new int[] { 5, 6, 4, 9 });
            Console.Write("Input L1:");
            PrintList(l1);
            Console.Write("Input L1:");
            PrintList(l2);
            Console.Write("-----------------------\n");
            Console.Write("Output:  ");
            PrintList(AddTwoNumbers1(l1,l2));
            Console.Write("Output:  ");
            PrintList(AddTwoNumbers2(l1, l2));
        }

        public static ListNode AddTwoNumbers1(ListNode l1, ListNode l2)
        {
            ListNode curr = new ListNode(); //first element to be discarded
            ListNode head = curr;
            int carry = 0;
            while (l1 != null || l2 != null || carry > 0)
            {
                int sum = carry;
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                carry = sum / 10;
                curr.next = new ListNode(sum % 10);                
                curr = curr.next;

            }
            return head.next; //discard first element

        }


        //without discarding first element
        //preparing node for the next iteration, that's why we need to check if next iteration is required 
        public static ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return null;

            ListNode curr = new ListNode();
            ListNode head = curr;
            int carry = 0;
            while (l1 != null || l2 != null || carry > 0)
            {
                int sum = carry;
                if (l1 != null)
                {
                    sum = sum + l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum = sum + l2.val;
                    l2 = l2.next;
                }

                carry = sum / 10;
                curr.val = sum % 10;
                
                if (l1 != null || l2 != null || carry > 0) //atleast one more iteration remaining
                {
                    curr.next = new ListNode();
                    curr = curr.next;
                }

            }
            return head;

        }




    }

}
