using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Queue
{
    internal class OrderElements
    {
        public static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>();

            q.Enqueue(10);
            q.Enqueue(20);
            q.Enqueue(30);

            while (q.Count > 0)
            {

                Console.WriteLine(q.Dequeue());
            }
            
        }
    }
}
