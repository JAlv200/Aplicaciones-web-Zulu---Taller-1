using Microsoft.AspNetCore.Components;
using MudBlazor;
using Taller.Frontend.Repositories;
using Taller.Shared.DTOs;

namespace Taller.Frontend.Components.Pages.Auth;

public partial class ChangePassword
{
    private ChangePasswordDTO changePasswordDTO = new();
    private bool Loading;

    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private IDialogService DialogService { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;
    [Inject] private IRepository Repository { get; set; } = null!;
    [CascadingParameter] private IMudDialogInstance MudDialog { get; set; } = null!;

    private async Task ChangePasswordAsync()
    {
        Loading = true;
        var responseHttp = await Repository.PostAsync("/api/accounts/changepassword", changePasswordDTO);
        Loading = false;
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            Snackbar.Add(message!, Severity.Error);
            return;
        }

        MudDialog.Cancel();
        NavigationManager.NavigateTo("/EditUser");
        Snackbar.Add("Contraseña modificada con éxito.", Severity.Success);
    }

    private void ReturnAction()
    {
        MudDialog.Cancel();
        NavigationManager.NavigateTo("/EditUsers");
    }
}