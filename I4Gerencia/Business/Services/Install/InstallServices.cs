using I4Gerencia.Business.Services.RepositorySql;
using I4Gerencia.Business.Services.Settings;
using I4Kernel.Services;
using Windows.Storage.Pickers;

namespace I4Gerencia.Business.Services.Install;

public class InstallServices : IInstallServices
{
    private readonly IRepositorySQL RepositorySql;
    private readonly ISettingsService SettingsService;

    public InstallServices(IRepositorySQL _RepositorySQL, ISettingsService _settingsService) //IRepositorySQL _RepositorySQL, 
    {
        this.RepositorySql = _RepositorySQL;
        this.SettingsService = _settingsService;
    }

    public async Task<string?> GetConfig()
    {
        string? Texto;
        FileOpenPicker fileOpenPicker = new ();

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

        if (ConnectivityService.CheckConnectivity())
        {
            string ConnectionString = string.Empty;
            if (TipoBD == TiposBBDD.SQL_Server.ToString())
            {
                ConnectionString = @"data source=" + Server + ";initial catalog=" + BBDD + ";user id=insys4sql;password=I4_7266bA*; Connect Timeout=30;TrustServerCertificate=True";
            }
            else
            {
                //// Postgres
            }

            this.SettingsService.ConnectionString = ConnectionString;
            string stringCommand = $"select * from metadata_usuarios where usu_abrev = 'INSYS4'";
            bool? resultado = await this.RepositorySql.ExecuteNonQuery(stringCommand);
            switch (resultado)
            {
                case true:
                    Sretorno = TypeReturn.OK;
                    break;
                case false:
                    Sretorno = TypeReturn.NoHayDatos;
                    break;
                default:
                    Sretorno = TypeReturn.ErrorBBDD;
                    break;
            }
        }
        return Sretorno;
    }   
}
