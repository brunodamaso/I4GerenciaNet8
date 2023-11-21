using I4Gerencia.ViewModels;
using I4Kernel.ViewModels.Base;
using I4Kernel.Services;

namespace I4Gerencia.Views;

public partial class PageBase : Page, IRecipient<Imessage>
{
   
    public PageBase()
    {
        DataContextChanged += VMPage_DataContextChanged;
    }

    private async void VMPage_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
    {
        if (args.NewValue is IViewModelBase ivmb)
        {
            await ivmb.InitializeAsyncCommand.ExecuteAsync(null);
        }
    }

    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        base.OnNavigatingFrom(e);
    }
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        base.OnNavigatedFrom(e);
    }

    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);     
    }
    public virtual async void Receive(Imessage message)
    {
        if (message.Value.ToString() == "Close")
        {
            //this.Close();
        }
      
    }
}
