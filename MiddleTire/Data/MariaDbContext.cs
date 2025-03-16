using Microsoft.EntityFrameworkCore;
using MiddleTire.Model;

namespace MiddleTire.Data
{
    public class MariaDbContext : DbContext
    {
        public MariaDbContext(DbContextOptions<MariaDbContext> options) : base(options) { }

        public DbSet<ICalculatorOperation> CalculatorOperations { get; set; } // Replace with your actual entity model
    }
}