using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB_ArrStr
{
    class ReadNCharactersGivenRead4
    {
        //https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/268/
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
                    if (totalCharsRead == n)
                        return totalCharsRead;
                    buf[totalCharsRead] = tempbuf[i];
                    totalCharsRead++;
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
