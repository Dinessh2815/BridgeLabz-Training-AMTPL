using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Annotations
{
    public class Example
    {
        [Obsolete("Use CalculateNewSalary Instead")]
        public void CalculateSalary()
        {
            Console.WriteLine("Old");

        }

        public void CalculateNewSalary()
        {
            Console.WriteLine("New");


        }

        class User
        {
            [Required]
            public string Email { get; set; }
        }
        public static void Main(string[] args)
        {
            Example calc = new Example();

            calc.CalculateSalary();
            calc.CalculateNewSalary();

        }

    }

    
        
    
}

