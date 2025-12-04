using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Sorting
{
    internal class QuickSort
    {
        
        public static void Main(string[] args)
        {
            void QuickSort(int[] arr, int low, int high)
            {
                int PartitionPivet = Partition(arr, low, high);

                QuickSort(arr, low, PartitionPivet - 1);
                QuickSort(arr, PartitionPivet + 1, high);
            }

            int Partition(int[] arr, int low, int high)
            {
                int pivot = arr[high];
                int i = low - 1;

                for(int j = low; j < high; j++)
                {
                    if (arr[j] < pivot)
                    {
                        i++;
                        (arr[i], arr[j]) = (arr[j], arr[i]);
                    }

                    (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
                    return i + 1;

                }



            }
            int[] arr = { 9, 3, 7, 1, 6 };
            QuickSort(arr, 0, arr.Length - 1);

            foreach (int x in arr)
                Console.Write(x + " ");

        }
    }
}
