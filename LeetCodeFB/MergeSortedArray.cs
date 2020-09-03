using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB
{
    class MergeSortedArray
    {
        public static void Demo()
        {
            int[] nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            int[] nums2 = new int[] { 2, 5, 6 };
            int m = 3, n = 3;

            Console.Write($"\ninput nums1 ({m} elements): ");
            foreach (var item in nums1)
            {
                Console.Write($"{item},");
            }

            Console.Write($"\ninput nums2 ({n} elements): ");
            foreach (var item in nums2)
            {
                Console.Write($"{item},");
            }

            //Merge(nums1, m, nums2, n);
            MergeUsingAddionalArray(nums1, m, nums2, n);

            Console.Write($"\ninput nums1 ({m + n} elements): ");
            foreach (var item in nums1)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine();
        }

        //two pointer method in a loop O(n square)
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int shifted = 0;
            int i = 0, j = 0;
            while (i < m + shifted && j < n)
            {
                if (nums1[i] > nums2[j])
                {
                    shift_one_right(nums1, i, m - 1 + shifted);
                    nums1[i] = nums2[j++];
                    shifted++;
                }
                i++;
            }
            while (j < n)
            {
                nums1[i++] = nums2[j++];
            }
        }

        public static void shift_one_right(int[] num, int start, int end)
        {
            while (end >= start)
            {
                num[end + 1] = num[end];
                end--;
            }
        }

        public static void MergeUsingAddionalArray(int[] nums1, int m, int[] nums2, int n)
        {
            int[] nums1_copy = new int[m];
            Array.Copy(nums1, 0, nums1_copy, 0, m);

            int i = 0, j = 0, k = 0;
            while (i < m && j < n)
                nums1[k++] = nums1_copy[i] < nums2[j] ? nums1_copy[i++] : nums2[j++];

            if (i < m)
                Array.Copy(nums1_copy, i, nums1, k, m - i);
            else if (j < n)
                Array.Copy(nums2, j, nums1, k, n - j);
        }
    }
}
