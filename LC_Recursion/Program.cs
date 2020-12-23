using System;

namespace LC_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("\n\t");
                Console.Write("1.PhoneNumberLetterCombination\n\t");
                Console.Write("2.Permutation\n\t");
                Console.Write("3.Subsets\n\t");
                Console.Write("4.\n\t");
                Console.Write("5.\n\t");
                Console.Write("6.\n\t");
                Console.Write("7.\n\t");
                Console.Write("8.\n\t");
                Console.Write("9.\n\t");
                Console.Write("10.\n\t");
                Console.Write("11.\n\t");
                Console.Write("12.\n\t");
                Console.Write("13.\n\t");
                Console.Write("0:Exit\nEnter Choice: ");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        PhoneNumberLetterCombination.Demo();
                        break;
                    case "2":
                        PermutationClass.Demo();
                        break;
                    case "3":
                        SubsetsClass.Demo();
                        break;
                    case "4":
                        PhoneNumberLetterCombination.Demo();
                        break;
                    case "5":
                        PhoneNumberLetterCombination.Demo();
                        break;
                    case "6":
                        PhoneNumberLetterCombination.Demo();
                        break;
                    case "7":
                        PhoneNumberLetterCombination.Demo();
                        break;
                    case "8":
                        PhoneNumberLetterCombination.Demo();
                        break;
                    case "9":
                        PhoneNumberLetterCombination.Demo();
                        break;
                    case "10":
                        PhoneNumberLetterCombination.Demo();
                        break;
                    case "11":
                        PhoneNumberLetterCombination.Demo();
                        break;
                    case "12":
                        PhoneNumberLetterCombination.Demo();
                        break;
                    case "13":
                        PhoneNumberLetterCombination.Demo();
                        break;
                    case "0":
                        return;
                }
            }
        }
    }
}
