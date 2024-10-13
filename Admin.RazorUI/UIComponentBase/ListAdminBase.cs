using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

public class ListAdminBase : ComponentBase
{
    [Inject]
	public IJSRuntime? JSRuntime { get; set; }
    
    [Inject]
    IAdminServices? AdminService {get; set; }

    [Parameter]
	public bool DeletingUser {get; set; } = false;

    protected List<UserApiResult>? AdminList {get; set; }

    protected override async Task OnInitializedAsync()
    {
       AdminList = await AdminService?.GetAdminUserList();
    }

    protected async void OnDeleted(int userId)
    {
        DeletingUser = true;
        AdminList = AdminList?.Where(x => x.id != userId).ToList();
        StateHasChanged();

        await Task.Delay(5000);
        DeletingUser = false;
        StateHasChanged();
        await Task.Run(() => JSRuntime?.InvokeVoidAsync("Swal.fire", args: "User data loading Completed."));
    }
}