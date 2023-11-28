namespace I4Gerencia;

public class App : Application
{
    private static readonly bool esMock = false;
    private ISettingsService settingsService;
    public static Window? MainWindow { get; private set; }
    public IHost? Host { get; private set; }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        var builder = this.CreateBuilder(args)
            // Add navigation support for toolkit controls such as TabBar and NavigationView
            .UseToolkitNavigation()
            .Configure(host => host
#if DEBUG
                // Switch to Development environment when running in DEBUG
                .UseEnvironment(Environments.Development)
#endif
                .UseLogging(configure: (context, logBuilder) =>
                {
                    // Configure log levels for different categories of logging
                    logBuilder
                        .SetMinimumLevel(
                            context.HostingEnvironment.IsDevelopment() ?
                                LogLevel.Information :
                                LogLevel.Warning)

                        // Default filters for core Uno Platform namespaces
                        .CoreLogLevel(LogLevel.Warning);

                    // Uno Platform namespace filter groups
                    // Uncomment individual methods to see more detailed logging
                    //// Generic Xaml events
                    //logBuilder.XamlLogLevel(LogLevel.Debug);
                    //// Layout specific messages
                    //logBuilder.XamlLayoutLogLevel(LogLevel.Debug);
                    //// Storage messages
                    //logBuilder.StorageLogLevel(LogLevel.Debug);
                    //// Binding related messages
                    //logBuilder.XamlBindingLogLevel(LogLevel.Debug);
                    //// Binder memory references tracking
                    //logBuilder.BinderMemoryReferenceLogLevel(LogLevel.Debug);
                    //// DevServer and HotReload related
                    //logBuilder.HotReloadCoreLogLevel(LogLevel.Information);
                    //// Debug JS interop
                    //logBuilder.WebAssemblyLogLevel(LogLevel.Debug);

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
                    RegisterAppServices(services);
                })
                .UseNavigation(RegisterRoutes)
            );
        MainWindow = builder.Window;

#if DEBUG
        MainWindow.EnableHotReload();
#endif

        Host = await builder.NavigateAsync<Shell>();
    }

    private static void RegisterAppServices(IServiceCollection Services)
    {
        ////Services.AddLocalization();

        Services.AddSingleton<ISettingsServiceBase, SettingsServiceBase>();
        Services.AddSingleton<ISettingsService, SettingsService>();
        Services.AddSingleton<IServiceProvider, ServiceProvider>();
        ////Services.AddSingleton<INavigationService, NavigationService>();
        Services.AddSingleton<ISQLService, SQLService>();
        Services.AddSingleton<IRepositorySQL, RepositorySql>();

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
            _ = ApplicationData.Current.LocalSettings;
            ISettingsService settingsService = serviceProvider.GetService<ISettingsService>();
            IRepositorySQL RepositorySql = serviceProvider.GetService<IRepositorySQL>();

            AppEnvironmentService aes = new(new InstallServices(RepositorySql, settingsService), new InstallServicesMock(settingsService));
            //            new LoginServices(RepositorySql, settingsService), new LoginServicesMock(settingsService),
            //            new HomeServices(RepositorySql, settingsService), new HomeServicesMock(settingsService),
            //            new PizarraServices(RepositorySql, settingsService), new PizarraServicesMock(settingsService),
            //            new MenuServices(RepositorySql, settingsService), new MenuServicesMock(settingsService),
            //            new PanelServices(RepositorySql, settingsService), new PanelServicesMock(settingsService));

            settingsService.UseMocks = esMock;
            aes.UpdateDependencies(settingsService.UseMocks);
            return aes;
        });

        //return Services;
    }

    private static void RegisterRoutes(IViewRegistry views, IRouteRegistry routes)
    {
        ////(ViewModel: typeof(ShellViewModel)),
        views.Register(new ViewMap(ViewModel: typeof(ShellViewModel)),
            new ViewMap<InstallPage, InstallViewModel>() //,
        //    new ViewMap<LoginPage, LoginViewModel>(),
        //    new ViewMap<HomePage, HomeViewModel>(),
        //    new ViewMap<PizarraPage, PizarraViewModel>(Data: new DataMap(typeof(List<ParameterClass>)), ResultData: typeof(string)),
        //    new ViewMap<MenuPage, MenuViewModel>(Data: new DataMap(typeof(List<Menu>)))
        );

        routes.Register(
            new RouteMap("Shell", View: views.FindByViewModel<ShellViewModel>()),
                    new RouteMap("Install", View: views.FindByViewModel<InstallViewModel>())//,
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
