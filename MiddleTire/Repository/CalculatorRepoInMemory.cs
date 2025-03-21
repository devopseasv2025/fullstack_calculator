﻿using Calculator;
using Microsoft.Extensions.Options;
using MiddleTire.Data;
using MiddleTire.Enums;
using MiddleTire.Model;
using MySqlConnector;

namespace MiddleTire.Repository;

public class CalculatorRepoInMemory 
{
    
    private readonly Lazy<Calculator.ICalculator> _cashedCalculator = new Lazy<Calculator.ICalculator>(new CachedCalculator());
    private readonly Lazy<Calculator.ICalculator> _simpleCalculator = new Lazy<Calculator.ICalculator>(new SimpleCalculator());
    
    public IResult Calculate(ICalculatorOperation calculatorOperation)
    {
        
        if (calculatorOperation.Calculator == ECalculators.CashedCalculator)
        {
            var result = _calculate(_cashedCalculator, calculatorOperation);  
            if (result == null) return Results.BadRequest("An error occured, formating of calculator operation is wrong");
            return Results.Ok(result);
        }  
        
        if (calculatorOperation.Calculator == ECalculators.SimpleCalculator)
        {
            var result = _calculate(_simpleCalculator, calculatorOperation);  
            if (result == null) return Results.BadRequest("An error occured, formating of calculator operation is wrong");
            return Results.Ok(result);
        }  
        
        return Results.BadRequest("Invalid calculatorOperation");
        
    }
    

    private static ICalculatorOperation? _calculate(Lazy<ICalculator> calculator, ICalculatorOperation calculatorOperation)
    {
        switch (calculatorOperation.Operation)
        {
            case ECalculatorOperations.Addition:
                
                if (calculatorOperation.Number2 == null) return null;
                calculatorOperation.Result = calculator.Value.Add(calculatorOperation.Number1, calculatorOperation.Number2.Value);
                return calculatorOperation;
            
            case ECalculatorOperations.Subtraction:
                if (calculatorOperation.Number2 == null) return null;
                calculatorOperation.Result = calculator.Value.Subtract(calculatorOperation.Number1, calculatorOperation.Number2.Value);
                return calculatorOperation;
            
            case ECalculatorOperations.Multiplication:
                if (calculatorOperation.Number2 == null) return null;
                calculatorOperation.Result = calculator.Value.Multiply(calculatorOperation.Number1, calculatorOperation.Number2.Value);
                return calculatorOperation;
            
            case ECalculatorOperations.Division:
                if (calculatorOperation.Number2 == null) return null;
                calculatorOperation.Result = calculator.Value.Divide(calculatorOperation.Number1, calculatorOperation.Number2.Value);
                return calculatorOperation;
            
            case ECalculatorOperations.Factorial: 
                calculatorOperation.Result = calculator.Value.Factorial(calculatorOperation.Number1);
                return calculatorOperation;
            
            case ECalculatorOperations.Isprime: 
                calculatorOperation.Result = calculator.Value.IsPrime(calculatorOperation.Number1) ? 0 : 1;
                return calculatorOperation;
            
            default:
                return null;
                
        }
        
    }
}