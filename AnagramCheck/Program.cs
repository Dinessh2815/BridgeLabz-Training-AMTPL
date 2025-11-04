namespace AnagramCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input1 = "Listen";
            string input2 = "SILENT";

            input1 = new string(input1.ToLower().Replace(" ", "").ToArray());
            input2 = new string(input2.ToLower().Replace(" ", "").ToArray());

            if (input1.Length != input2.Length)
            {
                Console.WriteLine("Not an anagram (different lengths)");
            }
            else
            {
                char[] arr1 = input1.ToCharArray();
                char[] arr2 = input2.ToCharArray();

                Array.Sort(arr1);
                Array.Sort(arr2);

                if(arr1.SequenceEqual(arr2))
                {
                    Console.WriteLine("this is Anagram");

                }
                else
                {
                    Console.WriteLine("Nope");
                }
            }
        }
    }
}
