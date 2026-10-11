
using WorkSphere.Application.DTOs.Employees;
using WorkSphere.Application.Interfaces;
using WorkSphere.Domain.Entities;

namespace WorkSphere.Application.Services;

public sealed class EmployeeService(
    IEmployeeRepository repository) : IEmployeeService
{
    public async Task<IReadOnlyList<EmployeeResponse>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var employees = await repository.GetAllAsync(cancellationToken);

        return employees.Select(Map).ToList();
    }

    public async Task<EmployeeResponse?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        var employee = await repository.GetByIdAsync(
            id, cancellationToken);

        return employee is null ? null : Map(employee);
    }

    public async Task<EmployeeResponse> CreateAsync(
        CreateEmployeeRequest request,
        CancellationToken cancellationToken)
    {
        var email = request.Email.Trim();

        if (await repository.EmailExistsAsync(
            email, null, cancellationToken))
        {
            throw new InvalidOperationException(
                "An employee with this email already exists.");
        }

        var employee = new Employee(
            request.FirstName,
            request.LastName,
            email,
            request.Department,
            request.JobTitle,
            request.DateOfJoining!.Value);

        await repository.AddAsync(employee, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);

        return Map(employee);
    }

    public async Task<EmployeeResponse?> UpdateAsync(
        int id,
        UpdateEmployeeRequest request,
        CancellationToken cancellationToken)
    {
        var employee = await repository.GetByIdAsync(
            id, cancellationToken);

        if (employee is null)
        {
            return null;
        }

        var email = request.Email.Trim();

        if (await repository.EmailExistsAsync(
            email, id, cancellationToken))
        {
            throw new InvalidOperationException(
                "Another employee already uses this email.");
        }

        employee.Update(
            request.FirstName,
            request.LastName,
            email,
            request.Department,
            request.JobTitle,
            request.DateOfJoining!.Value,
            request.IsActive);

        await repository.SaveChangesAsync(cancellationToken);

        return Map(employee);
    }

    public async Task<bool> DeleteAsync(
        int id,
        CancellationToken cancellationToken)
    {
        var employee = await repository.GetByIdAsync(
            id, cancellationToken);

        if (employee is null)
        {
            return false;
        }

        repository.Delete(employee);
        await repository.SaveChangesAsync(cancellationToken);

        return true;
    }

    private static EmployeeResponse Map(Employee employee) =>
        new(
            employee.Id,
            employee.FirstName,
            employee.LastName,
            employee.Email,
            employee.Department,
            employee.JobTitle,
            employee.DateOfJoining,
            employee.IsActive,
            employee.CreatedAtUtc);
}