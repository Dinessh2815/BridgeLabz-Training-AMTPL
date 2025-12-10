using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.HashSets
{
    internal class UniqueEmailValidator
    {
        public static void Main(string[] args)
        {
            HashSet<string> emails = new HashSet<string> { "a@gmail.com", "b@gmail.com", "a@gmail.com", "c@gmail.com", "b@gmail.com", "d@gmail.com" };

            foreach (string email in emails)
            {
                Console.WriteLine($"{email}");
            }

            Console.WriteLine($"Total unique registrations: {emails.Count}");

            if (emails.Contains("c@gmail.com"))
            {
                Console.WriteLine("c@gmail.com is registered");
            }
            else
            {
                Console.WriteLine("c@gmail.com is not registered");
            }



        }
        
    }
}
