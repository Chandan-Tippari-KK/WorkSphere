using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkSphere.Domain.Entities;

namespace WorkSphere.Infrastructure.Data.Configurations;

public sealed class EmployeeConfiguration
    : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Email)
            .HasMaxLength(254)
            .IsRequired();

        // Prevent duplicate email addresses at the database level too.
        builder.HasIndex(e => e.Email)
            .IsUnique();

        builder.Property(e => e.Department)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.JobTitle)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.DateOfJoining)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(e => e.IsActive)
            .IsRequired();

        builder.Property(e => e.CreatedAtUtc)
            .HasColumnType("datetime2")
            .IsRequired();
    }
}