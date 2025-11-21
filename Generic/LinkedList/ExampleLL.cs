public class ExampleLL
{
    public static void Main(string[] args)
    {
        LinkedList<int> List = new LinkedList<int>();

        List.AddFirst(10);
        List.AddLast(20);

        var n = List.Find(10);

        List.AddAfter(n, 15);

        foreach(var LL in List)
        {
            Console.WriteLine(LL);
        }
    }
}