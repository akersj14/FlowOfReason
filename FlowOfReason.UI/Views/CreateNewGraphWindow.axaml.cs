using System;
using System.Reactive.Disposables;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using CommunityToolkit.Mvvm.DependencyInjection;
using FlowOfReason.UI.ViewModels;
using ReactiveUI;

namespace FlowOfReason.UI.Views;

public partial class CreateNewGraphWindow : ReactiveWindow<CreateNewGraphWindowViewModel>
{
    public CreateNewGraphWindow()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetService<CreateNewGraphWindowViewModel>();

        this.WhenActivated(disposables =>
        {
            
            this.Bind(ViewModel, 
                    vm => vm.GraphName, 
                    v => v.GraphNameTextBox.Text)
                .DisposeWith(disposables);
            this.Bind(ViewModel, 
                    vm => vm.NodeTypesText, 
                    v => v.NodeTypesTextBox.Text)
                .DisposeWith(disposables);
            this.Bind(ViewModel, 
                    vm => vm.RelationshipTypesText, 
                    v => v.RelationshipTypesTextBox.Text)
                .DisposeWith(disposables);
            this.Bind(ViewModel, 
                    vm => vm.CommentTypesText, 
                    v => v.CommentTypesTextBox.Text)
                .DisposeWith(disposables);
        });
    }
    private void CancelButtonClicked(object sender, RoutedEventArgs e)
    {
        Close("Cancel Clicked!");
    }
    private void SaveButtonClicked(object sender, RoutedEventArgs e)
    {
        ViewModel.SaveGraph.Execute();
        Close("Save Clicked!");
    }
    
}