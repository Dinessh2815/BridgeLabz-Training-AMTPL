using System;


namespace ConditionsProject
{
    class Calculator
    {
        static void Main()
        {
            Console.WriteLine("Enter first number:");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the operator");
            char op = Convert.ToChar(Console.ReadLine());

            double result = 0;

            if (op == '+') 
            {
                result = num1 + num2;
            }
            else if (op == '-')
            {
                result = num1 - num2;
            }
            else if (op == '*')
            {
                result = num1 * num2;
            }
            else if (op == '/')
            {
                if (num2 != 0)
                {
                    result = num1 / num2;
                } else {
                    Console.WriteLine("Error: Division by zero");
                }
            }
            else
            {
                Console.WriteLine("Invalid operator");
            }

                Console.WriteLine($"The result is: {result:F}");
            }
        }
    }
