using System;
namespace ConsoleProject
{
    internal class Program
    {
        static void Main()
        {
            SmartHome l1 = new SmartLight("Vega");
            SmartHome f1 = new SmartFan("something");

            l1.activate();
            f1.activate();


        }
    }
}
