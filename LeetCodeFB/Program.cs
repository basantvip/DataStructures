using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LeetCodeFB
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("\n\t1.Longest Substring Without Repeating Characters\n\t2.String to Integer (atoi)\n\t3.Roman2Integer");
                Console.Write("\n\t4.3Sum\n\t5.RemoveDupesFromSortedArray\n\t6.Multiply Strings\n\t7.GroupAnagrams");
                Console.Write("\n\t8.MoveZeroes\n\t9.Add Binary\n\t10.MergeSortedArray\n\t11.ValidPalindrome");
                Console.Write("\n\t12.ValidPalindromeII\n\t13.LengthOfLongestSubstringKDistinct\n\t14.IntegerToEnglishWords\n\t15.AddTwoNumbers(LL)");
                Console.Write("\n\t16.Merge Two Sorted Lists (LL)\n\t17.SlidingWindowMedian\n\t18.Next Permutation\n\t19.MinimumWindowSubstring");
                Console.Write("\n\t20.Subarray Sum Equals K\n\t21.OneEditDistance\n\t22.\n\t23.");
                Console.Write("\n\t0:Exit\nEnter Choice: ");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        LongestSubstringWithoutRepeatingCharacters.Demo();
                        break;
                    case "2":
                        StringToInteger_atoi.Demo();
                        break;
                    case "3":
                        Roman2Integer.Demo();
                        break;
                    case "4":
                        ThreeSum.Demo();
                        break;
                    case "5":
                        RemoveDupesFromSortedArray.Demo();
                        break;
                    case "6":
                        MultiplyStrings.Demo();
                        break;
                    case "7":
                        GroupAnagrams.Demo();
                        break;
                    case "8":
                        MoveZeroes.Demo();
                        break;
                    case "9":
                        AddBinary.Demo();
                        break;
                    case "10":
                        MergeSortedArray.Demo();
                        break;
                    case "11":
                        ValidPalindrome.Demo();
                        break;
                    case "12":
                        ValidPalindromeOneCharDelete.Demo();
                        break;
                    case "13":
                        LengthOfLongestSubstringKDistinct.Demo();
                        break;
                    case "14":
                        IntegerToEnglishWords.Demo();
                        break;
                    case "15":
                        LLAddTwoNumbers.Demo();
                        break;
                    case "16":
                        LLMergeTwoSortedLists.Demo();
                        break;
                    case "17":
                        SlidingWindowMedian.Demo();
                        break;
                    case "18":
                        NextPermutation.Demo();
                        break;
                    case "19":
                        MinimumWindowSubstring.Demo();
                        break;
                    case "20":
                        SubarraySumEqualsK.Demo();
                        break;
                    case "21":
                        OneEditDistance.Demo();
                        break; 
                    case "0":
                        return;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }


        }
    }
}
