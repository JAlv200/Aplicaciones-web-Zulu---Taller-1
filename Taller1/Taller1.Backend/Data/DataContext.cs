using Microsoft.EntityFrameworkCore;
using Taller.Shared.Entities;

namespace Taller.Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Employee>().Property(x => x.Salary).HasPrecision(18, 2); // decimal precision for salary property
    }
}