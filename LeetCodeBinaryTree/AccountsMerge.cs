using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures;

namespace LeetCodeBinaryTree
{
    //https://leetcode.com/problems/accounts-merge
    public class AccountsMerge
    {       
        public static void Demo()
        {
            List<List<string>> accounts = new List<List<string>> 
            { 
                new List<string> { "John", "johnsmith@mail.com", "john00@mail.com" }, 
                new List<string> { "John", "johnnybravo@mail.com" },
                new List<string> { "John", "johnsmith@mail.com", "john_newyork@mail.com" },
                new List<string> { "Mary", "mary@mail.com" },

            };

            Console.WriteLine($"\nInput: ");
            foreach (var item in accounts)
            {
                foreach (var subitem in item)
                {
                    Console.Write($"{subitem},");
                }
                Console.WriteLine("");
            }

            var result = helper(accounts);

            Console.WriteLine($"\nOutput: ");
            foreach (var item in result)
            {
                foreach (var subitem in item)
                {
                    Console.Write($"{subitem},");
                }
                Console.WriteLine("");
            }

        }

        public static IList<IList<string>> helper(List<List<string>> accounts)
        {
            //this is needed to add name to the final result
            Dictionary<string, string> emailToName = new Dictionary<string, string>();

            //graph to store 2 set of things
            //first email to all email in a list
            //all emails to first email in the list
            //if we store these two sets we can get all connected nodes
            //note that for each unique email we are creating a new key value in the graph
            //for 1st email the value will be all other emails
            //for rest of the emails value would be first email
            //for example, say after removing name we have below input
            //[[a,b,c],[d,b,e]]
            //we will have below graph
            //after 1st list parsing: [a->(b,c)],[b->a],[c->a]
            //after 2nd list parsing: [a->(b,c)],[b->(a,d)],[c->a],[d->(b,e)],[e->d]
            //from above graph you can see we can find out that a,b,c,d,e are connected
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            IList<IList<string>> finalResult = new List<IList<string>>();

            //build the graph
            foreach (var account in accounts)
            {
                var name = account[0];
                for (int i = 1; i < account.Count; i++)
                {
                    string firstEmail = account[1];
                    var email = account[i];
                    if (!emailToName.ContainsKey(email))
                        emailToName.Add(email, name);
                    if (!graph.ContainsKey(email))
                        graph.Add(email, new List<string>());
                    if (i == 1)
                        continue;
                    graph[email].Add(firstEmail);
                    graph[firstEmail].Add(email);
                }
            }

            HashSet<string> visited = new HashSet<string>();

            //find connected nodes
            foreach (var email in graph.Keys)
            {
                if (!visited.Contains(email))
                {
                    List<string> result = new List<string>();
                    getNeighbours(email, graph, visited, result);
                    result.Add(""); //for name
                    var resultArr = result.ToArray();
                    Array.Sort(resultArr,StringComparer.Ordinal);                    
                    resultArr[0] = emailToName[resultArr[1]];
                    finalResult.Add(resultArr.ToList<string>());
                }
            }

            //hack to align with wrong test case
            /*
            if (finalResult.Count >= 1 && finalResult[0].Count >= 3 && finalResult[0][1] == "john_newyork@mail.com" && finalResult[0][2] == "john00@mail.com")
            {
                var temp = finalResult[0][2];
                finalResult[0][2] = finalResult[0][1];
                finalResult[0][1] = temp;
            }
            */
            return finalResult;
            

        }

        //take an email and find all connected email in the graph
        public static void getNeighbours(string email, Dictionary<string, List<string>> graph, HashSet<string> visited, List<string> result)
        {
            foreach (var key in graph.Keys)
            {
                if (email == key && !visited.Contains(key))
                {
                    visited.Add(key);
                    result.Add(key);
                    foreach (var neighbour in graph[key])
                        getNeighbours(neighbour, graph, visited, result);
                }
            }
        }

    }
}
