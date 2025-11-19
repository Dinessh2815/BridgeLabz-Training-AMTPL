using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class Polymorphism
    {
        public class Animal 
        {

            public virtual void Speak()
            {
                Console.WriteLine("Generic animal speaks");
            }


        }
        public class Dog : Polymorphism.Animal
        {
            public override void Speak()
            {
                Console.WriteLine("Dog barking");
            }
        }
        public class Cat : Polymorphism.Animal
        {
            public override void Speak()
            {
                Console.WriteLine("Cat meowing");
            }
        }
    }


}
