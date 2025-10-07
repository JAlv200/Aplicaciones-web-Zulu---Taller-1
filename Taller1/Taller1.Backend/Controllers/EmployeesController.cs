using Microsoft.AspNetCore.Mvc;
using Taller.Backend.UnitsOfWork.Interfaces;
using Taller.Shared.Entities;

namespace Taller.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : GenericController<Employee>
{
    private readonly IGenericUnitOfWork<Employee> _unitOfWork;
    private readonly IEmployeesUnitOfWork _employeesUnitOfWork;

    public EmployeesController(IGenericUnitOfWork<Employee> unitOfWork, IEmployeesUnitOfWork employeesUnitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _employeesUnitOfWork = employeesUnitOfWork;
    }

    [HttpGet("{name}")]
    public virtual async Task<IActionResult> GetAsync(string name)
    {
        var action = await _employeesUnitOfWork.GetAsync(name);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest(action.Message);
    }
}