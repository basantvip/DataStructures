using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeFB_ArrStr
{
    class LengthOfLongestSubstringKDistinct
    {
        //https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/
        public static void Demo()
        {
            string s = "eceba";
            int k = 2;
            Console.WriteLine($"input:(string:{s},k:{k})");
            Console.WriteLine($"output:{LengthOfLongestSubstringKDistinct_internal(s,k)}");
        }

        public static int LengthOfLongestSubstringKDistinct_internal(string s,int k)
        {
            // because With extended ASCII codes, there are total 256 characters
            //here we need to make sure that using left and right index we keep k distintc chars
            //if we see > k then move left bondary
            //the right index moves if < k, the left index moves if > k and stops when = k
            //since at the end of the inner loop we are making sure we dont get > k
            //so after inner while loop we can compare current length with max length
            //in charcount array we are storing ascii chars. The size is 256, so that we can accomodate all chars
            int[] charCount = new int[256];
            int distinct = 0, left = 0, maxLength = 0;
            for (int right = 0; right < s.Length; right++)
            {

                //check if it's a new char
                if (charCount[s[right]]++ == 0)
                    distinct++;

                //check if we need to slide the left window
                //keep sliding the window until distinct count becomes k
                while (distinct > k)
                {
                    //if distinct is more than k, remove the item from left
                    charCount[s[left]]--;

                    //while removing the item if all occurance of a char is removed
                    //it means, we dont have that char in window between left and right
                    //hence decrement the distint count 
                    if (charCount[s[left]] == 0)
                        distinct--;

                    //slide left window towards right
                    left++;
                }
                //since the problem say atmost k characters, I can take max when distinct <= k
                maxLength = Math.Max(maxLength, right - left + 1);
            }            
            
            return maxLength;
        }
    }
}
