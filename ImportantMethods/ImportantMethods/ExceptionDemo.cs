using System;

namespace ImportantMethods
{
    internal class ExceptionDemo
    {
        private class InvalidAgeException : Exception
        {
            public InvalidAgeException(string message) : base(message) { }
        }

        static void CheckAge(int age)
        {
            if (age < 18)
            {
                throw new InvalidAgeException("Age must be 18 or above");
            }
        }

        public static void Main()
        {
            try
            {
                int x = 10;
                int y = 0;
                int result = x / y;

                CheckAge(15);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("You cannot divide by zero!");
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine("Invalid Age: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Always runs");
            }
        }
    }
}
