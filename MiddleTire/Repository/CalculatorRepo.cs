using Calculator;
using MiddleTire.Enums;
using MiddleTire.Model;

namespace MiddleTire.Repository;

public class CalculatorRepo : ICalculatorRepo
{
    
    private readonly Lazy<Calculator.ICalculator> _cashedCalculator = new Lazy<Calculator.ICalculator>(new CachedCalculator());
    private readonly Lazy<Calculator.ICalculator> _simpleCalculator = new Lazy<Calculator.ICalculator>(new SimpleCalculator());
    
    
    public IResult Calculate(ICalculatorOperation calculatorOperation)
    {
        if (calculatorOperation.Calculator == ECalculators.CashedCalculator) return _calculate(_cashedCalculator, calculatorOperation); 
        if (calculatorOperation.Calculator == ECalculators.SimpleCalculator) return _calculate(_simpleCalculator, calculatorOperation);  
        return Results.Problem("Invalid calculatorOperation");
    }
    

    private static IResult _calculate(Lazy<ICalculator> calculator, ICalculatorOperation calculatorOperation)
    {
        switch (calculatorOperation.Operation)
        {
            case ECalculatorOperations.Addition:
                calculatorOperation.Result = calculator.Value.Add(calculatorOperation.Number1, calculatorOperation.Number2);
                return Results.Ok(calculatorOperation);
            
            case ECalculatorOperations.Subtraction:
                calculatorOperation.Result = calculator.Value.Subtract(calculatorOperation.Number1, calculatorOperation.Number2);
                return Results.Ok(calculatorOperation);
            
            case ECalculatorOperations.Multiplication:
                calculatorOperation.Result = calculator.Value.Multiply(calculatorOperation.Number1, calculatorOperation.Number2);
                return Results.Ok(calculatorOperation);
            
            case ECalculatorOperations.Division:
                calculatorOperation.Result = calculator.Value.Divide(calculatorOperation.Number1, calculatorOperation.Number2);
                return Results.Ok(calculatorOperation);
            
            case ECalculatorOperations.Factorial: 
                calculatorOperation.Result = calculator.Value.Factorial(calculatorOperation.Number1);
                return Results.Ok(calculatorOperation);
            
            case ECalculatorOperations.Isprime: 
                calculatorOperation.Result = calculator.Value.IsPrime(calculatorOperation.Number1) ? 0 : 1;
                return Results.Ok(calculatorOperation);
            
            default:
                return Results.Problem("Invalid calculatorOperation");
                
        }
        
    }

    
    
    
}