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
                Console.Write("\n\t1.LongestCommonPrefix\n\t2.PhoneNumberLetterCombination\n\t3.AddTwoNumbers\n\t4.TwoSum\n\t5.TwoSumIV_Input_BST\n\t6.SearchAutoComplete\n\t7.SubTree\n\t0:Exit\nEnter Choice: ");
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
                    case "0":
                        return;
                }
            }


            
            
            Console.ReadLine();
        }
    }
}
