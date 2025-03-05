﻿using System;
using Calculator;
using NUnit.Framework;

namespace Calculator.Tests;

[TestFixture]
[TestOf(typeof(CachedCalculator))]

public class CachedCalculatorTest
{
     [Test]
    public void Substract()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;
        
        // Act
        var result = calc.Subtract(b, a);
        
        // Assert
        Assert.That(result, Is.EqualTo(1));
        
    }
    [Test]
    public void Multiply()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;
        
        // Act
        var result = calc.Multiply(a, b);
        
        // Assert
        Assert.That(result, Is.EqualTo(6));
    }
    
    [Test]
    public void Divide()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 10;
        var b = 2;
        
        // Act
        var result = calc.Divide(a, b);
        
        // Assert
        Assert.That(result, Is.EqualTo(5));
    }
    
    [Test]
    public void Factorial_Positive()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 5;
        
        // Act
        var result = calc.Factorial(a);
        
        // Assert
        Assert.That(result, Is.EqualTo(120));
    }
    
    [Test]
    public void Factorial_Negative()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = -1;
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => calc.Factorial(a));
    }
    
    [Test]
    public void Factorial_Zero()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 0;
        
        // Act
        var result = calc.Factorial(a);
        
        // Assert
        Assert.That(result, Is.EqualTo(1));
    }
    
    [Test]
    public void IsPrime_One()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 1;
        
        // Act
        var result = calc.IsPrime(a);
        
        // Assert
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void IsPrime_Prime()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 7;
        
        // Act
        var result = calc.IsPrime(a);
        
        // Assert
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void IsPrime_NotPrime()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 14;
        
        // Act
        var result = calc.IsPrime(a);
        
        // Assert
        Assert.That(result, Is.False);
    }
}