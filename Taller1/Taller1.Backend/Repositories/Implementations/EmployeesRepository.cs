using Microsoft.EntityFrameworkCore;
using Taller.Backend.Data;
using Taller.Backend.Helpers;
using Taller.Backend.Repositories.Interfaces;
using Taller.Shared.DTOs;
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

    public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync()
    {
        var employees = await _context.Employees
            .OrderBy(x => x.LastName)
            .ToListAsync();

        return new ActionResponse<IEnumerable<Employee>>
        {
            WasSuccess = true,
            Result = employees
        };
    }

    public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.Employees
            .AsQueryable();

        return new ActionResponse<IEnumerable<Employee>>
        {
            WasSuccess = true,
            Result = await queryable
                .OrderBy(x => x.LastName)
                .Paginate(pagination)
                .ToListAsync()
        };
    }

    public virtual async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string name) => new ActionResponse<IEnumerable<Employee>>
    {
        WasSuccess = true,
        Result = await _context.Employees.Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name)).ToListAsync()
    };
}