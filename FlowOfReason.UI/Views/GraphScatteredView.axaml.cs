using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using CommunityToolkit.Mvvm.DependencyInjection;
using FlowOfReason.UI.ViewModels;
using ReactiveUI;

namespace FlowOfReason.UI.Views;

public partial class GraphScatteredView : ReactiveUserControl<GraphScatteredViewModel>
{
    
    
    public GraphScatteredView()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetService<GraphScatteredViewModel>();
        // this.WhenActivated(disposables =>
        // {
        //     ViewModel.ActiveGraphId
        //         .Do()
        //         .Subscribe()
        //         .DisposeWith(disposables);
        // });
    }
}