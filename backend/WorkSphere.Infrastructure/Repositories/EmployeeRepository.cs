using Microsoft.EntityFrameworkCore;
using WorkSphere.Application.Interfaces;
using WorkSphere.Domain.Entities;
using WorkSphere.Infrastructure.Data;

namespace WorkSphere.Infrastructure.Repositories;

public sealed class EmployeeRepository(
    WorkSphereDbContext dbContext) : IEmployeeRepository
{
    public async Task<IReadOnlyList<Employee>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext.Employees
            .AsNoTracking()
            .OrderBy(e => e.Id)
            .ToListAsync(cancellationToken);
    }

    public async Task<Employee?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await dbContext.Employees
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<bool> EmailExistsAsync(
        string email,
        int? excludingEmployeeId,
        CancellationToken cancellationToken)
    {
        var query = dbContext.Employees
            .Where(e => e.Email == email);

        if (excludingEmployeeId.HasValue)
        {
            query = query.Where(
                e => e.Id != excludingEmployeeId.Value);
        }

        return await query.AnyAsync(cancellationToken);
    }

    public async Task AddAsync(
        Employee employee,
        CancellationToken cancellationToken)
    {
        await dbContext.Employees.AddAsync(employee, cancellationToken);
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Delete(Employee employee)
    {
        dbContext.Employees.Remove(employee);
    }
}