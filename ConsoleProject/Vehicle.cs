using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class Vehicle
    {
        public string Brand;
        public int RegistrationNumber;

        public Vehicle(string brand, int registrationNumber)
        {
            Brand = brand;
            RegistrationNumber = registrationNumber;
        }

        public virtual void Display()
        {
            Console.WriteLine($"vehicle info : {Brand} and {RegistrationNumber}");
        }


    }

    class Car : Vehicle
    {
        public int DoorNumbers;
        public Car(string brand, int registrationNumber, int doorNumbers) : base(brand, registrationNumber)
        {
            DoorNumbers = doorNumbers;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"numbe rof doors : {DoorNumbers}");
        }


    }
}

