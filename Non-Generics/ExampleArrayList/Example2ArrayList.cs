using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Non_Generics.ExampleArrayList
{
    internal class Example2ArrayList
    {
        public static void Main(string[] args)
        {
            ArrayList list = new ArrayList();

            list.Add(45);
            list.Add(90);
            list.Add(78);
            list.Add(90);
            list.Add(56);

            list.Insert(2, 100);

            list.RemoveAt(3);

            if (list.Contains(56))
            {
                Console.WriteLine("56 found");
            }
            else
            {
                Console.WriteLine("56 not found");
            }

            Console.WriteLine(list.IndexOf(78));

            foreach (var item in list)
            {
                Console.WriteLine(item); 
            }
        }
    }
}
