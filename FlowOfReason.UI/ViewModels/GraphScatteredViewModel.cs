using System;
using System.Reactive.Disposables;
using FlowOfReason.Core.DataBases;
using FlowOfReason.UI.Services;
using ReactiveUI;

namespace FlowOfReason.UI.ViewModels;

public class GraphScatteredViewModel : ViewModelBase
{
    private readonly ILogicGraphDataBase _logicGraphDatabase;
    private readonly IContextController _contextController;
    private readonly string _activeGraphId;
    private readonly ILogicGraphNodeDataBase _nodeDatabase;

    public GraphScatteredViewModel(ILogicGraphDataBase graphDataBase, ILogicGraphNodeDataBase nodeDataBase, IContextController contextController)
    {
        _logicGraphDatabase = graphDataBase ?? throw new ArgumentNullException(nameof(graphDataBase));
        _contextController = contextController ?? throw new ArgumentNullException(nameof(contextController));
        _nodeDatabase = nodeDataBase ?? throw new ArgumentNullException(nameof(nodeDataBase));
        
        _contextController.ActiveGraphId
            .ToProperty(this, x => x._activeGraphId);
        
    }
    
}