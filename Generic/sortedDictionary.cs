using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class sortedDictionary
    {
        public static void Main(string[] args)
        {
            Dictionary<int, string> employees = new Dictionary<int, string>();

            
            employees.Add(101, "Ramesh");
            employees.Add(102, "Anita");
            employees.Add(103, "Vikram");
            employees.Add(104, "Suresh");
            employees.Add(105, "Kavya");

            var sorted = employees.OrderBy(x => x.Value);
            Console.WriteLine("Employees in alphabetical order:");

            foreach(var x in sorted)
            {
                Console.WriteLine($"ID: {x.Key} and Name: {x.Value}");
            }
        }
    }
}
