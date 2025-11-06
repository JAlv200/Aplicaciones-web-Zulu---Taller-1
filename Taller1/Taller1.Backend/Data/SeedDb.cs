using Microsoft.EntityFrameworkCore;
using Taller.Backend.UnitsOfWork.Interfaces;
using Taller.Shared.Entities;
using Taller.Shared.Enums;

namespace Taller.Backend.Data;

public class SeedDb
{
    private readonly DataContext _context;
    private readonly IUsersUnitOfWork _usersUnitOfWork;

    public SeedDb(DataContext context, IUsersUnitOfWork usersUnitOfWork)
    {
        _context = context;
        _usersUnitOfWork = usersUnitOfWork;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckEmployeesScript();
        await CheckEmployeesAsync();
        await CheckCountriesFullScriptAsync();
        await CheckRoles();
        await CheckUserAsync("1020", "Juan", "Alvarez", "juanjo@yopmail.com",
            "321 463 5869", "Grove street", UserType.Admin);
    }

    private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email,
        string phone, string adress, UserType userType)
    {
        var user = await _usersUnitOfWork.GetUserAsync(email);
        if (user == null)
        {
            user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
                PhoneNumber = phone,
                Address = adress,
                Document = document,
                City = _context.Cities.FirstOrDefault(),
                UserType = userType
            };

            await _usersUnitOfWork.AddUserAsync(user, "password123");
            await _usersUnitOfWork.AddUserToRoleAsync(user, userType.ToString());
        }

        return user;
    }

    private async Task CheckRoles()
    {
        await _usersUnitOfWork.CheckRoleAsync(UserType.Admin.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.User.ToString());
    }

    private async Task CheckCountriesFullScriptAsync()
    {
        if (!_context.Countries.Any())
        {
            var countriesSQLScript = File.ReadAllText("Data\\CountriesStatesCities.sql");
            _context.Database.SetCommandTimeout(300); // Increase time to read and execute the SQL Script, not enough RAM/Time to load all the data
            await _context.Database.ExecuteSqlRawAsync(countriesSQLScript);
        }
    }

    private async Task CheckEmployeesScript()
    {
        if (!_context.Employees.Any())
        {
            var employeesSQLScript = File.ReadAllText("Data\\employees_insert.sql");
            await _context.Database.ExecuteSqlRawAsync(employeesSQLScript);
        }
    }

    private async Task CheckEmployeesAsync()
    {
        if (!_context.Employees.Any())
        {
            // Reg1
            _context.Employees.Add(new Employee
            {
                FirstName = "Juan Fernando",
                LastName = "Garcia",
                IsActive = true,
                HireDate = new DateTime(2024, 3, 12, 03, 12, 0), // Create dates manually with DateTime ctor
                Salary = new Random().Next(1100000, 10000001) // Generate random numbers between 1.1M and 10M
            });
            // Reg2
            _context.Employees.Add(new Employee
            {
                FirstName = "Ana Marina",
                LastName = "Giraldo",
                Salary = 2500000.00m
            });
            // Reg3
            _context.Employees.Add(new Employee
            {
                FirstName = "Juan Esteban",
                LastName = "Vargas",
                IsActive = true,
                HireDate = new DateTime(2024, 3, 12, 03, 12, 0),
                Salary = new Random().Next(1100000, 10000001)
            });
            // Reg4
            _context.Employees.Add(new Employee
            {
                FirstName = "Sofia",
                LastName = "Garcia",
                HireDate = null,
                Salary = 1750000.00m
            });
            // Reg5
            _context.Employees.Add(new Employee
            {
                FirstName = "Leonardo",
                LastName = "Yepes",
                IsActive = true,
                HireDate = new DateTime(2023, 2, 22, 04, 30, 0),
                Salary = new Random().Next(1100000, 10000001)
            });
            // Reg6
            _context.Employees.Add(new Employee
            {
                FirstName = "Juan Pablo",
                LastName = "Martinez",
                IsActive = true,
                HireDate = new DateTime(2022, 7, 14, 02, 32, 0),
                Salary = 3000000.00m
            });
            // Reg7
            _context.Employees.Add(new Employee
            {
                FirstName = "Hilary",
                LastName = "Ospina",
                IsActive = false,
                HireDate = new DateTime(2021, 10, 05, 11, 12, 0),
                Salary = new Random().Next(1100000, 10000001)
            });
            // Reg8
            _context.Employees.Add(new Employee
            {
                FirstName = "Juan Pablo",
                LastName = "Velez",
                IsActive = true,
                HireDate = new DateTime(2020, 6, 25, 13, 42, 0),
                Salary = 2500000.00m
            });
            // Reg9
            _context.Employees.Add(new Employee
            {
                FirstName = "Valentina",
                LastName = "Lopez",
                IsActive = false,
                HireDate = new DateTime(2022, 4, 12, 14, 36, 0),
                Salary = 1250000.00m
            });
            // Reg10
            _context.Employees.Add(new Employee
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