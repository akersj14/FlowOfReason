using System.Reactive.Disposables;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using CommunityToolkit.Mvvm.DependencyInjection;
using FlowOfReason.UI.ViewModels;
using ReactiveUI;

namespace FlowOfReason.UI.Views;

public partial class UserAccountPage : ReactiveUserControl<UserAccountPageViewModel>
{
    public UserAccountPage()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetService<UserAccountPageViewModel>();
        this.WhenActivated(disposables =>
        {
            this.BindCommand(ViewModel, 
                vm => vm.SaveChanges, 
                v => v.SaveAccountDetailsButton)
                .DisposeWith(disposables);
        });
    }
}