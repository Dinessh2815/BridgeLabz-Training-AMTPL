namespace ArraysProject
{
    class Program
    {
        static void Main()
        {
            int flips;
            Console.WriteLine("Enter the number of flips of the coin");
            flips = Convert.ToInt32(Console.ReadLine());
            if (flips < 0)
            {
                Console.WriteLine("Error: Invalid Number of flips entered!");
            }
            else
            {
                int headCount = 0;
                int tailCount = 0;

                Random random = new Random();

                for(int i = 0; i < flips; i++)
                {
                    double result = random.NextDouble();
                    if (result > 0.5)
                    {
                        headCount++;
                    }
                    else
                    {
                        tailCount++;
                    }
                }
                double tailPercentage = (double) tailCount / flips * 100;
                double headPercentage = (double) headCount / flips * 100;

                Console.WriteLine($"The number of flips are {flips}");
                Console.WriteLine($"the probability of tails is {tailPercentage}%");
                Console.WriteLine($"the probability of tails is {headPercentage}%");
            }
            }
        }
}