using I4Gerencia.Business.Services.Settings;
using I4Kernel.Services;
using Windows.Storage.Pickers;

namespace I4Gerencia.Business.Services.Install;

public class InstallServicesMock : IInstallServices
{
    private readonly ISettingsService SettingsService;

    public InstallServicesMock(ISettingsService _settingsService)
    {
        this.SettingsService = _settingsService;
    }

    public async Task<string> GetConfig()
    {
        string Texto;
        var fileOpenPicker = new FileOpenPicker();

        fileOpenPicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
        fileOpenPicker.FileTypeFilter.Add(".conf");
        var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.MainWindow);
        WinRT.Interop.InitializeWithWindow.Initialize(fileOpenPicker, hwnd);

        StorageFile pickedFile = await fileOpenPicker.PickSingleFileAsync();
        if (pickedFile != null && pickedFile.Name.ToUpper() == "I4INIT.CONF")
        {
            Texto = pickedFile.Path + "\r\n";
            Texto += await FileIO.ReadTextAsync(pickedFile);
        }
        else
        {
            Texto = null;
        }
        return Texto;
    }

    public async Task<TypeReturn> CheckLicencia(string Server, string BBDD, string TipoBD)
    {
        TypeReturn Sretorno = TypeReturn.ErrorConexion;
        Sretorno = TypeReturn.OK;
        return Sretorno;
    }   
}