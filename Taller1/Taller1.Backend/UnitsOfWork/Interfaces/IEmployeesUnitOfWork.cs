using Taller.Shared.DTOs;
using Taller.Shared.Entities;
using Taller.Shared.Responses;

namespace Taller.Backend.UnitsOfWork.Interfaces;

public interface IEmployeesUnitOfWork
{
    Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination);
}