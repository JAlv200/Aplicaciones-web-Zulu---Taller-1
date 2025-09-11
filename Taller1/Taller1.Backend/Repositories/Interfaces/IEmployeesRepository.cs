using Taller1.Shared.Entities;
using Taller1.Shared.Responses;

namespace Taller1.Backend.Repositories.Interfaces;

public interface IEmployeesRepository
{
    Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string name);
}