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

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            return await FilterName(pagination);
        }

        return new ActionResponse<IEnumerable<Employee>>
        {
            WasSuccess = true,
            Result = await queryable
                .OrderBy(x => x.LastName)
                .Paginate(pagination)
                .ToListAsync()
        };
    }

    public virtual async Task<ActionResponse<IEnumerable<Employee>>> FilterName(PaginationDTO pagination) // Converted GetAsync(string name) to this method, because ... should have probably deleted it ... but i like this method
    {
        var queryable = _context.Employees
            .AsQueryable()
            .Where(x => x.FirstName.ToLower().Contains(pagination.Filter!.ToLower()) || x.LastName.ToLower().Contains(pagination.Filter!.ToLower()))
            .OrderBy(x => x.LastName)
            .Paginate(pagination);

        return new ActionResponse<IEnumerable<Employee>>
        {
            WasSuccess = true,
            Result = await queryable.ToListAsync()
        };
    }
}