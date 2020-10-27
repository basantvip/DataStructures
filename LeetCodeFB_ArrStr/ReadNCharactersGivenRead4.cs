using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB_ArrStr
{
    class ReadNCharactersGivenRead4
    {
        //https://leetcode.com/problems/read-n-characters-given-read4/
        public static void Demo()
        {
            return;
        }        

        public int Read(char[] buf, int n)
        {
            int totalCharsRead = 0;
            char[] tempbuf = new char[4];
            while (totalCharsRead < n)
            {
                int currCharsRead = Read4(tempbuf);
                for (int i = 0; i < currCharsRead; i++)
                {
                    if (totalCharsRead == n) //Already read the numbers of chars needed to read
                        return totalCharsRead;
                    buf[totalCharsRead] = tempbuf[i]; //copy current char from temp buffer to output buffer
                    totalCharsRead++;
                }
                if (currCharsRead < 4) //no more chars available to read
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
