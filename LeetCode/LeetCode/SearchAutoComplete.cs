using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class SearchAutoComplete
    {
        public static void Demo()
        {
            Dictionary<string, int> searchHistory = new Dictionary<string, int>();
            searchHistory.Add("i love you", 5);
            searchHistory.Add("island", 3);
            searchHistory.Add("ironman", 2);
            searchHistory.Add("i love leetcode", 2);
            while (true)
            {
                Console.Write("\nSearch History:");                                 
                foreach (var item in searchHistory)
                {
                    Console.Write($"{item.Key}[{item.Value}],");
                }
                Console.Write("\n");
                Console.Write("1.Search,2.Exit:");
                if (Console.ReadKey().KeyChar == '2')
                    break;
                Console.Write("\nEnter search string (only small letters and space. # to end):");
                var searchString = "";
                while (true)
                {
                    char c = Console.ReadKey().KeyChar;
                    if (c == '#')
                        break;

                    if ((c < 'a' || c > 'z') && c != ' ')
                        continue;

                    searchString = searchString + c;
                    var searchResult = GetAutoCompleteResults(searchString, searchHistory);
                    Console.Write("\nSearch Result:");                    
                    foreach (var item in searchResult)
                    {
                        Console.Write($"{item},");
                    }
                    Console.Write("\n");
                    Console.Write($"{searchString}");
                }
                Console.WriteLine($"\nYou entered:{searchString}");
                if (searchHistory.ContainsKey(searchString))
                    searchHistory[searchString]++;
                else
                    searchHistory.Add(searchString, 1);
                var a = "";
            }
        }

        public static List<string> GetAutoCompleteResults(string searchString, IDictionary<string, int> searchHistory)
        {
            return searchHistory.Where(t => t.Key.StartsWith(searchString)).Select(t => t).OrderByDescending(t => t.Value).ThenBy(t => t.Key).Take(3).Select(t => t.Key).ToList() ;            
        }
            //["i love you", "island","ironman", "i love leetcode"], [5,3,2,2]) 
        
    }
}
