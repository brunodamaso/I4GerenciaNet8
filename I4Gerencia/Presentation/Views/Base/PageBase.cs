using I4Gerencia.Presentation.ViewModels;
using I4Kernel.ViewModels.Base;
using I4Kernel.Services;

namespace I4Gerencia.Presentation.Views;

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


    public virtual async void Receive(Imessage message)
    {
        if (message.Value.ToString() == "Close")
        {
            ////this.Close();
        }
      
    }
}
