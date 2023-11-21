using I4Kernel.Services.Settings;

namespace I4Gerencia.Services.Settings;

public partial interface ISettingsService : ISettingsServiceBase
{
    string UsuarioActual { get; set; }
    string RutaInsys4 { get; set; }
    string ServerInsys4 { get; set; }
    string BBDDServerInsys4 { get; set; }
    int TipoServerInsys4 { get; set; }
    string ConnectionString { get; set; }
    bool Recordar { get; set; }
    string PassWord { get; set; }

}