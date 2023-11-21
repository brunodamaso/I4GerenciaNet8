using I4Gerencia.Services.Settings;
using I4Gerencia.Views;

namespace I4Gerencia.ViewModels;

public class ShellViewModel
{
    private readonly INavigator navigator;
    private readonly ISettingsService settingsService;

    public ShellViewModel(INavigator _navigator, ISettingsService _settingsService)
    {
        navigator = _navigator;
        settingsService = _settingsService;
        _ = Start();
    }

    public async Task Start()
    {
        if (this.settingsService.AuthAccessToken.IsNullOrEmpty())
        {
            //await navigator.NavigateViewModelAsync<InstallViewModel>(this, qualifier: Qualifiers.ClearBackStack);
        }
        else
        {
            //await navigator.NavigateViewModelAsync(this,typeof(LoginViewModel), qualifier: Qualifiers.ClearBackStack);
        }


    }
}
