//using I4Gerencia.Services.i18n;
using System.Reflection.Metadata;
using I4Gerencia.Business.Services.Settings;
using I4Kernel.Services;
using I4Kernel.ViewModels.Base;
using Microsoft.Extensions.Localization;
//using Uno.Extensions.Navigation;
using static I4Kernel.Common.Enum;

namespace I4Gerencia.Presentation.ViewModels;

public partial class InstallViewModel : ViewModelBase
{
    #region Variables    

    private readonly ISettingsService settingsService;
    private readonly IAppEnvironmentService appEnvironmentService;

    [ObservableProperty]
    private string _txtConfig;
    [ObservableProperty]
    private string _txtServer;
    [ObservableProperty]
    private string _txtBBDD;
    [ObservableProperty]
    private string _txtTipoBD;

    #endregion

    //private readonly IStringLocalizer stringLocalizer;

    public InstallViewModel(INavigator navigator ,IAppEnvironmentService _appEnvironmentService, ISettingsService _settingsService,IStringLocalizer stringLocalizer) //: base(parametro)
    {
        appEnvironmentService = _appEnvironmentService;
        settingsService = _settingsService;
        Navigator = navigator;
        StringLocalizer = stringLocalizer;
    }

    #region Commands
    [RelayCommand]
    protected virtual async Task DoAceptar()
    {
        if (await Install())
        {
            //bd await this.Navigator.NavigateViewModelAsync<LoginViewModel>(this, qualifier: Qualifiers.ClearBackStack);
        }
    }

    [RelayCommand]
    protected virtual async Task GetConfig()
    {
        string _texto = await appEnvironmentService.InstallServices.GetConfig();
        if (!_texto.IsNullOrEmpty())
        {
            StringReader Texto = new(_texto);
            if (Texto.ToString() != "")
            {
                TxtConfig = Texto.ReadLine();

                string linea = Texto.ReadLine().Replace(";", "").ToUpper();
                while (linea != null)
                {
                    string[] valores = linea.Split('=');
                    switch (valores[0])
                    {
                        case "NOMBRESERVIDOR":
                            TxtServer = valores[1];
                            break;
                        case "DIRECTORIODATOS":
                            TxtBBDD = valores[1];
                            if (!TxtBBDD.Contains("insys4"))
                            {
                                TxtBBDD = "Insys4" + TxtBBDD;
                            }
                            break;
                        case "TIPOBD":
                            int posi = int.Parse(valores[1]);
                            TxtTipoBD = ((TiposBBDD)posi).ToString();
                            break;
                        default:
                            break;
                    }
                    linea = Texto.ReadLine()?.Replace(";", "").ToUpper();
                }
            }
        }
        else
        {
            await this.ShowMessageDialogAsync(StringLocalizer.GetString("ArchivoIncorrecto"));
        }
    }

    [RelayCommand]
    protected virtual void DoCancel()
    {
        App.MainWindow.Close();
    }

    #endregion

    #region Private

    private async Task<bool> Install()
    {
        bool instalado = false;
        if (TxtServer.IsNullOrEmpty() == false && TxtBBDD.IsNullOrEmpty() == false && TxtTipoBD.IsNullOrEmpty() == false)
        {
            TypeReturn Licencia = await this.appEnvironmentService.InstallServices.CheckLicencia(TxtServer, TxtBBDD, TxtTipoBD);
            switch (Licencia)
            {
                case TypeReturn.OK:
                    await this.ShowMessageDialogAsync(StringLocalizer.GetString("InstallCorrecto"), Titulo: StringLocalizer.GetString("Configuracion"),Si: StringLocalizer.GetString("Aceptar.Text"));
                    this.settingsService.AuthAccessToken = string.Concat(TxtServer, "/", TxtBBDD, "/", TxtTipoBD);
                    instalado = true;
                    break;
                case TypeReturn.NoHayDatos:
                    await this.ShowMessageDialogAsync(StringLocalizer.GetString("ErrorQuery"));
                    break;
                case TypeReturn.ErrorBBDD:
                    await this.ShowMessageDialogAsync(StringLocalizer.GetString("ErrorBBDD"));
                    break;
                case TypeReturn.ErrorConexion:
                    await this.ShowMessageDialogAsync(StringLocalizer.GetString("ErrorNoHayConexion"));
                    break;
                default:
                    break;
            }
        }
        else
        {
            await this.ShowMessageDialogAsync(StringLocalizer.GetString("ErrorFaltanCampos"));
        }
        return instalado;
    }
    #endregion
}
