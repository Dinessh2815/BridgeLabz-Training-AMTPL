using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class LongestConsecutive
    {

public class LongestConsecutiveSeq
    {
        public static void Main(string[] args)
        {
            int[] nums = { 100, 4, 200, 1, 3, 2 };

            Console.WriteLine("Longest Consecutive Length = " + LongestConsecutive(nums));
        }

        public static int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            HashSet<int> set = new HashSet<int>(nums);
            int longest = 0;

            foreach (int num in set)
            {
                if (!set.Contains(num - 1))
                {
                    int currentNum = num;
                    int count = 1;


                    while (set.Contains(currentNum + 1))
                    {
                        currentNum++;
                        count++;
                    }

                    longest = Math.Max(longest, count);
                }
            }

            return longest;
        }
    }

}
}
