using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Non_Generics.ExampleHashTable
{
    internal class Example2HashTable
    {
        public static void Main(string[] args)
        {
            Hashtable students = new Hashtable();

            students.Add(101, "Arun");
            students.Add(102, "Meera");
            students.Add(103, "Dinessh");
            students.Add(104, "Kavi");

            students[102] = "Meera Kumari";
            students.Remove(104);
            if (students.ContainsKey(103))
            {
                Console.WriteLine("103 found");
            }
            else
            {
                Console.WriteLine("103 not found");
            }

            if (students.ContainsValue("Arun"))
            {
                Console.WriteLine("Arun present");
            }
            else
            {
                Console.WriteLine("Arun not present");
            }

            foreach (DictionaryEntry items in  students)
            {
                Console.WriteLine($"Roll No.: {items.Key} and Names: {items.Value}");
            }

            Console.WriteLine(students.Count);
        }
    }
}
