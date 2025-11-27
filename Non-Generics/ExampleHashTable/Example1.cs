using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Non_Generics.ExampleHashTable
{
    internal class Example1
    {
        public static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();

            ht["id"] = 101;
            ht["name"] = "Dinessh";
            ht["score"] = 95;

            ht.Remove("id");

            foreach (DictionaryEntry entry in ht) 
            {
                Console.WriteLine($"{entry.Key} : {entry.Value}");
            }
        }
    }
}
