namespace I4Gerencia.Services.Install;

public interface IInstallServices
{
    Task<TypeReturn> CheckLicencia(string Server, string BBDD, string TipoBD);
    Task<string?> GetConfig();
}
