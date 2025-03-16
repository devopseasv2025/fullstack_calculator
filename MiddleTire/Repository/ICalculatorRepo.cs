using MiddleTire.Model;

namespace MiddleTire.Repository;

public interface ICalculatorRepo
{
    Task<IResult> Calculate(ICalculatorOperation calculatorOperation);
    Task<IResult> GetCalculatorOperations(); 
}