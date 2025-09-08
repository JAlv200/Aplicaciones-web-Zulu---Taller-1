using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller1.Backend.Data;
using Taller1.Shared.Entities;

namespace Taller1.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly DataContext _context;

    public EmployeesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _context.Employees.ToListAsync());
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetAsync(string name)
    {
        return Ok(await _context.Employees.Where
            (x => x.FirstName.Contains(name) || x.LastName.Contains(name))
            .ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Employee employee)
    {
        _context.Add(employee);
        await _context.SaveChangesAsync();
        return Ok(employee);
    }
}