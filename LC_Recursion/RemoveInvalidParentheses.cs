using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures;

namespace LC_Recursion
{
    //https://leetcode.com/problems/letter-combinations-of-a-phone-number/solution/    
    public class RemoveInvalidParentheses
    {       
        public static void Demo()
        {
            string s = "(a)())()";
            Console.WriteLine($"Input String Number:{s}");
            Console.WriteLine("Results:");            
            var a = new LC_Recursion_Solution();
            var result = a.RemoveInvalidParentheses(s);
            foreach (var item in result)
            {
                Console.Write($"{item},");
            }            
        }        
    }

    public class LC_Recursion_Solution
    {
        public IList<string> RemoveInvalidParentheses(string s)
        { 
            HashSet<string> results = new HashSet<string>();
            Helper(s, results);
            return results.ToList<string>();
        }
        

        public void Helper(string s, HashSet<string> results)
        {
            int ToDelete = this.FindMinToDelete(s, results);
            this.FindValid(s, 0, 0, ToDelete, "", results);
        }

        public int FindMinToDelete(string s, HashSet<string> results)
        {
            string result = "";
            int cnt = 0, DelCount = 0;            
            foreach (char c in s)
            {
                if (c == '(')
                {
                    cnt++;
                }
                else if (c == ')')
                {
                    if (cnt == 0)
                    {
                        DelCount++;
                        continue;
                    }
                    else
                    {
                        cnt--;
                    }
                }
                result = result + c;

            }
            if (cnt > 0)
            {
                DelCount += cnt;
                result = RemoveTrailing(result, cnt);
            }

            results.Add(result);
            return DelCount;
        }

       

        public string RemoveTrailing(string s, int count)
        {
            var sb = new StringBuilder(s);
            for (int i = sb.Length - 1; count > 0; i--)
            {
                if (sb[i] == '(')
                {
                    sb.Remove(i, 1);
                    count--;
                }
            }
            return sb.ToString();
        }

        public void FindValid(string s, int i, int cnt, int DelCountAllowed, string result, HashSet<string> results)
        {
            //StringBuilder sb = new StringBuilder(result);

            if (DelCountAllowed < 0)
                return;

            if (i == s.Length)
            {
                if (cnt > 0)
                {
                    DelCountAllowed -= cnt;
                    result = RemoveTrailing(result, cnt);
                }
                if (DelCountAllowed == 0 && !results.Contains(result))
                    results.Add(result);

                return;
            }

            char c = s[i];

            if (c == '(')
            {
                //try excluding current char
                FindValid(s, i + 1, cnt, DelCountAllowed - 1, result, results);

                //try including current char                                
                result = result + c;
                FindValid(s, i + 1, cnt + 1, DelCountAllowed, result, results);
            }
            else if (c == ')')
            {
                if (cnt == 0)
                {
                    //the only option here is to exclude the current char
                    FindValid(s, i + 1, cnt, DelCountAllowed - 1, result, results);
                }
                else
                {
                    //try excluding current char
                    FindValid(s, i + 1, cnt, DelCountAllowed - 1, result, results);

                    //try including current char                
                    result = result + c;
                    FindValid(s, i + 1, cnt - 1, DelCountAllowed, result, results);
                }
            }
            else //other characters
            {
                result = result + c;
                FindValid(s, i + 1, cnt, DelCountAllowed, result, results);
            }

        }
    }
}
