using System.Diagnostics.Metrics;
using Taller.Backend.Repositories.Interfaces;
using Taller.Backend.UnitsOfWork.Interfaces;
using Taller.Shared.DTOs;
using Taller.Shared.Entities;
using Taller.Shared.Responses;

namespace Taller.Backend.UnitsOfWork.Implementations;

public class EmployeesUnitOfWork : GenericUnitOfWork<Employee>, IEmployeesUnitOfWork
{
    private readonly IEmployeesRepository _employeesRepository;

    //Reducing some logic, no heritage of GenericUnitOfWork
    public EmployeesUnitOfWork(IGenericRepository<Employee> repository, IEmployeesRepository employeesRepository) : base(repository)
    {
        _employeesRepository = employeesRepository;
    }

    public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination) =>
        await _employeesRepository.GetAsync(pagination);
}