using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class DecodeWays
    {
        public static void Demo()
        {
            Console.WriteLine("Enter input string of digits");
            var inputString = Console.ReadLine();
            Console.WriteLine($"Number of ways: {Ways(inputString)}");            
        }       

        public static int Ways(String message)
        {
            int msgLen = message.Length;
            if (message.Length == 0 || (message.Length == 1) && message == "0")
                return 0;
            int[] decodeCount = new int[msgLen + 1];

            decodeCount[0] = 1;
            decodeCount[1] = 1;

            for (int i = 2; i <= msgLen; i++) //will go one item beyond array
            {
                int Prev = int.Parse(message[i - 1].ToString());
                int PrevTwo = int.Parse(message[i - 2].ToString()) * 10 + Prev;

                if (Prev > 0)
                    decodeCount[i] = decodeCount[i - 1];

                if (PrevTwo <= 26)
                    decodeCount[i] = decodeCount[i] + decodeCount[i - 2];
            }

            return decodeCount[msgLen];
        }
    }
}
