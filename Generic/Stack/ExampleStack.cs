public class ExampleStack
{
    public static void Main(string[] args)
    {
        Stack<string> names = new Stack<string>();

        names.Push("A");
        names.Push("B");
        names.Push("C");

        Console.WriteLine(names.Pop());
        Console.WriteLine(names.Peek());
        Console.WriteLine(names.Contains("A"));
    }
}