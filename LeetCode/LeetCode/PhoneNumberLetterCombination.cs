using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class PhoneNumberLetterCombination
    {
        public static List<string> keypad = new List<string>() { " ", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
        public static void Demo()
        {
            Console.WriteLine("keyPad:");
            for (var i = 0; i < keypad.Count; i++)
            {
                Console.Write($"{i}:{keypad[i]}\t");
                if ((i + 1) % 3 == 0)
                    Console.WriteLine();
            }

            Console.Write("\nEnter a phone number:");
            var phone = Console.ReadLine();

            var result = GetPhoneNumberLetterCombination(phone);
            foreach (var item in result)
            {
                Console.Write($"{item},");
            }

            Console.ReadLine();

        }

        public static List<string> GetPhoneNumberLetterCombination(string phone)
        {
            List<string> result = new List<string>();

            foreach (var item in phone)
            {
                var currentNumber = int.Parse(item.ToString());

                List<string> temp = new List<string>();
                if (result.Count == 0)
                {
                    foreach (var currentChar in keypad[currentNumber])
                    {
                        result.Add($"{currentChar}");
                    }
                    continue;
                }
                foreach (var resultItem in result) 
                {
                    foreach (var currentChar in keypad[currentNumber])
                    {
                        temp.Add($"{resultItem}{currentChar}");
                    }
                }
                result = temp;
            }
            
            return result;


        }
    }
}
