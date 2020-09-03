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
                Console.Write("\n\t8.MoveZeroes\n\t9.Add Binary\n\t10.MergeSortedArray\n\t11.");
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
                    case "0":
                        return;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }


        }
    }
}
