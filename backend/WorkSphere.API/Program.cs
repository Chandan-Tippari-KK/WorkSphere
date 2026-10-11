using Microsoft.EntityFrameworkCore;
using WorkSphere.Application.Interfaces;
using WorkSphere.Application.Services;
using WorkSphere.Infrastructure.Data;
using WorkSphere.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("WorkSphereDb")
    ?? throw new InvalidOperationException(
        "Connection string 'WorkSphereDb' was not found.");

builder.Services.AddDbContext<WorkSphereDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();