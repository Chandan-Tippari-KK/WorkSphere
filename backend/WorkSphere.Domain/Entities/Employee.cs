
namespace WorkSphere.Domain.Entities;

public sealed class Employee
{
    public int Id { get; private set; }

    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public string Department { get; private set; } = string.Empty;

    public string JobTitle { get; private set; } = string.Empty;

    public DateTime DateOfJoining { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }

    private Employee()
    {
        // Required by Entity Framework Core.
    }

    public Employee(
        string firstName,
        string lastName,
        string email,
        string department,
        string jobTitle,
        DateTime dateOfJoining)
    {
        Validate(firstName, nameof(firstName), 50);
        Validate(lastName, nameof(lastName), 50);
        Validate(email, nameof(email), 254);
        Validate(department, nameof(department), 100);
        Validate(jobTitle, nameof(jobTitle), 100);

        if (dateOfJoining == default)
        {
            throw new ArgumentException(
                "Date of joining is required.",
                nameof(dateOfJoining));
        }

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        Email = email.Trim();
        Department = department.Trim();
        JobTitle = jobTitle.Trim();
        DateOfJoining = dateOfJoining.Date;
        IsActive = true;
        CreatedAtUtc = DateTime.UtcNow;
    }

    public void Update(
        string firstName,
        string lastName,
        string email,
        string department,
        string jobTitle,
        DateTime dateOfJoining,
        bool isActive)
    {
        Validate(firstName, nameof(firstName), 50);
        Validate(lastName, nameof(lastName), 50);
        Validate(email, nameof(email), 254);
        Validate(department, nameof(department), 100);
        Validate(jobTitle, nameof(jobTitle), 100);

        if (dateOfJoining == default)
        {
            throw new ArgumentException(
                "Date of joining is required.",
                nameof(dateOfJoining));
        }

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        Email = email.Trim();
        Department = department.Trim();
        JobTitle = jobTitle.Trim();
        DateOfJoining = dateOfJoining.Date;
        IsActive = isActive;
    }

    private static void Validate(
        string value,
        string propertyName,
        int maxLength)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(
                $"{propertyName} is required.",
                propertyName);
        }

        if (value.Trim().Length > maxLength)
        {
            throw new ArgumentException(
                $"{propertyName} cannot exceed {maxLength} characters.",
                propertyName);
        }
    }
}