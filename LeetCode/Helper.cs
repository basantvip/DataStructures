﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class Helper{    
        public static string GetString(this LinkedList<int> linkedList)
        {
            return string.Join(",", linkedList);            
        }
    }
}
