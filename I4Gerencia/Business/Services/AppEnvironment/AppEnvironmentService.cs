namespace I4Gerencia.Business.Services.AppEnvironment;

public class AppEnvironmentService : IAppEnvironmentService
{
    private readonly IInstallServices _InstallServices;
    private readonly IInstallServices _InstallServicesMock;
    //private readonly ILoginServices _LoginServices;
    //private readonly ILoginServices _LoginServicesMock;
    //private readonly IHomeServices _HomeServices;
    //private readonly IHomeServices _HomeServicesMock;
    //private readonly IPizarraServices _PizarraServices;
    //private readonly IPizarraServices _PizarraServicesMock;
    //private readonly IMenuServices _MenuServices;
    //private readonly IMenuServices _MenuServicesMock;
    //private readonly IPanelServices _PanelServices;
    //private readonly IPanelServices _PanelServicesMock;


    public IInstallServices InstallServices { get; private set; }
    //public ILoginServices LoginServices { get; private set; }
    //public IHomeServices HomeServices { get; private set; }
    //public IPizarraServices PizarraServices { get; private set; }
    //public IMenuServices MenuServices { get; private set; }
    //public IPanelServices PanelServices { get; private set; }

    public AppEnvironmentService(IInstallServices installServices, IInstallServices installServicesMock)
        //ILoginServices loginServices, ILoginServices loginServicesMock,
        //IHomeServices homeServices, IHomeServices homeServicesMock,
        //IPizarraServices pizarraServices, IPizarraServices pizarraServicesMock,
        //IMenuServices menuServices, IMenuServices menuServicesMock,
        //IPanelServices panelServices, IPanelServices panelServicesMock)
    {
        _InstallServices = installServices;
        _InstallServicesMock = installServicesMock;
        //_LoginServices = loginServices;
        //_LoginServicesMock = loginServicesMock;
        //_HomeServices = homeServices;
        //_HomeServicesMock = homeServicesMock;
        //_PizarraServices = pizarraServices;
        //_PizarraServicesMock = pizarraServicesMock;
        //_MenuServices = menuServices;
        //_MenuServicesMock = menuServicesMock;
        //_PanelServices = panelServices;
        //_PanelServicesMock = panelServicesMock;
    }

    public void UpdateDependencies(bool useMockServices =false)
    {
        if (useMockServices)
        {
            InstallServices = _InstallServicesMock;
            //LoginServices = _LoginServicesMock;
            //HomeServices = _HomeServicesMock;
            //PizarraServices = _PizarraServicesMock;
            //MenuServices = _MenuServicesMock;
            //PanelServices = _PanelServicesMock;
        }
        else
        {
            InstallServices = _InstallServices;
            //LoginServices = _LoginServices;
            //HomeServices = _HomeServices;
            //PizarraServices = _PizarraServices;
            //MenuServices = _MenuServices;
            //PanelServices = _PanelServices;
        }
    }
}

