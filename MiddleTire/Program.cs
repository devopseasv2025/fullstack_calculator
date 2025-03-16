using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiddleTire.Data;
using MiddleTire.Model;
using MiddleTire.Repository;

namespace MiddleTire;

public static class Program
{
    public static async Task Main(string[] args)  // Make Main async to use await
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                policy => policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        // Register the repository service
        builder.Services.AddScoped<ICalculatorRepo, CalculatorRepoMariaDb>();
        
        // Get connection string from environment variables or use a default
        var connectionString = Environment.GetEnvironmentVariable("MariaDBConnectionString") 
                               ?? "server=localhost;database=your_db;user=your_user;password=your_password;";

        for (int i = 0; i < 100; i++)
        { 
            Console.WriteLine("HERE IS THE CONNECTION STRING " + connectionString);
        }
        
        // Register MariaDB context
        builder.Services.AddDbContext<MariaDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        );

        var app = builder.Build();

        app.UseCors("AllowAll");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        // Define the API endpoint
        app.MapPost("/api/calculate", async ([FromBody] CalculatorOperation calcOperation, ICalculatorRepo calculatorRepoMariaDb) =>
        {
            try
            {
                var result = await calculatorRepoMariaDb.Calculate(calcOperation);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Results.BadRequest("An error occurred");
            }
        });

        app.MapGet("/api/calculations", async (ICalculatorRepo calculatorRepoMariaDb) =>
        {
            return await calculatorRepoMariaDb.GetCalculatorOperations(); 
        });


        

        // Run the application
        await app.RunAsync();
    }
}
