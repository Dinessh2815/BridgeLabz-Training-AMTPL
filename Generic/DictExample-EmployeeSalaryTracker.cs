using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class DictExample_EmployeeSalaryTracker
    {
        public static void Main(string[] args)
        {
            Dictionary<int, int> salaries = new Dictionary<int, int>
            {
                {101, 50000},
                {102, 62000},
                {103, 48000},
                {104, 72000}
            };

            salaries.Add(105, 55000);
            salaries[102] = 65000;
            if (salaries.ContainsKey(103))
            {
                salaries.Remove(103);
            }

            foreach (var emp in salaries)
            {
                Console.WriteLine($"ID: {emp.Key}, Salary: {emp.Value}");
            }

            Console.WriteLine();
            Console.WriteLine($"Total Employees: {salaries.Count}");
            Console.WriteLine($"Highest Salary: {salaries.Values.Max()}");
            Console.WriteLine($"Lowest Salary: {salaries.Values.Min()}");

        }
    }
}
