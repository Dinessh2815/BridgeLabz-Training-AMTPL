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
    public class MultipleDivideTests
    {
        [TestCase(4, 2, 2)]
        [TestCase(6, 2, 3)]
        [TestCase(14, 2, 7)]
        public void Divide_Return(int a, int b, int expected)
        {
            var calc = new Calculator();
            Assert.That(calc.Divide(a, b), Is.EqualTo(expected));
        }
    }
}