namespace I4Gerencia.Services.AppEnvironment;

public interface IAppEnvironmentService
{
    IInstallServices InstallServices { get; }
    //ILoginServices LoginServices { get; }
    //IHomeServices HomeServices { get; }
    //IPizarraServices PizarraServices { get; }
    //IMenuServices MenuServices { get; }
    //IPanelServices PanelServices { get; }

    void UpdateDependencies(bool useMockServices);
}
