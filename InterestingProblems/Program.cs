using System;
using System.Linq;

namespace InterestingProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            //var input = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
            //int k = 3;

            //SlidingWindowMedian a = new SlidingWindowMedian();            
            //var result = a.GetMedian(input, k);

            //Console.Write("Input:");
            //foreach (var item in input)
            //{
            //    Console.Write($"{item},");
            //}
            //Console.WriteLine($"\nk:{k}");

            //Console.Write("Output:");
            //foreach (var item in result)
            //{
            //    Console.Write($"{item},");
            //}
            //Console.WriteLine("");
            //Console.ReadLine();

            EncodeDecode.Test();
        }
        
    }

    public class Heap
    {
        private int[] arr;
        private string heapType;
        private int length;
        public Heap(string heapType = "MAX")
        {
            //default;
            this.heapType = heapType.ToUpper();
            this.length = 0;
        }

        public Heap(string items, string heapType = "MAX")
        {
            this.heapType = heapType.ToUpper();
            this.arr = items.Split(",").Where(t => int.TryParse(t, out int i)).Select(int.Parse).ToArray();
            Heapify();
            this.length = arr.Length;
        }

        public void Heapify()
        {
            if (heapType == "MIN")
                Heapify_Min(0);
            else if (heapType == "MAX")
                Heapify_Max(0);
        }

        public void Insert(int val)
        {
            if (this.Length == 0)
            {
                this.arr = new int[1] { val };
                this.length++;
            }
            else //insert at the end of the heap and then Heapify
            {
                int[] newArr = new int[this.Length + 1];
                Array.Copy(arr, newArr, this.Length);
                newArr[this.Length] = val;
                arr = newArr;
                this.length++;

                if (heapType == "MIN")
                    Heapify_Min(0);
                else if (heapType == "MAX")
                    Heapify_Max(0);
            }

        }

        public bool Delete(int val)
        {

            int[] newArr;
            for (int i = 0; i < this.Length; i++)
            {

                if (arr[i] == val)
                {
                    if (this.Length == 1)
                    {
                        arr = null;
                        this.length--;
                    }
                    //if item found then swap with the last element
                    //and then remove the last element from the array
                    //and then Heapify and return
                    else
                    {
                        SwapElements(i, this.Length - 1);
                        newArr = new int[this.Length - 1];
                        Array.Copy(arr, newArr, this.Length - 1);
                        arr = newArr;
                        this.length--;

                        if (heapType == "MIN")
                            Heapify_Min(0);
                        else if (heapType == "MAX")
                            Heapify_Max(0);
                    }

                    return true;
                }
            }
            //if item not found, return false
            return false;
        }

        public void Print()
        {
            Console.Write($"Heap {heapType}: ");
            foreach (var item in arr)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine();
        }

        public int Length
        {
            get { return this.length; }
        }

        public int Peak()
        {
            if (this.Length > 0)
                return arr[0];
            else throw new Exception("no elements to peak");
        }

        private void Heapify_Max(int currIndex)
        {
            if (this.Length <= 1)
                return;
            if (2 * currIndex + 1 >= this.Length)
                return;

            Heapify_Max(2 * currIndex + 1);
            Heapify_Max(2 * currIndex + 2);

            int maxIndex = (arr[2 * currIndex + 1] > arr[currIndex]) ? 2 * currIndex + 1 : currIndex;
            if (2 * currIndex + 2 < this.Length)
                maxIndex = (arr[2 * currIndex + 2] > arr[maxIndex]) ? 2 * currIndex + 2 : maxIndex;

            if (maxIndex != currIndex)
            {
                SwapElements(maxIndex, currIndex);
                //we must Heapify again starting this node
                //since we are always comparing a node to its child node, 
                //when the swap occurs we must do that again since the node has changed
                Heapify_Max(maxIndex);
            }

        }

        private void Heapify_Min(int currIndex)
        {
            if (this.Length <= 1)
                return;

            if (2 * currIndex + 1 >= this.Length)
                return;

            Heapify_Min(2 * currIndex + 1);
            Heapify_Min(2 * currIndex + 2);

            int minIndex = (arr[2 * currIndex + 1] < arr[currIndex]) ? 2 * currIndex + 1 : currIndex;
            if (2 * currIndex + 2 < this.Length)
                minIndex = (arr[2 * currIndex + 2] < arr[minIndex]) ? 2 * currIndex + 2 : minIndex;

            if (minIndex != currIndex)
            {
                SwapElements(minIndex, currIndex);
                //we must Heapify again starting this node
                //since we are always comparing a node to its child node, 
                //when the swap occurs we must do that again since the node has changed
                Heapify_Min(minIndex);
            }
        }

        private void SwapElements(int i, int j)
        {
            if (i >= this.Length || j >= this.Length || i == j)
                return;

            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }

    public class SlidingWindowMedian
    {
        public double[] GetMedian(int[] input, int k)
        {

            if (input.Length < k)
                return null;

            double[] result = new double[input.Length - k + 1];

            Heap maxHeap = new Heap("MAX"); //1st half
            Heap minHeap = new Heap("MIN"); //2nd half           

            for (int i = 0; i < input.Length; i++)
            {

                //Add new item to the appropiate Heap
                if (i == 0)
                    maxHeap.Insert(input[i]);
                else if (minHeap.Length > 0)
                {
                    if (input[i] >= minHeap.Peak())
                        minHeap.Insert(input[i]);
                    else
                        maxHeap.Insert(input[i]);
                }
                else
                {
                    if (input[i] <= maxHeap.Peak())
                        maxHeap.Insert(input[i]);
                    else
                        minHeap.Insert(input[i]);
                }

                //remove item outside the window from respective Heap
                if (i >= k)
                {
                    if (maxHeap.Length > 0 && input[i - k] <= maxHeap.Peak())
                        maxHeap.Delete(input[i - k]);
                    else
                        minHeap.Delete(input[i - k]);
                }

                //balance Heap
                while (Math.Abs(minHeap.Length - maxHeap.Length) > 1)
                {
                    if (minHeap.Length > maxHeap.Length)
                        TransferHeapRoot(minHeap, maxHeap);
                    else
                        TransferHeapRoot(maxHeap, minHeap);
                }

                //add current window median to the result
                if (i + 1 >= k)
                    result[i - k + 1] = (minHeap.Length > maxHeap.Length) ? (double)minHeap.Peak() : (maxHeap.Length > minHeap.Length ? (double)maxHeap.Peak() : ((double)(minHeap.Peak()) + maxHeap.Peak()) / 2);

            }

            return result;

        }

        public void TransferHeapRoot(Heap source, Heap destination)
        {
            if (source.Length == 0 || source == destination)
                return;
            var item = source.Peak();
            source.Delete(item);
            destination.Insert(item);
        }
    }

    public class EncodeDecode
    { 
        public static void Test()
        {
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine("Hello, World");
            }

            string[] input = new string[3] { "a", "abc", "1" };

            var result = toString(input);

            Console.WriteLine(result);
            
            var newInput = fromString(result);

            if (input.Length  != newInput.Length)
                Console.WriteLine("Test Case Failed");

            for (int i=0;i<input.Length;i++)
            {
                if (input[i] != newInput[i])
                    Console.WriteLine("Test Case Failed");
            }

            Console.WriteLine("Test Case Passed");
            

        }

        public static string toString(string[] input)
        {
            if (input.Length == 0)
                return "";

            var header = "";
            var body = "";
            foreach (var str in input)
            {
                if (header == "")
                    header = $"{str.Length.ToString()}";
                else
                    header = $"{header},{str.Length.ToString()}";

                body = $"{body}{str}";
            }

            return $"{header}:{body}";
        }

        public static string[] fromString(string input)
        {

            if (input == "")
                return new string[] { };

            string header = input.Split(':')[0];

            var len = header.Split(',').Length;

            string[] result = new string[len];

            var last = 0; int index = 0;
            foreach (var currentStr in header.Split(','))
            {
                int current = Convert.ToInt32(currentStr);
                result[index++] = input.Substring(header.Length + 1 + last, current - last);
                last = current;
            }

            return result;

        }
    }


}
