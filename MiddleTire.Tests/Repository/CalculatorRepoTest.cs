using Microsoft.AspNetCore.Http;
using MiddleTire.Enums;
using MiddleTire.Model;
using MiddleTire.Repository;
using NUnit.Framework;

namespace MiddleTire.Tests.Repository;

[TestFixture]
[TestOf(typeof(CalculatorRepo))]
public class CalculatorRepoTest
{

    [Test]
    public void METHOD()
    {
        // ARANGE 
        var calculatorRepo = new CalculatorRepo();
        ICalculatorOperation calculatorOperation = new CalculatorOperation();
        calculatorOperation.Calculator = ECalculators.CashedCalculator;
        calculatorOperation.Operation = ECalculatorOperations.Addition;
        calculatorOperation.Number1 = 1; 
        calculatorOperation.Number2 = 2;
        
        // ACT 
        IResult actualResult = calculatorRepo.Calculate(calculatorOperation);
        
        // assert 
        int exspectedResult = 3; 
        
        Assert.Equals(actualResult, exspectedResult);
    }    
}