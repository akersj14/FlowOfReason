using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using FlowOfReason.Core.DataBases;
using FlowOfReason.Core.Factories;
using FlowOfReason.UI.Services;
using ReactiveUI;

namespace FlowOfReason.UI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public bool IsGraphViewVisible { get; } = true;

    public MainWindowViewModel(IInteractionsService interactionsService, ILogicGraphFactory logicGraphFactory, ILogicGraphDataBase logicGraphDataBase, IUserAccountService userAccountService)
    {
        
        ShowCreateGraphDialog = new Interaction<CreateNewGraphWindowViewModel, ReturnedCreatedGraphDialogViewModel?>();
        this.WhenActivated(disposable =>
        {
            interactionsService.CreateGraphDialogStart.Do(async i =>
                    {
                        var createGraph = new CreateNewGraphWindowViewModel();
            
                        var result = await ShowCreateGraphDialog.Handle(createGraph);
                        if (result == null)
                        {
                            Debug.WriteLine("Ended Creating Graph Process without Creating Graph.");
                            return;
                        }
            
                        var graph = result.LogicGraph;
                        Debug.Write($"Created new logic graph: {graph.Id}");
            
                        // var graph = logicGraphFactory.CreateLogicGraph();
                        // graph.Name = "New Graph";
                        await logicGraphDataBase.AddAsync(graph);
                        var currentUser = userAccountService.GetCurrentUser();
                        currentUser.OwnedLogicGraphs.Add(graph.Id);
                        userAccountService.UpdateUser(currentUser);
                    }).Subscribe().DisposeWith(disposable);
        });
    }
    
    public Interaction<CreateNewGraphWindowViewModel, ReturnedCreatedGraphDialogViewModel?> ShowCreateGraphDialog { get; }

    
}