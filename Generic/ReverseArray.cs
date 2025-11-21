using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.LinkedList
{
    internal class ReverseArray
    {
        public static void Main(string[] args)
        {
            List<int> arr = new List<int> { 1, 2, 3, 4, };

            int start = 0;
            int end = arr.Count - 1;

            while (start < end)
            {
                int temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;


            }

            foreach(int i in arr)
            {
                Console.Write(i);
            }
        }
    }
}
