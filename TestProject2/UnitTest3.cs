using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleProject;
using NUnit.Framework;

namespace TestProject2
{
    [TestFixture]
    public class AddTest
    {
        [TestCase(2, 3, 5)]
        [TestCase(3, 4, 7)]
        [TestCase(4, 5, 9)]

        public void Add_Test(int a, int b, int expected)
        {
            var calc = new Calculator();
            Assert.That(calc.Add(a, b), Is.EqualTo(expected));
        }

    }

    
}
