using Calculator;
using MiddleTire.Enums;
using MiddleTire.Model;
using MySqlConnector;

namespace MiddleTire.Repository;

public class CalculatorRepoMariaDb : ICalculatorRepo
{
    private readonly Lazy<Calculator.ICalculator> _cashedCalculator = new Lazy<Calculator.ICalculator>(new CachedCalculator());
    private readonly Lazy<Calculator.ICalculator> _simpleCalculator = new Lazy<Calculator.ICalculator>(new SimpleCalculator());

    private readonly string _connectionString;
    
    public CalculatorRepoMariaDb(IConfiguration configuration)
    {
        _connectionString = configuration["MariaDBConnectionString"] 
                            ?? throw new ArgumentNullException("MariaDBConnectionString is missing.");
    }
    
    public async Task<IResult> Calculate(ICalculatorOperation calculatorOperation)
    {
        
        if (calculatorOperation.Calculator == ECalculators.CashedCalculator)
        {
            var result = _calculate(_cashedCalculator, calculatorOperation);  
            if (result == null) return Results.BadRequest("An error occured, formating of calculator operation is wrong");
            await StoreCalculationInDatabase(result);
            return Results.Ok(result);
        }  
        
        if (calculatorOperation.Calculator == ECalculators.SimpleCalculator)
        {
            var result = _calculate(_simpleCalculator, calculatorOperation);  
            if (result == null) return Results.BadRequest("An error occured, formating of calculator operation is wrong");
            await StoreCalculationInDatabase(result);
            return Results.Ok(result);
        }  
        
        return Results.BadRequest("Invalid calculatorOperation");
        
    }

    public async Task<IResult> GetCalculatorOperations()
    {
        var calc = await GetCalculatorOperationsFromDb();
        return Results.Ok(calc);
    }
    

    private async Task<List<ICalculatorOperation>> GetCalculatorOperationsFromDb()
    {
        var operations = new List<ICalculatorOperation>();

        var query = "SELECT * FROM CalculatorOperations";  // Assume a table for calculator operations
        await using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync();
        await using var command = new MySqlCommand(query, connection);
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            // Mapping database values to CalculatorOperation
            var operation = new CalculatorOperation
            {
                Number1 = (int)reader["number1"],
                Number2 = reader["number2"] as int?,
                Operation = Enum.Parse<ECalculatorOperations>(reader["operation"].ToString() ?? string.Empty),
                Result = reader["result"] as double?,
                Calculator = Enum.Parse<ECalculators>(reader["calculator"].ToString() ?? string.Empty)
            };

            operations.Add(operation);
        }

        return operations;
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
    
    private async Task StoreCalculationInDatabase(ICalculatorOperation calculatorOperation)
    {
        var query = @"INSERT INTO CalculatorOperations (number1, number2, operation, result, calculator) VALUES (@number1, @number2, @operation, @result, @calculator)";

        await using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync();
        await using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@number1", calculatorOperation.Number1);
        command.Parameters.AddWithValue("@number2", (object?)calculatorOperation.Number2 ?? DBNull.Value);
        command.Parameters.AddWithValue("@operation", (int)calculatorOperation.Operation);
        command.Parameters.AddWithValue("@result", (object?)calculatorOperation.Result ?? DBNull.Value);
        command.Parameters.AddWithValue("@calculator", (int)calculatorOperation.Calculator);

        await command.ExecuteNonQueryAsync();
    }
    
}