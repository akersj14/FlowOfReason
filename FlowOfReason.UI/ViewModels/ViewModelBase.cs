using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;

namespace FlowOfReason.UI.ViewModels;

public class ViewModelBase : ReactiveObject, IActivatableViewModel
{
    public ViewModelActivator Activator { get; } = new();
}