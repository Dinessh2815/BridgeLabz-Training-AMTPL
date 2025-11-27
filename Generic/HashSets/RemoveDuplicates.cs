public class RemoveDuplicates
{
    public static void Main(string[] args)
    {
        int[] arr = new int[] { 1, 2, 3, 3, 4, 5, 6, 6, 7, 2, 4, 5, 6 };
        HashSet<int> set = new HashSet<int>();

        for (int i = 0; i < arr.Length; i++) 
        {
            set.Add(arr[i]);
        }

        foreach(int i in set)
        {
            Console.WriteLine(i);
        }
    }
}