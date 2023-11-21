using I4Kernel.Services.Settings;

namespace I4Gerencia.Services.Settings;

public class SettingsService : SettingsServiceBase, ISettingsService
{
    #region Setting Constants

    private const string AccessToken = "access_token";
    private const string IdToken = "id_token";
    private const string IdUseMocks = "use_mocks";
    private const string IdRutaInsys4 = "RutaInsys4";
    private const string IdServerInsys4 = "ServerInsys4";
    private const string IdTipoServerInsys4 = "TipoServerInsys4";
    private const string IdBBDDServerInsys4 = "BBDDServerInsys4 ";
    private const string IdConnectionString = "ConnectionString";
    private const string IdUsuarioActual = "UsuarioActual";
    private const string IdRecordar = "Recordar";
    private const string IdPassWord = "PassWord";


    #endregion

    public SettingsService() //ISettingsServiceBase settingsServiceBase
    {
        //settingsServiceBase.AuthAccessToken = GlobalSetting.Instance.AuthToken;
    }

    #region Settings Properties

    public string RutaInsys4
    {
        get => Preferences.Get(IdRutaInsys4, "C:\\compartida\\insys4\\");
        set => Preferences.Set(IdRutaInsys4, value);
    }
    public string ServerInsys4
    {
        get => Preferences.Get(IdServerInsys4, string.Empty);
        set => Preferences.Set(IdServerInsys4, value);
    }
    public string BBDDServerInsys4
    {
        get => Preferences.Get(IdBBDDServerInsys4, string.Empty);
        set => Preferences.Set(IdBBDDServerInsys4, value);
    }
    public int TipoServerInsys4
    {
        get => Preferences.Get(IdTipoServerInsys4, 6);
        set => Preferences.Set(IdTipoServerInsys4, value);
    }
    public string ConnectionString
    {
        get => Preferences.Get(IdConnectionString, string.Empty);
        set => Preferences.Set(IdConnectionString, value);
    }

    public string UsuarioActual
    {
        get => Preferences.Get(IdUsuarioActual, string.Empty);
        set => Preferences.Set(IdUsuarioActual, value);
    }
    public bool Recordar
    {
        get => Preferences.Get(IdRecordar, false);
        set => Preferences.Set(IdRecordar, value);
    }
    public string PassWord
    {
        get => Preferences.Get(IdPassWord, string.Empty);
        set => Preferences.Set(IdPassWord, value);
    }

    #endregion
}