
using WorkSphere.Domain.Entities;

namespace WorkSphere.Application.Interfaces;

public interface IEmployeeRepository
{
    Task<IReadOnlyList<Employee>> GetAllAsync(
        CancellationToken cancellationToken);

    Task<Employee?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken);

    Task<bool> EmailExistsAsync(
        string email,
        int? excludingEmployeeId,
        CancellationToken cancellationToken);

    Task AddAsync(
        Employee employee,
        CancellationToken cancellationToken);

    Task SaveChangesAsync(
        CancellationToken cancellationToken);

    void Delete(Employee employee);
}