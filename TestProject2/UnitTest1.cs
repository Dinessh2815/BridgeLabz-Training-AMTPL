using ConsoleProject;
using NUnit.Framework;

namespace TestProject2
{
    [TestFixture]
    public class AddTests
    {
        private Calculator calc;

        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }

        [Test]
        public void Add_ReturnsCorrectSum()
        {
            int result = calc.Add(10, 20);

            Assert.That(result, Is.EqualTo(30));
        }
    }
    public class MultipleAddTests
    {
        [TestCase(10, 20, 60)]
        [TestCase(5, 5, 10)]
        [TestCase(-10, -10, -20)]

        public void Add_MultipleTest(int a, int b, int expected)
        {
            var calc = new ConsoleProject.Calculator();
            Assert.That(calc.Add(a, b), Is.EqualTo(expected));
        }
    }
}