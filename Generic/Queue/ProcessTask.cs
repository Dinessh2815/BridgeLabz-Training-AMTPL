using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Queue
{
    internal class ProcessTask
    {
        public static void Main(string[] args)
        {
            Queue<string> process = new Queue<string>();

            process.Enqueue("Login");
            process.Enqueue("Load Dashboard");
            process.Enqueue("Fetch user Data");
            process.Enqueue("Login Activity");

            Console.WriteLine($"Processing: {process.Dequeue()}");
            Console.WriteLine($"Processing: {process.Dequeue()}");

            Console.WriteLine($"Next task: {process.Peek()}");
            Console.WriteLine(process.Count);

        }
    }
}
