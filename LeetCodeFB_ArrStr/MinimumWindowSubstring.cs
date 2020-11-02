using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeFB_ArrStr
{
    class MinimumWindowSubstring
    {
        //https://leetcode.com/problems/minimum-window-substring/
        public static void Demo()
        {
            string S = "ADOBECODEBANC";
            string T = "ABC";
            //int start, end;
            Console.WriteLine($"String:{S}");
            Console.WriteLine($"Term to Search:{T}");
            Console.WriteLine($"Result:{MinWindow(S, T)}");
        }  

        public static string MinWindow(string s, string t)
        {
            if (s.Length == 0 || s.Length < t.Length)
                return "";
            
            //to cover all ASCII characters
            int[] TargetCount = new int[256];
            int[] SourceCount = new int[256];            

            foreach (char c in t)
            {
                TargetCount[c]++;
            }

            int charsFound = 0, charsToBeFound = t.Length;            
            int left = 0, right = 0;
            int MaxLeft = -1, MaxRight = -1;

            while (right < s.Length)
            {
                //As the right pointer moves Source count increases, as the left pointer moves, Source Count decreases
                //Basically the active window is from left to right
                //Anything outside this window should not appear in SourceCount array
                SourceCount[s[right]]++;

                //if right pointer element not found in target, move to the next right elememt
                if (TargetCount[s[right]] == 0)
                {                    
                    right++;
                    continue;
                }                

                //Matching found and not repeated
                //increment match count
                if (SourceCount[s[right]] <= TargetCount[s[right]])
                    charsFound++;

                //all matches found, time to slide left window to find min length
                if (charsFound == charsToBeFound)
                {
                    //sliding left window if char not found in target or its a repeated char
                    //keep moving right to find min len
                    while (TargetCount[s[left]] == 0 || SourceCount[s[left]] > TargetCount[s[left]])
                    {
                        //as the left pointer moves, Source Count decreases
                        SourceCount[s[left]]--;
                        left++;
                    }

                    //if we slide this left pointer any more right we will lose a matching windows
                    //this point is one of the candidate for min window
                    //if this length is smaller than pre min length
                    //or this is the first time length matching found
                    if (((right - left) < (MaxRight - MaxLeft)) || MaxLeft == -1)
                    {
                        MaxRight = right;
                        MaxLeft = left;
                    }
                    
                    //move the left pointer to break the current matching window and look for next matching window
                    SourceCount[s[left]]--;
                    left++;

                    //Since this step breaks the matching window, the last char dropped was in target
                    charsFound--;
                }
                
                right++;

            }

            if (MaxLeft == -1)
                return "";
            return s.Substring(MaxLeft, MaxRight - MaxLeft + 1);
        }       
    }
}
