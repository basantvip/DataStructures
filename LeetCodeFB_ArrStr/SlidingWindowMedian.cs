using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;
using LeetCodeFB_LL;

namespace LeetCodeFB_ArrStr
{
    //https://leetcode.com/problems/sliding-window-median/
    class SlidingWindowMedian
    {
        public ListNode head;
        public int item_count;
        public SlidingWindowMedian()
        {
            item_count = 0;
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
            var input = new int[] { 7, 9, 3, 8, 0, 2, 4, 8, 3, 9 };
            int k = 1;

            SlidingWindowMedian a = new SlidingWindowMedian();
            //var result = a.MedianSlidingWindow(input, k);
            var result = a.SlidingWindowMedianUsingHeap(input, k);

            Console.Write("Input:");
            foreach (var item in input)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine($"\nk:{k}");

            Console.Write("Output:");
            foreach (var item in result)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine("");
            
        }

        public double[] SlidingWindowMedianUsingHeap(int[] input, int k)
        {

            if (input.Length < k)
                return null;

            double[] result = new double[input.Length - k + 1];

            Heap maxHeap = new Heap("MAX"); //1st half
            Heap minHeap = new Heap("MIN"); //2nd half           

            for (int i = 0; i < input.Length; i++)
            {

                //Add new item to the appropiate Heap
                if (i==0)
                    maxHeap.Insert(input[i]);
                else if (minHeap.Length > 0)
                {
                    if (input[i] >= minHeap.Peak())
                        minHeap.Insert(input[i]);
                    else
                        maxHeap.Insert(input[i]);
                }
                else 
                { 
                    if (input[i] <= maxHeap.Peak())
                        maxHeap.Insert(input[i]);
                    else
                        minHeap.Insert(input[i]);
                }

                //remove item outside the window from respective Heap
                if (i>=k)
                {                    
                    if (maxHeap.Length > 0 &&  input[i - k] <= maxHeap.Peak())
                        maxHeap.Delete(input[i - k]);
                    else
                        minHeap.Delete(input[i - k]);
                }
                
                //balance Heap
                while (Math.Abs(minHeap.Length - maxHeap.Length) > 1)
                {
                    if (minHeap.Length > maxHeap.Length)
                        TransferHeapRoot(minHeap, maxHeap);
                    else
                        TransferHeapRoot(maxHeap, minHeap);
                }

                //add current window median to the result
                if (i + 1 >= k)
                    result[i - k + 1] = (minHeap.Length > maxHeap.Length) ? (double) minHeap.Peak() : (maxHeap.Length > minHeap.Length ? (double)maxHeap.Peak() : ((double)(minHeap.Peak()) + maxHeap.Peak()) / 2);

            }

            return result;

        }

        public void TransferHeapRoot(Heap source, Heap destination)
        {
            if (source.Length == 0 || source == destination)
                return;
            var item = source.Peak();
            source.Delete(item);
            destination.Insert(item);
        }

        private void InsertSortedList(int val)
        {
            item_count++;
            ListNode n = new ListNode(val);
            ListNode curr = head, prev = new ListNode();

            //No element
            if (curr == null)
            {
                this.head = n;
                return;
            }

            //should be inserted at 1st position
            if (this.head.val > val)
            {
                n.next = head;
                head = n;
                return;
            }

            //somewhere  after first
            while (curr != null && curr.val <= val)
            {
                prev = curr;
                curr = curr.next;
            }

            prev.next = n;
            n.next = curr;
            return;
        }

        private void RemoveSortedList(int val)
        {
            ListNode curr = head, prev = new ListNode();

            //No element
            if (curr == null)
                return;

            //should be removed from 1st position
            if (this.head.val == val)
            {
                head = head.next;
                item_count--;
                return;
            }

            //somewhere  after first
            while (curr.next != null && curr.val != val)
            {
                prev = curr;
                curr = curr.next;
            }

            //no match
            if (curr.val != val)
                return;

            prev.next = curr.next;
            item_count--;
            return;
        }

        private double GetMedian()
        {
            ListNode curr = head;
            ListNode prev = new ListNode();
            int mid = item_count / 2;
            
            for (int i = 0; i < mid; i++)
            {
                prev = curr;
                curr = curr.next;
            }

            if (item_count % 2 == 0)
                return ((double)prev.val + curr.val) / 2;
            else
                return (double)curr.val;
        }

        private double[] MedianSlidingWindow(int[] nums, int k)
        {
            if (nums.Length == 0 || k > nums.Length)
                return null;
            //return new double[] { };

            double[] result = new double[nums.Length - k + 1];

            for (int i = 0; i < nums.Length; i++)
            {
                if (i >= k)
                    RemoveSortedList(nums[i - k]);

                InsertSortedList(nums[i]);
                

                if (i >= k - 1)
                {
                    result[i - k + 1] = GetMedian();
                    PrintList(head);
                }
                
            }
            return result;
        }
    }
}
