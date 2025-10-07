using Microsoft.EntityFrameworkCore;
using Taller.Backend.Data;
using Taller.Backend.Repositories.Interfaces;
using Taller.Shared.Entities;
using Taller.Shared.Responses;

namespace Taller.Backend.Repositories.Implementations;

public class EmployeesRepository : GenericRepository<Employee>, IEmployeesRepository
{
    private readonly DataContext _context;

    public EmployeesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public virtual async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string name) => new ActionResponse<IEnumerable<Employee>>
    {
        WasSuccess = true,
        Result = await _context.Employees.Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name)).ToListAsync()
    };
}