using MiddleTire.Model;

namespace MiddleTire.Repository;

public interface ICalculatorRepo
{
    IResult Calculate(ICalculatorOperation calculatorOperation);
}