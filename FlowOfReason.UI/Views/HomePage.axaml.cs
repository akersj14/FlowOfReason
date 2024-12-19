using System.Reactive.Disposables;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using CommunityToolkit.Mvvm.DependencyInjection;
using FlowOfReason.UI.ViewModels;
using ReactiveUI;
using SkiaSharp;

namespace FlowOfReason.UI.Views;

public partial class HomePage : ReactiveUserControl<HomePageViewModel>
{
    public HomePage()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetService<HomePageViewModel>();

        this.WhenActivated(disposables =>
        {
            this.BindCommand(ViewModel, vm => vm.CreateNewGraph,
                v => v.CreateNewGraphButton)
                .DisposeWith(disposables);
        });
    }
    
}