using System;
namespace LoopsProject
{
    internal class Program
    {
        static void Main()
        {
            int i = 0;
            while(i >= 5)
            {
                Console.WriteLine($"Value: {i + 1}");
                i++;
            }
        }
    }
}
