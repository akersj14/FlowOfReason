using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FlowOfReason.UI.ViewModels;

namespace FlowOfReason.UI.Views;

public partial class ExistingNodePage : UserControl
{
    public ExistingNodePage()
    {
        InitializeComponent();
        DataContext = new ExistingNodePageViewModel();
    }
}