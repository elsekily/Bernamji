using bernamji.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Bernamji.DataAccess.Persistence;

public class BernamjiDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public BernamjiDbContext(DbContextOptions<BernamjiDbContext> options)
           : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

    }
}
