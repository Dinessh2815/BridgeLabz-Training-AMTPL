namespace UniqueChar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 2, 3, 4, 3, 3, 6, 7, 8 };
            HashSet<int> uniqueChar = new HashSet<int>();

            foreach(char ch in arr)
            {
                uniqueChar.Add(ch);
            }

            Console.WriteLine($"Unique Charanters: {string.Join(',',uniqueChar)}");



            

        }
    }
}
