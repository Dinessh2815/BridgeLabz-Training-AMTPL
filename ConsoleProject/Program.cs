

using System;
namespace myFirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Student name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Student age:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Fee");
            double fee = Convert.ToDouble(Console.ReadLine());



            Console.WriteLine($"Hi {name}! your age is: {age}. \n The fee student paying is: {fee}");
        }
    }
}