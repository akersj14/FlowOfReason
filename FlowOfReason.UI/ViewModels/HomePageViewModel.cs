using System.Reactive;
using FlowOfReason.UI.Services;
using ReactiveUI;

namespace FlowOfReason.UI.ViewModels;

public class HomePageViewModel(IInteractionsService interactionsService) : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> CreateNewGraph { get; set; } = ReactiveCommand.Create(interactionsService.StartCreateGraphDialog);

}