using System.Reactive.Disposables;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
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
                    vm => vm.RelationshipTypes, 
                    v => v.RelationshipTypesListBox.ItemsSource)
                .DisposeWith(disposables);
            this.Bind(ViewModel, 
                    vm => vm.NodeTypes, 
                    v => v.NodeTypesListBox.ItemsSource)
                .DisposeWith(disposables);
            this.Bind(ViewModel, 
                    vm => vm.CommentTypes, 
                    v => v.CommentTypesListBox.ItemsSource)
                .DisposeWith(disposables);
            
            this.BindCommand(ViewModel,
                vm => vm.AddNodeType,
                v => v.AddNodeTypeButton)
                .DisposeWith(disposables);
            this.BindCommand(ViewModel,
                vm => vm.AddRelationshipType,
                v => v.AddRelationshipTypeButton)
                .DisposeWith(disposables);
            this.BindCommand(ViewModel,
                vm => vm.AddCommentType,
                v => v.AddCommentTypeButton)
                .DisposeWith(disposables);
            this.BindCommand(ViewModel, vm => vm.SaveGraph)
        });
    }
}