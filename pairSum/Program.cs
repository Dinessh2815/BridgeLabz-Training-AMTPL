using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] nums = { 2, 7, 11, 15, 7, 2 };
        int target = 9;

        FindAllPairs(nums, target);
    }

    static void FindAllPairs(int[] nums, int target)
    {
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

        Console.WriteLine("Pairs: ");

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (map.ContainsKey(complement))
            {
                foreach (int index in map[complement])
                {
                    Console.WriteLine($"({complement}, {nums[i]}) -> indices ({index}, {i})");
                }
            }

            if (!map.ContainsKey(nums[i]))
            {
                map[nums[i]] = new List<int>();
            }

            map[nums[i]].Add(i);
        }
    }
}
