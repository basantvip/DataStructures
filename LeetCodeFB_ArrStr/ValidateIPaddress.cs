using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeFB_ArrStr
{
    using System.Runtime.Serialization.Formatters;

    class ValidateIPaddress
    {
        //https://leetcode.com/problems/validate-ip-address/
        public static void Demo()
        {
            var IP = "172.16.254.1";
            Console.WriteLine($"{IP} is {Demo_internal(IP)}");           
        }

        public static string Demo_internal(string IP)
        {
            return ValidIPv4(IP) ? "IPv4" : (ValidIPv6(IP) ? "IPv6" : "Neither");
        }

        public static bool ValidIPv4(string IP)
        {
            var s = IP.Split('.');

            if (s.Length != 4)
                return false;

            foreach (string item in s)
            {
                int x;
                if (!int.TryParse(item, out x))
                    return false;
                if (x < 0 || x > 255 || item.Length != x.ToString().Length)
                    return false;
            }

            return true;
        }
        public static bool ValidIPv6(string IP)
        {
            var s = IP.Split(':');

            if (s.Length != 8)
                return false;

            foreach (string item in s)
            {
                if (item.Length < 1 || item.Length > 4)
                    return false;
                foreach (char c in item.ToCharArray())
                {
                    if (!isHex(c))
                        return false;
                }
            }

            return true;
        }

        public static bool isHex(char c)
        {
            return ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'));
        }
    }
}
