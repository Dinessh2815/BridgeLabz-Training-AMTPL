using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Lambda
{
    internal class Example
    {
        public static void Main(string[] args)
        {
            Func<int, int> square = x => x * x;

            Console.WriteLine(square(5));

        }
    }
}
