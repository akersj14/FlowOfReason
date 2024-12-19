using System.Reactive.Disposables;
using Avalonia.ReactiveUI;
using CommunityToolkit.Mvvm.DependencyInjection;
using FlowOfReason.UI.ViewModels;
using ReactiveUI;

namespace FlowOfReason.UI.Views;

public partial class GraphSearchGraphResultItemTemplate : ReactiveUserControl<GraphSearchGraphResultItemTemplateViewModel>
{
    public GraphSearchGraphResultItemTemplate()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetService<GraphSearchGraphResultItemTemplateViewModel>();

        this.WhenActivated(disposables =>
        {
            this.OneWayBind(ViewModel, vm => vm.GraphName, v => v.GraphNameTextBlock.Text)
                .DisposeWith(disposables);
            this.BindCommand(ViewModel, vm => vm.OpenGraphCommand, v => v.GoToGraphButton)
                .DisposeWith(disposables);
        });
    }

}