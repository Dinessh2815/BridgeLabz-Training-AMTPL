using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.LINQ
{
    internal class PracticeExample
    {
        class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public int Salary { get; set; }
            public bool IsPermanent { get; set; }
        }

        public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Ram", Department = "IT", Salary = 70000, IsPermanent = true },
                new Employee { Id = 2, Name = "Sam", Department = "HR", Salary = 45000, IsPermanent = false },
                new Employee { Id = 3, Name = "Ana", Department = "IT", Salary = 90000, IsPermanent = true },
                new Employee { Id = 4, Name = "John", Department = "Finance", Salary = 60000, IsPermanent = false },
                new Employee { Id = 5, Name = "Maya", Department = "HR", Salary = 80000, IsPermanent = true }
            };

            Console.WriteLine("1) ");

            var permanent = employees.Where(e => e.IsPermanent);

            foreach(Employee employee in permanent)
            {
                Console.WriteLine(employee.Name);
            }

            Console.WriteLine("2) ");

            var highSalary = employees.Where(e => e.Salary > 60000).OrderBy(e => e.Name);

            foreach(Employee employee in highSalary)
            {
                Console.WriteLine(employee.Name);
            }

            Console.WriteLine("3) ");

            var ITEmployee = employees.Where(e => e.Department == "IT").Select(e => new { ITName = e.Name, ITSalary = e.Salary });

            foreach(var employee in ITEmployee)
            {
                Console.WriteLine($"{employee.ITName} - {employee.ITSalary}");

            }

            Console.WriteLine("4) ");

            var HighestToLowestSalary = employees.OrderByDescending(e => e.Salary);

            foreach(var employee in HighestToLowestSalary)
            {
                Console.WriteLine(employee.Name);
            }

            Console.WriteLine("5) ");

            var groupedEmployee = employees.GroupBy(e => e.Department);

            foreach(var dept in groupedEmployee)
            {
                Console.WriteLine("Dept :" + dept.Key);

                foreach(var employee in dept)
                {
                    Console.WriteLine(employee.Name);
                }
            }

        }

    }
}
