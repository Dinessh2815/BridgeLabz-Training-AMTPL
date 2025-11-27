using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Stack
{
    internal class DecimalToBinary
    {
        public static void Main(string[] args)
        {
            int input = 15;
            Stack<int> stack = new Stack<int>();
            int remainder;

            if (input == 0)
            {
                Console.WriteLine("Binary = 0");
                return;
            }

            while (input > 0)
            {
                remainder = input % 2;
                stack.Push(remainder);
                input = input / 2;
            }

            Console.Write("Binary = ");
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
