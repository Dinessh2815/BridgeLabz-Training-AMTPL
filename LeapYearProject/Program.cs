using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a year (4 digits): ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int year) && input.Length == 4)
        {
            if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
            {
                Console.WriteLine($"{year} is a Leap Year.");
            }
            else
            {
                Console.WriteLine($"{year} is not a Leap Year.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter a 4-digit year.");
        }
    }
}
