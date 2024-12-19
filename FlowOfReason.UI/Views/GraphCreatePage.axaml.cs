using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using CommunityToolkit.Mvvm.DependencyInjection;
using FlowOfReason.UI.ViewModels;

namespace FlowOfReason.UI.Views;

public partial class GraphCreatePage : ReactiveUserControl<GraphCreatePageViewModel>
{
    public GraphCreatePage()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetService<GraphCreatePageViewModel>();
    }
}