using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Sorting
{
    internal class BubbleSort
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[] { 2, 3, 1, 4, 8, 7, 6 };
            int n = arr.Length;

            for (int pass = 0; pass < n - 1; pass++)
            {
                for (int i = 0; i < n - pass - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }
                }
            }

            for (int i = 0; i <= n - 1; i++)
            {
                Console.Write(arr[i] + ",");
            }
        }
    }
}
