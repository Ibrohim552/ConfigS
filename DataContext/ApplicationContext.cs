using EFcoreWebAPi.Models;
using Microsoft.EntityFrameworkCore;

namespace EFcoreWebAPi.DataContext;

public class ApplicationContext:DbContext
{
    public DbSet<Doctors> Doctor { get;  set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}