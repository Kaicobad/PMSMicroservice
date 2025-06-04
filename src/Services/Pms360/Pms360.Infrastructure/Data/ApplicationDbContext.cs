using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Pms360.Domain.Entities;

namespace Pms360.Infrastructure.Data;
public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<PMSType> PMSTypes => Set<PMSType>();
    //public DbSet<PMSDurationType> PMSDurationTypes => Set<PMSDurationType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

}
