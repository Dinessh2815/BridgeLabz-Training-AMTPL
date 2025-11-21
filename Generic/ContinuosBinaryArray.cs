using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class ContinuosBinaryArray
    {
        public static void Main(string[] args)
        {
            int[] arr = { 0, 0, 1, 0, 1, 1, 0 };

            Dictionary<int, int> firstIndex = new Dictionary<int, int>();

            int PrefixSum = 0;
            int maxLegth = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                PrefixSum += (arr[i] == 0 ? -1 : 1);

                if (firstIndex.ContainsKey(PrefixSum))
                {
                    maxLegth = Math.Max(i - firstIndex[PrefixSum], maxLegth);
                    

                }
                else 
                {
                    firstIndex[PrefixSum] = i;
                }

                
            }
            Console.WriteLine(maxLegth);
        }
    }
}
