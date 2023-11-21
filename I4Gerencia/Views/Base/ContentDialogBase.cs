using I4Kernel.ViewModels.Base;

namespace I4Gerencia.Views;

public partial class ContentDialogBase : ContentDialog, IRecipient<Imessage>
{
    public IViewModelBase ViewModel { get; set; }
    public ContentDialogBase()
    {
        DataContextChanged += VMPage_DataContextChanged;

    }

    private async void VMPage_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
    {
        if (args.NewValue is IViewModelBase ivmb)
        {
            await ivmb.InitializeAsyncCommand.ExecuteAsync(null);
            ViewModel = args.NewValue as IViewModelBase;
        }
    }
    public virtual void Receive(Imessage message)
    {
        if (message.Value.ToString() == "Close")
        {
            //this.Close();
        }

    }
}