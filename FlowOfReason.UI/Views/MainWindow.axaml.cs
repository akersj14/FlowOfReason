using System;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using CommunityToolkit.Mvvm.DependencyInjection;
using FlowOfReason.UI.ViewModels;
using ReactiveUI;

namespace FlowOfReason.UI.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetService<MainWindowViewModel>();
        this.WhenActivated(() =>
        {
            var disposables = new CompositeDisposable();
            
            ViewModel!.ShowCreateGraphDialog
                .RegisterHandler(DoShowCreateNewGraphDialogAsync).DisposeWith(disposables);
            
            return disposables;
        });
            
    }
    
    private async Task DoShowCreateNewGraphDialogAsync(IInteractionContext<CreateNewGraphWindowViewModel,
        string?> interaction)
    {
        var dialog = new CreateNewGraphWindow();
        dialog.DataContext = interaction.Input;

        var result = await dialog.ShowDialog<string>(this);
        interaction.SetOutput(result);
    }
}