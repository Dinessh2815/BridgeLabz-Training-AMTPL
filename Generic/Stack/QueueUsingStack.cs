namespace ConsoleProject.Stack
{
    internal class QueueUsingStack
    {
        public class MyQueue<T>
        {
            Stack<T> StackIn = new Stack<T>();
            Stack<T> StackOut = new Stack<T>();


            public void Enqueue(T item)
            {
                StackIn.Push(item);
            }

            public T Dequeue()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException();
                }

                MoveInToOut();

                return StackOut.Pop();
            }
            

            public T Peek()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException();
                }

                MoveInToOut();

                return StackOut.Peek();
            }
            public bool IsEmpty()
            {
                return StackIn.Count == 0 && StackOut.Count == 0;
            }
            private void MoveInToOut()
            {
                if (StackOut.Count == 0)
                {
                    while (StackIn.Count > 0)
                    {
                        StackOut.Push(StackIn.Pop());
                    }
                }
            }
        }
        public static void Main(string[] args)
        {
            


            MyQueue<int> q = new MyQueue<int>();

            q.Enqueue(10);
            q.Enqueue(20);
            q.Enqueue(30);

            Console.WriteLine(q.Peek());  
            Console.WriteLine(q.Dequeue()); 

            Console.WriteLine(q.Dequeue()); 

            q.Enqueue(40);

            Console.WriteLine(q.Peek());

        }
    }
}
