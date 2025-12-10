using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class ListExampleStudentMarks
    {
        public static void Main(string[] args)
        {
            List<int> marks = new List<int> {45, 89, 62, 33, 90, 75, 48 };

            marks.RemoveAll(x => x > 50);

            marks.Add(95);
            marks.Insert(2, 70);
            marks.Sort();

            Console.WriteLine($"Total Students : {marks.Count}");
            Console.WriteLine($"Highest : {marks.Max()}");
            Console.WriteLine($"Lowest : {marks.Min()}");
            Console.Write("All Marks: ");

            foreach (int i in marks)
            {
                Console.Write($"{i},");
            }

        }
    }
}
