namespace ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Dinessh";
            string reversed = "";
            for(int i = name.Length - 1; i > 0; i--)
            {
                reversed += name[i]; 
            }

            Console.WriteLine(reversed);


        }
    }
}
