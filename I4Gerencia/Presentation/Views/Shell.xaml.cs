using I4Kernel.Common;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Uno.Toolkit.UI;
using Windows.UI;

namespace I4Gerencia.Presentation.Views;

public sealed partial class Shell : UserControl, IContentControlProvider
{
    public ContentControl ContentControl => Splash;
    public ExtendedSplashScreen SplashScreen => Splash;

    public Shell()
    {
        this.InitializeComponent();

        ToggleFullscreen(false);
    }


    private async Task ToggleFullscreen(bool fullscreen)
    {
#if WINDOWS
        if (App.MainWindow != null)
        {
            GetAppWindow _GetAppWindow = new(App.MainWindow);
            await _GetAppWindow.ToggleFullscreen(fullscreen);
        }
#endif
    }
    
}
