
namespace MoveAllZerosToEnd
{
    internal class Program
    {
        static void Main()
        {
            int nonZeroCount = 0;
            int[] arr = { 12, 0, 4, 5, 0, 6, 0 };
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    arr[nonZeroCount] = arr[i];
                    nonZeroCount++;
                }
            }

            for(int i = nonZeroCount; i < arr.Length; i++)
            {
                arr[i] = 0;
            }
            Console.WriteLine(string.Join(",", arr)); 
            
            
        }
    }
}
