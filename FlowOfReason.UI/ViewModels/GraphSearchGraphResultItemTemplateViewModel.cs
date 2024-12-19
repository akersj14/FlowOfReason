using System;
using System.Reactive;
using System.Windows.Input;
using FlowOfReason.Core.DataModels;
using FlowOfReason.UI.Services;
using ReactiveUI;

namespace FlowOfReason.UI.ViewModels;

public class GraphSearchGraphResultItemTemplateViewModel : ViewModelBase
{
    private readonly IContextController _contextController;
    private readonly LogicGraph _logicGraph;
    public string GraphName { get; set; } = "This is a graph";

    public GraphSearchGraphResultItemTemplateViewModel(LogicGraph logicGraph, IContextController contextController)
    {
        _logicGraph = logicGraph ?? throw new ArgumentNullException(nameof(logicGraph));
        _contextController = contextController ?? throw new ArgumentNullException(nameof(contextController));
        
        GraphName = logicGraph.Name;

        OpenGraphCommand = ReactiveCommand.Create(() =>
        {
            _contextController.OpenGraphById(_logicGraph.Id);
        });
    }
    public ReactiveCommand<Unit, Unit> OpenGraphCommand { get; set; }
}