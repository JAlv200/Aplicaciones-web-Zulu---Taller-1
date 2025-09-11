using Taller1.Backend.Repositories.Interfaces;
using Taller1.Backend.UnitsOfWork.Interfaces;
using Taller1.Shared.Entities;
using Taller1.Shared.Responses;

namespace Taller1.Backend.UnitsOfWork.Implementations;

public class EmployeesUnitOfWork : GenericUnitOfWork<Employee>, IEmployeesUnitOfWork
{
    private readonly IGenericRepository<Employee> _repository;
    private readonly IEmployeesRepository _employeesRepository;

    public EmployeesUnitOfWork(IGenericRepository<Employee> repository, IEmployeesRepository employeesRepository) : base(repository)
    {
        _repository = repository;
        _employeesRepository = employeesRepository;
    }

    public async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string name) =>
    await _employeesRepository.GetAsync(name);
}