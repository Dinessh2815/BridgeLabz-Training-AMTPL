
public class Example1
{

    public static void Main()
    {
        HashSet<string> names = new HashSet<string>();

        names.Add("a");
        names.Add("b");
        names.Add("c");
        names.Add("d");
        names.Add("a");

        names.Remove("b");

        foreach (string s in names)
        {
            Console.WriteLine(s); 
        }
    }
}