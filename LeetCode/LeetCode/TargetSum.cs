using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class TargetSum
    {
        public static void Demo()
        {
            var s = "1, 2, 3, 4, 5";
            var target = 3;
            int i;
            var list = s.Split(',').Where(t => int.TryParse(t, out i)).Select(t => int.Parse(t)).ToList();
            Console.Write("List:");
            list.ForEach(t => Console.Write($"{t},"));

            Console.WriteLine($"\nTarget Sum:{target}");
            Console.WriteLine($"Result:{GetTargetSum(list, target)}");
        }

        public static int GetTargetSum(List<int> list, int Target)
        {
            Queue<int> queue = new Queue<int>();
            Queue<int> tmp_queue = new Queue<int>();

            queue.Enqueue(list[0]);
            queue.Enqueue(-list[0]);
            
            for (int i = 1; i < list.Count; i++)
            {
                while (queue.Count > 0)
                {
                    var item = queue.Dequeue();
                    tmp_queue.Enqueue(item + list[i]);
                    tmp_queue.Enqueue(item - list[i]);
                }
                while (tmp_queue.Count > 0)
                    queue.Enqueue(tmp_queue.Dequeue());                
            }

            return queue.Where(t => t == Target).ToList().Count;
        }

        
    }
}
