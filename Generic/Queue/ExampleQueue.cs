public class ExampleQueue
{
    public static void Main(string[] args)
    {
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Console.WriteLine(queue.Dequeue());

        Console.WriteLine(queue.Peek());


    }
}