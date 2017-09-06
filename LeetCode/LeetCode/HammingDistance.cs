using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class HammingDistance
    {
        public static void Demo()
        {
            Console.Write("Enter 1st Integer:");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter 2nd Integer:");
            int b = int.Parse(Console.ReadLine());
            Console.Write($"{a}:");
            PrintBits(a);
            Console.Write($"\n{b}:");
            PrintBits(b);
            Console.Write($"\nHamming Distance (Number of places where bits are different):");
            Console.Write($"{GetHammingDistance(a,b)}");
            Console.Write($"\nReverse Hamming Distance(Number of places where bits are same):");
            Console.Write($"{GetReverseHammingDistance(a, b)}");
        }

        public static int GetHammingDistance(int a, int b)
        {
            var s = a ^ b;
            PrintBits(s);
            Console.Write(":");
            return (CountBits(s, true));
        }

        public static int GetReverseHammingDistance(int a, int b)
        {
            var s = FlipBits(a ^ b);
            PrintBits(s);
            Console.Write(":");
            return (CountBits(s, true));
        }

        public static int FlipBits(int n)
        {
            var s = n;
            int bitLength = 0;
            while (s > 0)
            {
                bitLength++;
                s = s / 2;
            }

            return (n ^ (1 << bitLength) - 1);
        }
            
        public static int CountBits(int n, bool bitToCount)
        {
            var result = 0;
            while (n > 0)
            {
                if (n % 2 == (bitToCount ? 1 : 0))
                    result++;
                n = n / 2;
            }
            return result;
        }

        public static void PrintBits(int n)
        {
            if (n <= 0)
                return;            
            PrintBits(n / 2);
            Console.Write(n % 2);
        }
    }
}
