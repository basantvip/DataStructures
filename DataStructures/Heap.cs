using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DataStructures
{
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

        public static void Demo()
        {   
            Console.WriteLine("Enter Comma Separated Heap Elements:");
            var input = "1,4,8,5,2,3"; //Console.ReadLine();            

            //********************MAX HEAP DEMO************************//
            Console.WriteLine($"input: {input} ");
            Heap maxHeap = new Heap(input, "max");
            maxHeap.Print();

            Console.WriteLine("Enter a value to insert in Max Heap:");
            var item = Console.ReadLine();
            if (int.TryParse(item, out int val))
            {
                maxHeap.Insert(val);
                maxHeap.Print();
            }

            Console.WriteLine("Enter a value to be Deleted from Max Heap:");
            item = Console.ReadLine();
            if (int.TryParse(item, out val))
            {
                maxHeap.Delete(val);
                maxHeap.Print();
            }

            //********************MIN HEAP DEMO************************//
            Console.WriteLine($"input: {input} ");
            Heap minHeap = new Heap(input, "min");
            minHeap.Print();

            Console.WriteLine("Enter a value to insert in Min Heap:");
            item = Console.ReadLine();
            if (int.TryParse(item, out val))
            {
                minHeap.Insert(val);
                minHeap.Print();
            }

            Console.WriteLine("Enter a value to be Deleted from Min Heap:");
            item = Console.ReadLine();
            if (int.TryParse(item, out val))
            {
                minHeap.Delete(val);
                minHeap.Print();
            }

            Console.ReadLine();
        }
    }
}
