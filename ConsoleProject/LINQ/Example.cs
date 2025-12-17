using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.LINQ
{
    internal class Example
    {
        class Employee
        {
            public string Name { get; set; }
            public string Department { get; set; }
            public DateTime JoiningDate { get; set; }
        }

        class Product
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
        }

        class Student
        {
            public string Name { get; set; }
            public int Score { get; set; }
        }

        class Order
        {
            public decimal Amount { get; set; }
        }

        class Customer
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }


        public static void Main(string[] args)
        {
            // ================= EMPLOYEES =================
            List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "Arun", Department = "IT", JoiningDate = DateTime.Now.AddMonths(-2) },
            new Employee { Name = "Meera", Department = "HR", JoiningDate = DateTime.Now.AddMonths(-8) },
            new Employee { Name = "Karthik", Department = "IT", JoiningDate = DateTime.Now.AddMonths(-4) },
            new Employee { Name = "Divya", Department = "Finance", JoiningDate = DateTime.Now.AddMonths(-1) },
            new Employee { Name = "Ravi", Department = "IT", JoiningDate = DateTime.Now.AddYears(-1) }
        };


            // ================= PRODUCTS =================
            List<Product> products = new List<Product>
        {
            new Product { Name = "Laptop", Category = "Electronics", Price = 75000 },
            new Product { Name = "Mobile", Category = "Electronics", Price = 45000 },
            new Product { Name = "Table", Category = "Furniture", Price = 15000 },
            new Product { Name = "Chair", Category = "Furniture", Price = 5000 },
            new Product { Name = "Headphones", Category = "Electronics", Price = 8000 },
            new Product { Name = "Sofa", Category = "Furniture", Price = 40000 }
        };


            // ================= STUDENTS =================
            List<Student> students = new List<Student>
        {
            new Student { Name = "Amit", Score = 85 },
            new Student { Name = "Sneha", Score = 72 },
            new Student { Name = "Rohit", Score = 90 },
            new Student { Name = "Neha", Score = 88 },
            new Student { Name = "Vikas", Score = 65 }
        };


            // ================= ORDERS =================
            List<Order> orders = new List<Order>
        {
            new Order { Amount = 1200 },
            new Order { Amount = 5600 },
            new Order { Amount = 2300 },
            new Order { Amount = 9800 },
            new Order { Amount = 4500 }
        };


            // ================= CUSTOMERS =================
            List<Customer> customers = new List<Customer>
        {
            new Customer { Name = "Raj", Age = 28 },
            new Customer { Name = "Suresh", Age = 35 },
            new Customer { Name = "Anita", Age = 42 },
            new Customer { Name = "Kiran", Age = 30 },
            new Customer { Name = "Pooja", Age = 38 }
        };


            // ================= BOOKS =================
            List<string> books = new List<string>
        {
            "Atomic Habits",
            "Clean Code",
            "Algorithms Unlocked",
            "Design Patterns",
            "Agile Principles"
        };


            // ================= NUMBERS =================
            List<int> numbers = new List<int> { 3, 6, 9, 12, 15, 18, 21, 24 };


            // ================= CITIES =================
            List<string> cities = new List<string>
        {
            "Chennai",
            "Mumbai",
            "Delhi",
            "chennai",
            "Bangalore",
            "MUMBAI"
        };

            Console.WriteLine("Sample data initialized successfully!");


            Console.WriteLine("========= Question 1 Filter Employees ==========");

            var ITEmployee = employees.Where(e => e.Department == "IT");

            foreach (var employee in ITEmployee)
            {
                Console.WriteLine("Name: " + employee.Name + "\n" + "Joining Date: " + employee.JoiningDate + "\n");
            }

            Console.WriteLine("========= Question 2 Sort by Length ==========");

            //order by length
            var SortedCities = cities.OrderBy(e => e.Length);

            foreach (var City in SortedCities)
            {
                Console.WriteLine(City);
            }

            //order by ascending char
            Console.WriteLine("\n");
            var SortedCitiesASC = cities.OrderBy(e => e);
            foreach (var City in SortedCitiesASC)
            {
                Console.WriteLine(City);
            }

            Console.WriteLine("========= Question 3 Group Products & Avg Price==========\n");

            //using Group BY and SELECT for printing the grouped category and the AvgPrice

            var AvgProducts = products.GroupBy(e => e.Category).Select(g => new { Category = g.Key, AvgPrice = g.Average(p => p.Price) });

            foreach(var Product in AvgProducts)
            {
                Console.WriteLine(Product);
            }

            //Using only Group by

            var groups = products.GroupBy(p => p.Category);

            foreach(var Group in groups)
            {
                Console.WriteLine("Category : " + Group.Key);

                foreach( var Product in Group)
                {
                    Console.WriteLine(Product); 
                }
            }
            Console.WriteLine("\n========= Question 4 High-Scoring Students in order ==========\n");


            var ExceptionalStudents = students.Where(e => e.Score >= 80).OrderBy(s => s.Name).Select(s => new { s.Name, s.Score });

            foreach(var student in ExceptionalStudents)
            {
                Console.WriteLine("Name : " + student.Name + "\nScore : " + student.Score);
            }

            Console.WriteLine("\n========= Question 5 Even Number Descending ==========\n");

            var evenDesc = numbers.Where(n => n % 2 == 0).OrderByDescending(n => n);

            foreach(int i in evenDesc)
            {
                Console.WriteLine(i);
            }
        }
    }
}
