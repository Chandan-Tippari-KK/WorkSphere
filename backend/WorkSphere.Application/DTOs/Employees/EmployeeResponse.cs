
namespace WorkSphere.Application.DTOs.Employees;

public sealed record EmployeeResponse(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Department,
    string JobTitle,
    DateTime DateOfJoining,
    bool IsActive,
    DateTime CreatedAtUtc);