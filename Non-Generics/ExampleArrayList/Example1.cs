using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Non_Generics.ExampleArrayList
{
    internal class Example1
    {
        public static void Main(string[] args)
        {
            ArrayList arr = new ArrayList();
            arr.Add(10);
            arr.Add("hello");
            arr.Add(3.5);

            arr.Insert(1, "Inserted");

            arr.RemoveAt(3);

            foreach(object i in arr)
            {
                Console.WriteLine(i);
            }
        }

        
    }
}
