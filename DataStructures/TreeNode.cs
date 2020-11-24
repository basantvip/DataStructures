using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int value)
        {
            this.val = value;
        }

        public override string ToString()
        {
            var left = this.left != null ? this.left.val.ToString() : "";
            var right = this.right != null ? this.right.val.ToString() : "";
            return $"({left}){val}({right}) -> ";
        }
    }   
}
