
using WorkSphere.Application.DTOs.Employees;

namespace WorkSphere.Application.Interfaces;

public interface IEmployeeService
{
    Task<IReadOnlyList<EmployeeResponse>> GetAllAsync(
        CancellationToken cancellationToken);

    Task<EmployeeResponse?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken);

    Task<EmployeeResponse> CreateAsync(
        CreateEmployeeRequest request,
        CancellationToken cancellationToken);

    Task<EmployeeResponse?> UpdateAsync(
        int id,
        UpdateEmployeeRequest request,
        CancellationToken cancellationToken);

    Task<bool> DeleteAsync(
        int id,
        CancellationToken cancellationToken);
}