using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class PlusOne
    {
        public static void Demo()
        {
            //66. https://leetcode.com/problems/plus-one/description/
            int[] input = new int[] { 3,2,4,3,2,4,3,2,4 };            
            
            Console.Write("Input:");
            input.ToList().ForEach(t => Console.Write($"{t}"));
            Console.WriteLine();
            var result = PlusOneDemo(input);
            Console.Write("Output:");
            result.ToList().ForEach(t => Console.Write($"{t}"));
            Console.WriteLine();
            result = PlusOneDemoV2(input);
            Console.Write("Output:");
            result.ToList().ForEach(t => Console.Write($"{t}"));
            Console.ReadLine();
        }

        public static int[] PlusOneDemo(int[] digits)
        {
            int[] result = new int[digits.Length + 1];
            int carry = 1;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                var sum = digits[i] + carry;
                result[i + 1] = sum % 10;
                carry = sum / 10;
            }
            result[0] = carry;
            int j = 0;
            while (j < result.Length)
            {
                if (result[j] != 0)
                    break;
                j++;
            }
            if (j > 0)
                return result.Reverse().Take(result.Length - j).Reverse().ToArray<int>();
            else
                return result;
        }

        public static int[] PlusOneDemoV2(int[] digits)
        {            
            List<int> result = new List<int>(digits);
            for (int i = result.Count-1; i >= 0; i--)
            {
                if (result[i] != 9)
                {
                    result[i] += 1;
                    return result.ToArray<int>();
                }
                result[i] = 0;                
            }
            result.Insert(0,1);

            return result.ToArray<int>();
           
        }
    }
}
