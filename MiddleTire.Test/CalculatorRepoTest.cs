using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
    public void Calculate_With_CashedCalculator_Returns_200OK()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = 3,
            Operation = ECalculatorOperations.Addition,
            Calculator = ECalculators.CashedCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as Ok<ICalculatorOperation>;

        // Assert
        Assert.That(result.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    }

    [Test]
    public void Calculate_With_SimpleCalculator_Returns_200OK()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = 3,
            Operation = ECalculatorOperations.Addition,
            Calculator = ECalculators.SimpleCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as Ok<ICalculatorOperation>;

        // Assert
        Assert.That(result.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    }

    [Test]
    public void Calculate_With_InvalidCalculator_Returns_400BadRequest()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = 3,
            Operation = ECalculatorOperations.Addition,
            Calculator = (ECalculators)999 // Invalid value
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as BadRequest<string>;

        // Assert
        Assert.That(result.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
        Assert.That(result.Value, Is.EqualTo("Invalid calculatorOperation"));
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
    # region multiplication
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
    # endregion

    #region Divison
    // multiple 
    [Test]
    public void Calculate_Simple_Div_Missing_Number2_Returns_BadRequest()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = null, // Missing second number
            Operation = ECalculatorOperations.Division,
            Calculator = ECalculators.SimpleCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as BadRequest<string>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
    }
    
    [Test]
    public void Calculate_Simple_Div_Returns_ok()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = 10, 
            Operation = ECalculatorOperations.Division,
            Calculator = ECalculators.SimpleCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as Ok<ICalculatorOperation>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    }
    [Test]
    public void Calculate_Cashed_Div_Missing_Number2_Returns_BadRequest()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = null, // Missing second number
            Operation = ECalculatorOperations.Division,
            Calculator = ECalculators.CashedCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as BadRequest<string>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
    }
    
    [Test]
    public void Calculate_Cashed_Div_Returns_ok()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Number2 = 10, 
            Operation = ECalculatorOperations.Division,
            Calculator = ECalculators.CashedCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as Ok<ICalculatorOperation>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    }
    

    #endregion

    #region Factorial

    

    
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
    #endregion

    #region IsPrime
    
    [Test]
    public void Calculate_Simple_IsPrime_Returns_ok()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Operation = ECalculatorOperations.Isprime,
            Calculator = ECalculators.SimpleCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as Ok<ICalculatorOperation>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    }
    [Test]
    public void Calculate_Cashed_IsPrime_Returns_ok()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Operation = ECalculatorOperations.Isprime,
            Calculator = ECalculators.CashedCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as Ok<ICalculatorOperation>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
    }
    

    #endregion
    
    # region defult

    public void Calculate_Cashed_defult_Returns_ok()
    {
        // Arrange
        ICalculatorOperation operation = new CalculatorOperation
        {
            Number1 = 5,
            Calculator = ECalculators.CashedCalculator
        };

        // Act
        var result = _calculatorRepo.Calculate(operation) as BadRequest<string>;

        // Assert
        Assert.That(result?.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
    }

    # endregion
    
}
