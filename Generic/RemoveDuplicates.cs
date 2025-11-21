using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.LinkedList
{
    internal class RemoveDuplicates
    {
        public static void Main(string[] args)
        {
            List<int> arr = new List<int> { 1, 1, 2, 2, 3, 3, 4 };
            List<int> arr2 = new List<int>();

            for(int i = 0; i < arr.Count(); i++)
            {
                if (i == 0 || arr[i] != arr[i - 1])
                {
                    arr2.Add(arr[i]);
                }
            }

            Console.Write(string.Join(",", arr2));

           

        }
    }
}
