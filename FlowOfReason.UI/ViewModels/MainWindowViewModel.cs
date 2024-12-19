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
        
        ShowCreateGraphDialog = new Interaction<CreateNewGraphWindowViewModel, string?>();
        this.WhenActivated(disposable =>
        {
            interactionsService.CreateGraphDialogStart.Do(async i =>
            {
                var createGraph =
                    new CreateNewGraphWindowViewModel(logicGraphFactory, logicGraphDataBase, userAccountService);

                var result = await ShowCreateGraphDialog.Handle(createGraph);

                Debug.WriteLine($"Dialog Ended with result {result}");
            }).Subscribe().DisposeWith(disposable);
        });
    }
    
    public Interaction<CreateNewGraphWindowViewModel, string?> ShowCreateGraphDialog { get; }

    
}