using MiddleTire.Enums;

namespace MiddleTire.Model;

public interface ICalculatorOperation
{
    int Number1 { get; set; }
    int Number2 { get; set; }
    ECalculatorOperations Operation { get; set; }
    double? Result { get; set; }
    ECalculators Calculator { get; set; }
}

public class CalculatorOperation : ICalculatorOperation
{
    public int Number1 { get; set; }
    public int Number2 { get; set; }
    public ECalculatorOperations Operation { get; set; }
    public double? Result { get; set; }
    public ECalculators Calculator { get; set; }
}