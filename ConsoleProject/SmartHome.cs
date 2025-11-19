using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class SmartHome
    {
        public string Name;

        public SmartHome(string name)
        {
            Name = name;
        }

        public virtual void activate()
        {
            Console.WriteLine("Device getting turned on");
        }
    }

    class SmartLight : SmartHome
    {


        public SmartLight(string name) : base(name)
        { 

        }

        public override void activate() 
        {
            Console.WriteLine($"Smart Light {Name} is turned on!");
        }
    }
    class SmartFan : SmartHome
    {
        public SmartFan(string name) : base(name)
        {

        }

        public override void activate()
        {
            Console.WriteLine($"Smart Fan {Name} is turned on!");
        }
    }
}
