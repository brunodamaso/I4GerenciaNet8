using I4Kernel.Extensions;
using I4Kernel.Services.Validations;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace I4Kernel.Components;

public sealed partial class EntryView : UserControl
{
    private ResourceDictionary AppResources => Application.Current.Resources;

    #region Propiedades

    #region HasBorder Property

    public static readonly DependencyProperty HasBorderProperty = DependencyProperty.Register(nameof(HasBorder), typeof(bool), typeof(EntryView), new PropertyMetadata(false, (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));

    public bool HasBorder
    {
        get
        {
            return (bool)this.GetValue(HasBorderProperty);
        }

        set
        {
            base.SetValue(HasBorderProperty, value);
        }
    }

    #endregion

    #region Obligado Property

    public static readonly DependencyProperty ObligadoProperty = DependencyProperty.Register(nameof(Obligado), typeof(bool), typeof(EntryView), new PropertyMetadata(false, (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));

    public bool Obligado
    {
        get
        {
            return (bool)this.GetValue(ObligadoProperty);
        }

        set
        {
            base.SetValue(ObligadoProperty, value);
        }
    }

    #endregion

    #region HasTitle Property

    public static readonly DependencyProperty HasTitleProperty = DependencyProperty.Register(nameof(HasTitle), typeof(bool), typeof(EntryView), new PropertyMetadata(false, (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));

    public bool HasTitle
    {
        get
        {
            return (bool)GetValue(HasTitleProperty);
        }

        set
        {
            SetValue(HasTitleProperty, value);
        }
    }

    #endregion

    ////#region IsFocused Property

    ////public static new readonly DependencyProperty IsFocusedProperty = DependencyProperty.Register(nameof(IsFocused), typeof(bool), typeof(EntryView),  new PropertyMetadata(false, (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e))); 

    ////public new bool IsFocused
    ////{
    ////    get => (bool)this.GetValue(IsFocusedProperty);
    ////    set => base.SetValue(IsFocusedProperty, value);
    ////}

    ////#endregion

    //#region TextTransform Property

    //public static readonly DependencyProperty TextTransformProperty = DependencyProperty.Register(nameof(TextTransform), typeof(TextTransform), typeof(EntryView), TextTransform.Default, BindingMode.OneWay);

    //public TextTransform TextTransform
    //{
    //    get => this.GetValue<TextTransform>(TextTransformProperty);
    //    set => base.SetValue(TextTransformProperty, value);
    //}

    //#endregion

    #region SelectOnEntry Property

    public static readonly DependencyProperty SelectOnEntryProperty = DependencyProperty.Register(nameof(SelectOnEntry), typeof(bool), typeof(EntryView), new PropertyMetadata(false, (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));

    public bool SelectOnEntry
    {
        get
        {
            return (bool)GetValue(SelectOnEntryProperty);
        }

        set
        {
            SetValue(SelectOnEntryProperty, value);
        }
    }

    #endregion

    #region IsTabStop Property

    public static readonly DependencyProperty IsTabStopyProperty = DependencyProperty.Register(nameof(IsTabStop), typeof(bool), typeof(EntryView), new PropertyMetadata(true, (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));

    public new bool IsTabStop
    {
        get
        {
            return (bool)this.GetValue(IsTabStopyProperty);
        }

        set
        {
            base.SetValue(IsTabStopyProperty, value);
        }
    }

    #endregion

    #region IsReadOnly Property

    public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register(nameof(IsReadOnly), typeof(bool), typeof(EntryView), new PropertyMetadata(false, (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));

    public bool IsReadOnly
    {
        get
        {
            return (bool)this.GetValue(IsReadOnlyProperty);
        }

        set
        {
            base.SetValue(IsReadOnlyProperty, value);
        }
    }

    #endregion

    #region Text Property

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(EntryView), new PropertyMetadata("", (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));

    public string Text
    {
        get
        {
            return (string)this.GetValue(TextProperty);
        }

        set
        {
            SetValue(TextProperty, value);
        }
    }

    #endregion

    //#region IsNumeric Property
    //public static DependencyProperty IsNumericProperty = DependencyProperty.Register(nameof(IsNumeric), typeof(bool), typeof(EntryView),  new PropertyMetadata(false, (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e))); 

    //public bool IsNumeric
    //{
    //    get => (bool)this.GetValue(IsNumericProperty);
    //    set => base.SetValue(IsNumericProperty, value);
    //}
    //#endregion

    #region Placeholder Property

    public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(EntryView), new PropertyMetadata("", (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));

    public string Placeholder
    {
        get
        {
            return (string)this.GetValue(PlaceholderProperty);
        }

        set
        {
            base.SetValue(PlaceholderProperty, value);
        }
    }

    #endregion

    #region ToolTips Property

    public static readonly DependencyProperty ToolTipsProperty = DependencyProperty.Register(nameof(ToolTips), typeof(string), typeof(EntryView), new PropertyMetadata("", (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));

    public string ToolTips
    {
        get
        {
            return (string)this.GetValue(ToolTipsProperty);
        }

        set
        {
            base.SetValue(ToolTipsProperty, value);
        }
    }

    #endregion

    //#region Keyboard Property

    //public static readonly DependencyProperty KeyboardProperty = DependencyProperty.Register(nameof(Keyboard), typeof(Keyboard), typeof(EntryView), Keyboard.Text, BindingMode.TwoWay);

    //public Keyboard Keyboard
    //{
    //    get => this.GetValue<Keyboard>(KeyboardProperty);
    //    set => SetValue(KeyboardProperty, value);
    //}

    //#endregion

    //#region ReturnType Property

    //public static readonly DependencyProperty ReturnTypeProperty = DependencyProperty.Register(nameof(ReturnType), typeof(ReturnType), typeof(EntryView), null, BindingMode.TwoWay);

    //public ReturnType ReturnType
    //{
    //    get => this.GetValue<ReturnType>(ReturnTypeProperty);
    //    set => base.SetValue(ReturnTypeProperty, value);
    //}

    //#endregion

    #region IsPassword Property

    public static readonly DependencyProperty IsPasswordProperty = DependencyProperty.Register(nameof(IsPassword), typeof(bool), typeof(EntryView), new PropertyMetadata(false, (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));

    public bool IsPassword
    {
        get
        {
            return (bool)this.GetValue(IsPasswordProperty);
        }

        set
        {
            base.SetValue(IsPasswordProperty, value);
        }
    }
    #endregion

    #region IsEditBox Property

    public static readonly DependencyProperty IsEditBoxProperty = DependencyProperty.Register(nameof(IsEditBox), typeof(bool), typeof(EntryView), new PropertyMetadata(false, (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));

    public bool IsEditBox
    {
        get
        {
            return (bool)this.GetValue(IsEditBoxProperty);
        }

        set
        {
            base.SetValue(IsEditBoxProperty, value);
        }
    }
    public static readonly DependencyProperty HeightEditBoxProperty = DependencyProperty.Register(nameof(HeightEditBox), typeof(int), typeof(EntryView), new PropertyMetadata(46, (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));

    public int HeightEditBox
    {
        get
        {
            return (int)this.GetValue(HeightEditBoxProperty);
        }

        set
        {
            base.SetValue(HeightEditBoxProperty, value);
        }
    }

    #endregion

    #region FontSize Property

    public new static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(nameof(FontSize), typeof(double), typeof(EntryView),
         new PropertyMetadata((double)Application.Current.Resources.MergedDictionaries.LastOrDefault()["ControlContentThemeFontSize"], (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));

    public new double FontSize
    {
        get
        {
            return (double)this.GetValue(FontSizeProperty);
        }

        set
        {
            base.SetValue(FontSizeProperty, value);
        }
    }
    #endregion

    #region Background Property
    //new PropertyMetadata(Application.Current.Theme == ApplicationTheme.Light? (Color) Application.Current.Resources.MergedDictionaries.FirstOrDefault()["TextFillColorPrimary"] : (Color) Application.Current.Resources.MergedDictionaries.FirstOrDefault()["DarkBackForeground"],

    public static new readonly DependencyProperty BackgroundProperty = DependencyProperty.Register(nameof(Background), typeof(SolidColorBrush), typeof(EntryView),
         new PropertyMetadata((SolidColorBrush)Application.Current.Resources.MergedDictionaries.FirstOrDefault()["TextBoxBackgroundThemeBrush"],
        (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));

    public new SolidColorBrush Background
    {
        get
        {
            return (SolidColorBrush)this.GetValue(BackgroundProperty);
        }

        set
        {
            base.SetValue(BackgroundProperty, value);
        }
    }
    #endregion

    #region Foreground Property

    public new static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register(nameof(Foreground), typeof(SolidColorBrush), typeof(EntryView),
        new PropertyMetadata((SolidColorBrush)Application.Current.Resources.MergedDictionaries.FirstOrDefault()["CupertinoLabelBrush"],
        (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));


    public new SolidColorBrush Foreground
    {
        get
        {
            return (SolidColorBrush)this.GetValue(ForegroundProperty);
        }

        set
        {
            base.SetValue(ForegroundProperty, value);
        }
    }
    #endregion

    ////#region CanDecimal Property

    ////public static readonly DependencyProperty CanDecimalProperty = DependencyProperty.Register(nameof(CanDecimal), typeof(bool), typeof(EntryView), false, BindingMode.OneWay);

    ////public bool CanDecimal
    ////{
    ////    get => (bool)this.GetValue(CanDecimalProperty);
    ////    set => SetValue(CanDecimalProperty, value);
    ////}
    ////#endregion

    //#region ReturnCommand Property

    //public static readonly DependencyProperty ReturnCommandProperty = DependencyProperty.Register(nameof(ReturnCommand), typeof(ICommand), typeof(EntryView), null, BindingMode.OneWay);

    //public ICommand ReturnCommand
    //{
    //    get => this.GetValue<ICommand>(ReturnCommandProperty);
    //    set => base.SetValue(ReturnCommandProperty, value);
    //}

    //#endregion      

    ////#region ImageStyle Property

    ////public static readonly DependencyProperty ImageStyleProperty = DependencyProperty.Register(nameof(ImageStyle), typeof(Style), typeof(EntryView), null, BindingMode.OneWay);

    ////public Style ImageStyle
    ////{
    ////    get => this.GetValue<Style>(ImageStyleProperty);
    ////    set => base.SetValue(ImageStyleProperty, value);
    ////}

    ////#endregion

    #region IsValid Property

    public static readonly DependencyProperty IsValidProperty = DependencyProperty.Register(nameof(IsValid), typeof(bool), typeof(EntryView), new PropertyMetadata(true, (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));

    public bool IsValid
    {
        get
        {
            return (bool)this.GetValue(IsValidProperty);
        }

        set
        {
            SetValue(IsValidProperty, value);
        }
    }

    #endregion

    #region ValidaTable Property

    public static readonly DependencyProperty ValidaTableProperty = DependencyProperty.Register(nameof(ValidaTable), typeof(ValidatableObject), typeof(EntryView), new PropertyMetadata(true, (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));

    public ValidatableObject? ValidaTable
    {
        get
        {
            if (this.GetValue(ValidaTableProperty) is ValidatableObject validatable)
            {
                return (ValidatableObject)this.GetValue(ValidaTableProperty);
            }
            else
            {
                return null;
            }
        }
        set
        {
            SetValue(ValidaTableProperty, value);
        }
    }

    #endregion

    #region ErrorText Property

    public static readonly DependencyProperty ErrorTextProperty = DependencyProperty.Register(nameof(ErrorText), typeof(string), typeof(EntryView), new PropertyMetadata("", (s, e) => ((EntryView)s)?.OnMyPropertyChanged(e)));

    public string ErrorText
    {
        get
        {
            var value = (string)this.GetValue(ErrorTextProperty);
            if (!value.IsNullOrEmpty())
            {
                value = value?.Substring(value.IndexOf(": ") + 2);
            }
            return value;
        }
        set =>SetValue(ErrorTextProperty, value);
    }

    #endregion
  
    #endregion

    public EntryView()
    {
        AppResources.AddIfNotExist<EntryViewStyles>(EntryViewStyles.Key);
        InitializeComponent();
    }
    private void OnMyPropertyDataChanged(DependencyPropertyChangedEventArgs e)
    {
    }

    private void OnMyPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        
        EntryView entryView = this;
        entryView.Bindings.Update();

        if (entryView.HasTitle)
        {
            //entryView.PlaceholderElement.IsVisible = false;
            entryView.ColumnTitle.Width = new GridLength(120);
            entryView.Titulo.Text = string.Concat(entryView.Placeholder, entryView.Obligado ? "*" : "", ":");
        }
        else
        {
            entryView.ColumnTitle.Width = new GridLength(0);
            //entryView.PlaceholderElement.IsVisible = entryView.HasBorder;
        }
        entryView.HeightEditBox = IsEditBox ? 120 : entryView.HeightEditBox;

        SetStyle(entryView, "Normal");
    }


    private static void SetStyle(EntryView entryView, string style)
    {
        ResourceDictionary resources = Application.Current.Resources;
        if (entryView.IsReadOnly)
        {
            style = "Disabled";
            VisualStateManager.GoToState(entryView, "Disabled", false);
        }
       
        if (entryView.IsPassword)
        {
            entryView.EntryElement.Visibility = Visibility.Collapsed;
            entryView.EntryPassword.Visibility = Visibility.Visible;
        }

        entryView.Titulo.Style = (Style)resources[$"EntryView.Titulo.{style}"];
    }

    private void EntryElement_GotFocus(object sender, RoutedEventArgs e)
    {
        EntryView entryView = (EntryView)this;
        if (entryView.IsReadOnly)
        {
            SetStyle(entryView, "Disabled");
        }
        else
        {
            if (SelectOnEntry)
            {
                if (entryView.IsPassword)
                {
                    PasswordBox _entry = (PasswordBox)sender;
                    _entry.SelectAll();
                }
                else
                {
                    TextBox _entry = (TextBox)sender;
                    _entry.SelectAll();
                }
            }
            SetStyle(entryView, "Focused");
        }
    }

    private void EntryElement_LostFocus(object sender, RoutedEventArgs e)
    {
        //    if (this.IsNumeric && this.CanDecimal)
        //    {
        //        double _;
        //        if (!double.TryParse(((TextBlock)sender).Text, NumberStyles.Number, formatProvider, out _))
        //        {
        //            _ = 0;
        //        }
        //        ((TextBlock)sender).Text = _.ToString("N2", formatProvider);
        //    }
        EntryView entryView = (EntryView)this;
        SetStyle(entryView, "Normal");

        entryView.Text = entryView.EntryElement.Text;
        ValidaTable = ValidaTable?.Validate();
    }
}

public partial class EntryViewStyles : ResourceDictionary
{
    public static string Key
    {
        get
        {
            return nameof(EntryViewStyles);
        }
    }

    public EntryViewStyles()
    {
        InitializeComponent();
    }
}
