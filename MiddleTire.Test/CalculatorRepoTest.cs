using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MiddleTire.Enums;
using MiddleTire.Model;
using MiddleTire.Repository;
using NUnit.Framework;

namespace MiddleTire.Test.Repository;
// ARRANGE
// ACT
// ASSERT
[TestFixture]
[TestOf(typeof(CalculatorRepo))]
public class CalculatorRepoTest
{
    
    private CalculatorRepo _calculatorRepo;

    [SetUp]
    public void SetUp()
    {
        _calculatorRepo = new CalculatorRepo();
    }

    [Test]
    public void Operations_returns_obj_IResult_valid()
    {
        // ARRANGE
        CalculatorRepo calculatorRepo = new CalculatorRepo();
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 1,
            Number2 = 2,
            Operation = ECalculatorOperations.Addition,
            Calculator = ECalculators.CashedCalculator
        };

        // ACT
        var result = calculatorRepo.Calculate(operation);

        // ASSERT
        Assert.That(result, Is.InstanceOf<IResult>());
    }
    
    [Test]
    public void Calculate_Simple_Add_Missing_Number2_Returns_BadRequest()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = null, // Missing second number
            Operation = ECalculatorOperations.Addition,
            Calculator = ECalculators.SimpleCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as BadRequest<string>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
    }
    
    [Test]
    public void Calculate_Simple_Add_Returns_ok()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = 10, 
            Operation = ECalculatorOperations.Addition,
            Calculator = ECalculators.SimpleCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as Ok<ICalculatorOperation>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    }
    [Test]
    public void Calculate_Cashed_Add_Missing_Number2_Returns_BadRequest()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = null, // Missing second number
            Operation = ECalculatorOperations.Addition,
            Calculator = ECalculators.CashedCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as BadRequest<string>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
    }
    
    [Test]
    public void Calculate_Cashed_Add_Returns_ok()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = 10, 
            Operation = ECalculatorOperations.Addition,
            Calculator = ECalculators.CashedCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as Ok<ICalculatorOperation>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    }
    
    // subtract
    
    [Test]
    public void Calculate_Simple_Sub_Missing_Number2_Returns_BadRequest()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = null, // Missing second number
            Operation = ECalculatorOperations.Subtraction,
            Calculator = ECalculators.SimpleCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as BadRequest<string>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
    }
    
    [Test]
    public void Calculate_Simple_Sub_Returns_ok()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = 10, 
            Operation = ECalculatorOperations.Subtraction,
            Calculator = ECalculators.SimpleCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as Ok<ICalculatorOperation>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    }
    [Test]
    public void Calculate_Cashed_Sub_Missing_Number2_Returns_BadRequest()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = null, // Missing second number
            Operation = ECalculatorOperations.Subtraction,
            Calculator = ECalculators.CashedCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as BadRequest<string>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
    }
    
    [Test]
    public void Calculate_Cashed_Sub_Returns_ok()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = 10, 
            Operation = ECalculatorOperations.Subtraction,
            Calculator = ECalculators.CashedCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as Ok<ICalculatorOperation>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    }
    
    // multiple 
    [Test]
    public void Calculate_Simple_Mul_Missing_Number2_Returns_BadRequest()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = null, // Missing second number
            Operation = ECalculatorOperations.Multiplication,
            Calculator = ECalculators.SimpleCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as BadRequest<string>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
    }
    
    [Test]
    public void Calculate_Simple_Mul_Returns_ok()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = 10, 
            Operation = ECalculatorOperations.Multiplication,
            Calculator = ECalculators.SimpleCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as Ok<ICalculatorOperation>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    }
    [Test]
    public void Calculate_Cashed_Mul_Missing_Number2_Returns_BadRequest()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = null, // Missing second number
            Operation = ECalculatorOperations.Multiplication,
            Calculator = ECalculators.CashedCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as BadRequest<string>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
    }
    
    [Test]
    public void Calculate_Cashed_Mul_Returns_ok()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = 10, 
            Operation = ECalculatorOperations.Multiplication,
            Calculator = ECalculators.CashedCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as Ok<ICalculatorOperation>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    }
    
    // Factorial 
    
    [Test]
    public void Calculate_Simple_Factorial_Returns_ok()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Operation = ECalculatorOperations.Factorial,
            Calculator = ECalculators.SimpleCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as Ok<ICalculatorOperation>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    }
    [Test]
    public void Calculate_Cashed_Factorial_Returns_ok()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Operation = ECalculatorOperations.Factorial,
            Calculator = ECalculators.CashedCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as Ok<ICalculatorOperation>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    }
    
}