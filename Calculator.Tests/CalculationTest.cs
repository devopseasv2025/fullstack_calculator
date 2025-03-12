using Calculator;
using NUnit.Framework;

namespace Calculator.Tests;

[TestFixture]
[TestOf(typeof(CachedCalculator.Calculation))]
public class CalculationTest
{
    
    private class TestableCalculation : CachedCalculator.Calculation
    {
        public TestableCalculation(string operation, int a, int? b = null)
            : base(operation, a, b) { }
    }

    [Test]
    public void GetKey_ReturnsCorrectString()
    {
        // Arrange
        var calculation = new TestableCalculation("+", 5, 3);

        // Act
        string key = calculation.GetKey();

        // Assert
        Assert.That("5+3", Is.EqualTo(key));
    }

    [Test]
    public void GetKey_ReturnsCorrectString_WhenBIsNull()
    {
        // Arrange
        var calculation = new TestableCalculation("-", 10, null);

        // Act
        string key = calculation.GetKey();

        // Assert
        Assert.That("10-", Is.EqualTo(key));
    }
}