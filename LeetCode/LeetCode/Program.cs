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
            while (true)
            {
                Console.Write("\n\t1.LongestCommonPrefix\n\t2.PhoneNumberLetterCombination\n\t3.AddTwoNumbers");
                Console.Write("\n\t4.TwoSum\n\t5.TwoSumIV_Input_BST\n\t6.SearchAutoComplete\n\t7.SubTree");
                Console.Write("\n\t8.Decode Ways\n\t9.AveregeOfLevelsBinaryTree\n\t10.Brick Wall");
                Console.Write("\n\t11.Binary Tree Diameter\n\t12.TargetSum\n\t13.Hamming Distance");
                Console.Write("\n\t14.TotalHammingDistance\n\t15.BuyAndSellStock\n\t16.SortedArrayToBalancedBST");
                Console.Write("\n\t17.MinimumLengthSubArraySum\n\t18.MaxSumSubArray_Kadane\n\t19.MaximumSumSubrectangle");
                Console.Write("\n\t20.LongestContinuousIncreasingSubsequence\n\t21.Burst Ballons\n\t22.MinimumWindowSubstring");
                Console.Write("\n\t0:Exit\nEnter Choice: ");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        LongestCommonPrefix.Demo();
                        break;
                    case "2":
                        PhoneNumberLetterCombination.Demo();
                        break;
                    case "3":
                        AddTwoNumbers.Demo();
                        break;
                    case "4":
                        TwoSum.Demo();
                        break;
                    case "5":
                        TwoSumIV_Input_BST.Demo();
                        break;
                    case "6":
                        SearchAutoComplete.Demo();
                        break;
                    case "7":
                        SubTree.Demo();
                        break;
                    case "8":
                        DecodeWays.Demo();
                        break;
                    case "9":
                        AveregeOfLevelsBinaryTree.Demo();
                        break;
                    case "10":
                        BrickWall.Demo();
                        break;
                    case "11":
                        BinaryTreeDiameter.Demo();
                        break;
                    case "12":
                        TargetSum.Demo();
                        break;
                    case "13":
                        HammingDistance.Demo();
                        break;
                    case "14":
                        TotalHammingDistance.Demo();
                        break;
                    case "15":
                        BuyAndSellStock.Demo();
                        break;
                    case "16":
                        SortedArrayToBalancedBST.Demo();
                        break;
                    case "17":
                        MinimumLengthSubArraySum.Demo();
                        break;
                    case "18":
                        MaxSumSubArray_Kadane.Demo();
                        break;
                    case "19":
                        MaximumSumSubrectangle.Demo();
                        break;
                    case "20":
                        LongestContinuousIncreasingSubsequence.Demo();
                        break;
                    case "21":
                        BurstBallons.Demo();
                        break;
                    case "22":		
                        MinimumWindowSubstring.Demo();
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
