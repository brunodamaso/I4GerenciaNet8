namespace I4Gerencia;

public class App : Application
{
    private static readonly bool esMock = false;
    private readonly ISettingsService SettingsService;
    public static Window? MainWindow { get; private set; }
    public IHost? Host { get; private set; }

    public App()
    {
        SettingsService = new SettingsService();
    }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        var builder = this.CreateBuilder(args)
            .UseToolkitNavigation()
            .Configure(host => host
#if DEBUG                
                .UseEnvironment(Environments.Development)
#endif
                .UseLogging(configure: (context, logBuilder) =>
                {
                    logBuilder
                        .SetMinimumLevel(
                            context.HostingEnvironment.IsDevelopment() ?
                                LogLevel.Information :
                                LogLevel.Warning)
                        .CoreLogLevel(LogLevel.Warning);
                }, enableUnoLogging: true)

                .UseConfiguration(configure: configBuilder =>
                    configBuilder
                        .EmbeddedSource<App>()
                        .Section<AppConfig>()
                )
                .UseToolkit()
                .UseValidation()
                .UseThemeSwitching()
                .UseLocalization()
                .ConfigureServices((context, services) =>
                {
                    services = RegisterAppServices(services);
                })
                 .UseNavigation(RegisterRoutes)
            );
        MainWindow = builder.Window;

#if DEBUG
        MainWindow.EnableHotReload();
#endif
        Host = await builder.NavigateAsync<Shell>();
    }


    private IServiceCollection RegisterAppServices(IServiceCollection Services)
    {
        ////Services.AddLocalization();

        Services.AddSingleton<ISettingsServiceBase, SettingsServiceBase>();
        Services.AddSingleton<ISettingsService, SettingsService>();
        Services.AddSingleton<IServiceProvider, ServiceProvider>();
        ////Services.AddSingleton<INavigationService, NavigationService>();
        Services.AddSingleton<ISQLService, SQLService>();
        Services.AddSingleton<IRepositorySQL, RepositorySQL>();

        ////Services.AddSingleton<IDBService, DBServiceBase>();
        ////Services.AddSingleton<IRepositoryService, RepositoryService>(DBService);
        ////Services.AddSingleton<IDialogService, DialogService>();
        ////Services.AddSingleton<IOpenUrlService, OpenUrlService>();
        ////Services.AddSingleton<IRequestProvider, RequestProvider>();
        ////Services.AddSingleton<IIdentityService, IdentityService>();
        ////Services.AddSingleton<IFixUriService, FixUriService>();
        ////Services.AddSingleton<ILocationService, LocationService>();

        ////Services.AddSingleton<ITheme, Theme>();

        Services.AddSingleton<IAppEnvironmentService, AppEnvironmentService>(serviceProvider =>
        {
            ISettingsService settingsService = serviceProvider.GetService<ISettingsService>();
            IRepositorySQL RepositorySQL = serviceProvider.GetService<IRepositorySQL>();

            AppEnvironmentService aes = new(new InstallServices(RepositorySQL, settingsService), new InstallServicesMock(settingsService));
            //            new LoginServices(RepositorySQL, settingsService), new LoginServicesMock(settingsService),
            //            new HomeServices(RepositorySQL, settingsService), new HomeServicesMock(settingsService),
            //            new PizarraServices(RepositorySQL, settingsService), new PizarraServicesMock(settingsService),
            //            new MenuServices(RepositorySQL, settingsService), new MenuServicesMock(settingsService),
            //            new PanelServices(RepositorySQL, settingsService), new PanelServicesMock(settingsService));

            settingsService.UseMocks = esMock;
            aes.UpdateDependencies(settingsService.UseMocks);
            return aes;
        });

        return Services;
    }

    private static void RegisterRoutes(IViewRegistry views, IRouteRegistry routes)
    {
        ////(ViewModel: typeof(ShellViewModel)),
        views.Register(new ViewMap(ViewModel: typeof(ShellViewModel)) //,
        //    new ViewMap<InstallPage, InstallViewModel>(),
        //    new ViewMap<LoginPage, LoginViewModel>(),
        //    new ViewMap<HomePage, HomeViewModel>(),
        //    new ViewMap<PizarraPage, PizarraViewModel>(Data: new DataMap(typeof(List<ParameterClass>)), ResultData: typeof(string)),
        //    new ViewMap<MenuPage, MenuViewModel>(Data: new DataMap(typeof(List<Menu>)))
        );

        routes.Register(
            new RouteMap("Shell", View: views.FindByViewModel<ShellViewModel>()) //,
        //    new RouteMap("Login", View: views.FindByViewModel<LoginViewModel>(),
        //        Nested: new RouteMap[]
        //        {
        //            new RouteMap("Install", View: views.FindByViewModel<InstallViewModel>()),
        //        }
        //    ),
        //    new RouteMap("Home", View: views.FindByViewModel<HomeViewModel>()),
        //    new RouteMap("Pizarra", View: views.FindByViewModel<PizarraViewModel>()),
        //    new RouteMap("Menu", View: views.FindByViewModel<MenuViewModel>())
        );
    }

}

