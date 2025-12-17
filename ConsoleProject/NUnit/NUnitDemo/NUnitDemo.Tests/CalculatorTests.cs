using NUnit.Framework;
using NUnitDemo;

namespace NUnitDemo.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Add_ShouldReturnCorrectSum()
        {
            // Arrange
            Calculator calc = new Calculator();

            // Act
            int result = calc.Add(10, 5);

            // Assert
            Assert.AreEqual(15, result);
        }
    }
}
