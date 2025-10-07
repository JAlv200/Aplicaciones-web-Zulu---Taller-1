using Taller.Backend.Repositories.Interfaces;
using Taller.Backend.UnitsOfWork.Interfaces;
using Taller.Shared.Entities;
using Taller.Shared.Responses;

namespace Taller.Backend.UnitsOfWork.Implementations;

public class EmployeesUnitOfWork : IEmployeesUnitOfWork
{
    private readonly IEmployeesRepository _employeesRepository;

    //Reducing some logic, no heritage of GenericUnitOfWork
    public EmployeesUnitOfWork(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string name) =>
    await _employeesRepository.GetAsync(name);
}