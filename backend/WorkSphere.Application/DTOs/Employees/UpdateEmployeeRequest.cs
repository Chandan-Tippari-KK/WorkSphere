
using System.ComponentModel.DataAnnotations;

namespace WorkSphere.Application.DTOs.Employees;

public sealed class UpdateEmployeeRequest
{
    [Required, StringLength(50, MinimumLength = 1)]
    public string FirstName { get; init; } = string.Empty;

    [Required, StringLength(50, MinimumLength = 1)]
    public string LastName { get; init; } = string.Empty;

    [Required, EmailAddress, StringLength(254)]
    public string Email { get; init; } = string.Empty;

    [Required, StringLength(100, MinimumLength = 1)]
    public string Department { get; init; } = string.Empty;

    [Required, StringLength(100, MinimumLength = 1)]
    public string JobTitle { get; init; } = string.Empty;

    [Required]
    public DateTime? DateOfJoining { get; init; }

    public bool IsActive { get; init; }
}