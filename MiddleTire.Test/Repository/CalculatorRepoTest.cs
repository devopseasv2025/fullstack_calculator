using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Http;
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

    [Test]
    public void Operations_returns_obj_IResult_valid()
    {
        // ARRANGE
        ICalculatorRepo calculatorRepo = new CalculatorRepo();
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
    
}