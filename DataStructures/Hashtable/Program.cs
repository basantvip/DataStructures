using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HashTable
{
    class Program
    {
        static Hashtable GetHashTable()
        {
            Hashtable hashtable = new Hashtable();

            hashtable.Add(300, "Carrot");
            hashtable.Add("Area", 1000);
            
            return hashtable;
        }
        static HashSet<int> GetHashSet()
        {
            HashSet<int> hashSet = new HashSet<int>() { 1, 2 };
            hashSet.Add(6);
            hashSet.Add(6);
            return hashSet;
        }

        static void Main()
        {
            Hashtable hashtable = GetHashTable();

            string value1 = (string)hashtable[300];
            Console.WriteLine(value1);

            int value2 = (int)hashtable["Area"];
            Console.WriteLine(value2);

            Console.WriteLine($"HashTable contains key 100:{hashtable.ContainsKey(100)}");
            Console.WriteLine($"HashTable contains key 300:{hashtable.ContainsKey(300)}");
            Console.WriteLine($"HashTable contains key Area:{hashtable.ContainsKey("Area")}");

            var hashSet = GetHashSet();
            Console.WriteLine($"HashSet contains key 1:{hashSet.Contains(1)}");
            Console.WriteLine($"HashSet contains key 2:{hashSet.Contains(2)}");
            Console.WriteLine($"HashSet contains key 3:{hashSet.Contains(3)}");
            Console.WriteLine($"HashSet contains key 6:{hashSet.Contains(6)}");
            Console.ReadLine();
        }
        
    }
}
