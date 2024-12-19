using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Windows.Input;
using FlowOfReason.Core.DataBases;
using FlowOfReason.Core.Factories;
using FlowOfReason.UI.Services;
using ReactiveUI;

namespace FlowOfReason.UI.ViewModels;

public class CreateNewGraphWindowViewModel : ViewModelBase
{
    public CreateNewGraphWindowViewModel(ILogicGraphFactory graphFactory, ILogicGraphDataBase logicGraphDataBase, IUserAccountService userAccountService)
    {
        var graph = graphFactory.CreateLogicGraph();
        SaveGraph = ReactiveCommand.CreateFromTask(async () =>
        {
            if (string.IsNullOrEmpty(GraphName))
            {
                Debug.WriteLine("Tried to save a graph without a name.");
                return;
            }
            graph.Name = GraphName;
            graph.NodeTypes = NodeTypesText.Split(',').Where(i => !string.IsNullOrEmpty(i)).ToList();
            graph.CommentTypes = CommentTypesText.Split(',').Where(i => !string.IsNullOrEmpty(i)).ToList();
            graph.RelationshipTypes = RelationshipTypesText.Split(',').Where(i => !string.IsNullOrEmpty(i)).ToList();
            await logicGraphDataBase.AddAsync(graph);
            var currentUser = userAccountService.GetCurrentUser();
            currentUser.OwnedLogicGraphs.Add(graph.Id);
            userAccountService.UpdateUser(currentUser);
        });
    }

    public string GraphName { get; set; } = "Enter Graph Name Here";
    public ReactiveCommand<Unit, Unit> SaveGraph { get; set; }
    public string NodeTypesText { get; set; } = string.Empty;
    public string RelationshipTypesText { get; set; } = string.Empty;
    public string CommentTypesText { get; set; } = string.Empty;
}