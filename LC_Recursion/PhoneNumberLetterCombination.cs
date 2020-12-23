using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace LC_Recursion
{
    //https://leetcode.com/problems/letter-combinations-of-a-phone-number/solution/    
    public class PhoneNumberLetterCombination
    {       
        public static void Demo()
        {
            string phoneNumber = "2345";
            Console.WriteLine($"Input Phone Number:{phoneNumber}");
            Console.WriteLine("Letter Combination:");
            var list = new PhoneNumberLetterCombination().Helper(phoneNumber);
            foreach (var item in list)
            {
                Console.Write($"{item},");
            }
        }
        public Dictionary<char, string> phonepadMapping = new Dictionary<char, string>()
        {
            {'2',"abc"},
            {'3',"def"},
            {'4',"ghi"},
            {'5',"jkl"},
            {'6',"mno"},
            {'7',"pqrs"},
            {'8',"tuv"},
            {'9',"wxyz"}
        };

        public IList<string> result = new List<string>();

        public IList<string> Helper(string digits)
        {
            if (digits != "")
                Helper("", digits);
            return result;

        }

        //This is the same problem as binary tree path
        //we need to keep appending the current character to the string formed so far
        //when we hit the leaf (in this case when we go past the leaf and hit the null)
        //--> add the path formed to the result and return
        //else for each character in the map of current digit
        //-->Add the character to string formed so far
        //-->call recursively with appended path and removing the current digit from the phone number string
        public void Helper(string combination, string digits)
        {
            if (digits == "")
            {
                result.Add(combination);
                return;
            }
            var currentDigit = digits[0];
            var restDigit = digits.Length > 1 ? digits.Substring(1) : "";
            foreach (char c in phonepadMapping[currentDigit])
                Helper(combination + c, restDigit);
        }

    }
}
