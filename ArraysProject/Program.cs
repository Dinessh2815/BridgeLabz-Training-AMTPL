namespace ArraysProject
{
    class Program
    {
        static void Main()
        {
            int[] arr = new int[5];
            arr[0] = 10;
            arr[1] = 20;
            arr[2] = 30;
            arr[3] = 40;
            arr[4] = 50;

            for(int i = 0; i <= 5; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
