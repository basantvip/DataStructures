using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class AddTwoNumbers
    {
        public static void Demo()
        {

            LinkedList<int> list1 = new LinkedList<int>(new List<int>() { 2, 4, 3, 5 });
            LinkedList<int> list2 = new LinkedList<int>(new List<int>() { 5, 6, 4, 9 });
            LinkedList<int> result = new LinkedList<int>();

            var l1 = list1.First;
            var l2 = list2.First;
            int carry = 0;
            while (l1 != null || l2 != null || carry > 0)
            {
                int sum = (l1 != null ? l1.Value : 0) + (l2 != null ? l2.Value : 0) + carry;
                int currentDigit = sum % 10;
                result.AddLast(currentDigit);
                if (l1 != null)
                    l1 = l1.Next;
                if (l2 != null)
                    l2 = l2.Next;
                carry = sum / 10;
            }

            foreach (var item in result)
            {
                Console.Write($"{item},");
            }

        }
    }

}
