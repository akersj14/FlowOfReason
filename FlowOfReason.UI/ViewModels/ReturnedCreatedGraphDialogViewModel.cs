using System;
using FlowOfReason.Core.DataModels;
using FlowOfReason.Core.Factories;

namespace FlowOfReason.UI.ViewModels;

public class ReturnedCreatedGraphDialogViewModel : ViewModelBase
{
    private readonly ILogicGraphFactory _logicGraphFactory;

    public ReturnedCreatedGraphDialogViewModel(ILogicGraphFactory logicGraphFactory)
    {
        _logicGraphFactory = logicGraphFactory ?? throw new ArgumentNullException(nameof(logicGraphFactory));
    }
    public LogicGraph LogicGraph { get; set; }
}