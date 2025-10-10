using Microsoft.AspNetCore.Components;
using Taller.Frontend.Repositories;
using Taller.Shared.Entities;

namespace Taller.Frontend.Components.Pages.Employees;

public partial class EmployeesIndex
{
    [Inject] private IRepository Repository { get; set; } = null!;
    private List<Employee>? employees;

    protected override async Task OnInitializedAsync()
    {
        var HttpResult = await Repository.GetAsync<List<Employee>>("/api/employees");
        Thread.Sleep(2000);
        employees = HttpResult.Response;
    }
}