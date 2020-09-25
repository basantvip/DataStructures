using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB_ArrStr
{
    class ReadNCharactersGivenRead4_II
    {
        //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/269/
        public static void Demo()
        {
            return;
        }

        char[] tempbuf = new char[4];
        static int read = 0, available = 0;

        public int Read(char[] buf, int n)
        {
            int totalCharsRead = 0;            
            while (totalCharsRead < n)
            {
                while (read < available && totalCharsRead < n)
                {
                    buf[totalCharsRead++] = tempbuf[read++];
                }
                if (totalCharsRead >= n)
                    break;
                int currCharsRead = Read4(tempbuf);
                read = 0;
                available = currCharsRead;
                for (int i = 0; i < currCharsRead; i++)
                {
                    if (totalCharsRead == n)
                        return totalCharsRead;
                    buf[totalCharsRead] = tempbuf[i];
                    totalCharsRead++;
                    read++;
                }
                if (currCharsRead < 4)
                    break;
            }
            return totalCharsRead;
        }

        private readonly Random _random = new Random();

        //mock
        public int Read4(char[] buf4)
        {
            return _random.Next(0, 4);
        }
    }
}
