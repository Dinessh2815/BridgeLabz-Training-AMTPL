namespace ConsoleProject
{
    public class exampleOfList
    {
        public static void Main()
        {
            List<int> names = new List<int>();

            names.Add(1);
            names.Add(2);
            names.Add(3);
            names.Add(4);
            names.Add(5);

            Console.WriteLine(names[0]);
            Console.WriteLine(names[names.Count - 1]);
            Console.WriteLine(names.Count);
            Console.WriteLine(names.Contains(5));
            Console.WriteLine(names.IndexOf(4));



        }
    }
}
