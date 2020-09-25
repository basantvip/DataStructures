using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeFB_LL
{
    
    // Definition for a Node.
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val) 
        {
            val = _val;
            next = null;
            random = null;
        }
    } 

    public class LLCopyRandomList
    {
        public static void Demo()
        {

        }

        Dictionary<Node, Node> IOMap = new Dictionary<Node, Node>();
        public Node CopyRandomList_Recursive(Node head)
        {
            if (head == null)
                return null;
            if (IOMap.ContainsKey(head))
                return IOMap[head];
            Node result = new Node(head.val);
            IOMap.Add(head, result);
            result.next = CopyRandomList_Recursive(head.next);
            result.random = CopyRandomList_Recursive(head.random);
            return result;
        }

        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return null;            
            Node curr = head;
            Node result_head = new Node(0);
            Node result_prev = new Node(0);
            Node result_curr;
            bool first = true;
            while (curr != null)
            {
                result_curr = new Node(curr.val);
                if (first) //when first node, just need to set head
                {
                    result_head = result_curr;
                    first = false;
                }
                else
                    result_prev.next = result_curr; //else need to link current node to prev node

                result_prev = result_curr;
                IOMap.Add(curr, result_curr);
                curr = curr.next;
            }

            foreach (var item in IOMap)
            {
                if (item.Key.random != null) //nothing needs to be done if randon pointer is null, we will not find value anyway and it will throw error
                    item.Value.random = IOMap[item.Key.random];
            }

            return result_head;

        }

        public Node CopyRandomListUsingHash(Node head)
        {
            Hashtable IOMapHash = new Hashtable();

            if (head == null)
                return null;
            Node curr = head;
            Node result_head = new Node(0);
            Node result_prev = new Node(0);
            Node result_curr;
            bool first = true;
            while (curr != null)
            {
                result_curr = new Node(curr.val);
                if (first) //when first node, just need to set head
                {
                    result_head = result_curr;
                    first = false;
                }
                else
                    result_prev.next = result_curr; //else need to link current node to prev node

                result_prev = result_curr;
                IOMap.Add(curr, result_curr);
                IOMapHash.Add(curr, result_curr);
                curr = curr.next;
            }

            foreach (DictionaryEntry item in IOMapHash)
            {
                Node source = (Node)item.Key;
                Node target = (Node)item.Value;

                if (source.random  != null) //nothing needs to be done if randon pointer is null, we will not find value anyway and it will throw error
                    target.random = (Node)IOMapHash[source.random];
            }

            return result_head;

        }
    }






}
