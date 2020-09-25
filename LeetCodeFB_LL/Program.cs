using System;

namespace LeetCodeFB_LL
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("\n\t1.Add Tow Numbers\n\t2.Copy Randon Lists\n\t3.Merge Two Sorted Lists\n\t4.Reorder List");
                Console.Write("\n\t0:Exit\nEnter Choice: ");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        LLAddTwoNumbers.Demo();
                        break;
                    case "2":
                        LLCopyRandomList.Demo();
                        break;
                    case "3":
                        LLMergeTwoSortedLists.Demo();
                        break;
                    case "4":
                        LLReorderList.Demo();
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
