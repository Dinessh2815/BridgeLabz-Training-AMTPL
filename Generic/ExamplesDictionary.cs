using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class ExampleOfDictionary
    {
        public static void Main(string[] args)
        {
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();

            Students.Add(1, "std1");
            Students.Add(2, "std2");
            Students.Add(3, "std3");
            Students.Remove(2);

            Students[3] = "UpdatedStudent";


            foreach (var student in Students) 
            {   
                Console.WriteLine($"Roll No : {student.Key} \nName : {student.Value}");
            }





        }
    }
}
