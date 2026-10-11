using Microsoft.EntityFrameworkCore;
using WorkSphere.Domain.Entities;

namespace WorkSphere.Infrastructure.Data;

public sealed class WorkSphereDbContext(
    DbContextOptions<WorkSphereDbContext> options)
    : DbContext(options)
{
    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(WorkSphereDbContext).Assembly);
    }
}