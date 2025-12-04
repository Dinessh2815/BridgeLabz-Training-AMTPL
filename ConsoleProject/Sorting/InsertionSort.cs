using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Sorting
{
    internal class InsertionSort
    {
        public static void Main(string[] args)
        {
            int[] arr = { 5, 1, 4, 3, 2 };

            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;
                while (j > 0 && arr[j] < arr[j - 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = temp;

                    j--;
                }
            }

            foreach (int i in arr)
            {
                Console.Write($"{i},");
            }

        }
    }
}
