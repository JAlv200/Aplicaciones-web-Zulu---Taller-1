using Taller.Shared.DTOs;
using Taller.Shared.Entities;
using Taller.Shared.Responses;

namespace Taller.Backend.Repositories.Interfaces;

public interface IEmployeesRepository
{
    Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination);
}