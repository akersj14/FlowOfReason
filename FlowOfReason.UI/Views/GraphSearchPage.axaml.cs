using System.Reactive.Disposables;
using Avalonia.ReactiveUI;
using CommunityToolkit.Mvvm.DependencyInjection;
using FlowOfReason.UI.ViewModels;
using ReactiveUI;

namespace FlowOfReason.UI.Views;

public partial class GraphSearchPage : ReactiveUserControl<GraphSearchPageViewModel>
{
    public GraphSearchPage()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetService<GraphSearchPageViewModel>();
        
        this.WhenActivated(disposables =>
        {
            
            this.Bind(ViewModel, vm => vm.SearchText, v => v.SearchBox.Text)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, vm => vm.GraphSearchResults, v => v.GraphsListBox.ItemsSource)
                .DisposeWith(disposables);
            // this.OneWayBind(ViewModel, vm => vm.NodesResults, v => v.NodesListBox.ItemsSource)
            //     .DisposeWith(disposables);
        });
    }
}