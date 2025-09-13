using Microsoft.EntityFrameworkCore;

namespace Taller1.Backend.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckEmployeesAsync();
    }

    private async Task CheckEmployeesAsync()
    {
        if (!_context.Employees.Any())
        {
            // Registro1
            _context.Employees.Add(new Shared.Entities.Employee
            {
                FirstName = "Juan Fernando",
                LastName = "Garcia",
                IsActive = true,
                HireDate = new DateTime(2024, 3, 12, 03, 12, 0), // Crear fechas manualmente con año, mes, dia, hora, min, sec
                Salary = new Random().Next(1100000, 10000001) // Generar numeros aleatorios entre 1.1M y 10M
            });
            // Registro2
            _context.Employees.Add(new Shared.Entities.Employee
            {
                FirstName = "Ana Marina",
                LastName = "Giraldo",
                IsActive = false,
                HireDate = new DateTime(2024, 3, 12, 03, 12, 0),
                Salary = 2500000.00m
            });
            // Registro3
            _context.Employees.Add(new Shared.Entities.Employee
            {
                FirstName = "Juan Esteban",
                LastName = "Vargas",
                IsActive = true,
                HireDate = new DateTime(2024, 3, 12, 03, 12, 0),
                Salary = new Random().Next(1100000, 10000001)
            });
            // Registro4
            _context.Employees.Add(new Shared.Entities.Employee
            {
                FirstName = "Sofia",
                LastName = "Garcia",
                IsActive = false,
                HireDate = null,
                Salary = 1750000.00m
            });
            // Registro5
            _context.Employees.Add(new Shared.Entities.Employee
            {
                FirstName = "Leonardo",
                LastName = "Yepes",
                IsActive = true,
                HireDate = new DateTime(2023, 2, 22, 04, 30, 0),
                Salary = new Random().Next(1100000, 10000001)
            });
            // Registro6
            _context.Employees.Add(new Shared.Entities.Employee
            {
                FirstName = "Juan Pablo",
                LastName = "Martinez",
                IsActive = true,
                HireDate = new DateTime(2022, 7, 14, 02, 32, 0),
                Salary = 3000000.00m
            });
            // Registro7
            _context.Employees.Add(new Shared.Entities.Employee
            {
                FirstName = "Hilary",
                LastName = "Ospina",
                IsActive = false,
                HireDate = new DateTime(2021, 10, 05, 11, 12, 0),
                Salary = new Random().Next(1100000, 10000001)
            });
            // Registro8
            _context.Employees.Add(new Shared.Entities.Employee
            {
                FirstName = "Juan Pablo",
                LastName = "Velez",
                IsActive = true,
                HireDate = new DateTime(2020, 6, 25, 13, 42, 0),
                Salary = 2500000.00m
            });
            // Registro9
            _context.Employees.Add(new Shared.Entities.Employee
            {
                FirstName = "Valentina",
                LastName = "Lopez",
                IsActive = false,
                HireDate = new DateTime(2022, 4, 12, 14, 36, 0),
                Salary = 1250000.00m
            });
            // Registro10
            _context.Employees.Add(new Shared.Entities.Employee
            {
                FirstName = "Jesica",
                LastName = "Fernandez",
                IsActive = true,
                HireDate = new DateTime(2021, 5, 22, 15, 37, 0),
                Salary = new Random().Next(1100000, 10000001)
            });
            await _context.SaveChangesAsync();
        }
    }
}