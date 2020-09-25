using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LeetCodeFB_ArrStr
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
                Console.Write("\n\t12.ValidPalindromeII\n\t13.LengthOfLongestSubstringKDistinct\n\t14.IntegerToEnglishWords");
                Console.Write("\n\t15.SlidingWindowMedian\n\t16.Next Permutation\n\t17.MinimumWindowSubstring");
                Console.Write("\n\t18.Subarray Sum Equals K\n\t19.OneEditDistance\n\t20.ValidateIPaddress\n\t21.ProductOfArrayExceptSelf");
                Console.Write("\n\t22.ReadNCharactersGivenRead4\n\t23.ReadNCharactersGivenRead4_II\n\t24.\n\t25.");                
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
                        SlidingWindowMedian.Demo();
                        break;
                    case "16":
                        NextPermutation.Demo();
                        break;
                    case "17":
                        MinimumWindowSubstring.Demo();
                        break;
                    case "18":
                        SubarraySumEqualsK.Demo();
                        break;
                    case "19":
                        OneEditDistance.Demo();
                        break;
                    case "20":
                        ValidateIPaddress.Demo();
                        break;
                    case "21":
                        ProductOfArrayExceptSelf.Demo();
                        break;
                    case "22":
                        ReadNCharactersGivenRead4.Demo();
                        break;
                    case "23":
                        ReadNCharactersGivenRead4_II.Demo();
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
