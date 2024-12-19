using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace FlowOfReason.UI.Services;

public interface IInteractionsService
{
    void StartCreateGraphDialog();
    IObservable<int> CreateGraphDialogStart { get; }
    
}

public class InteractionsService : IInteractionsService
{
    private readonly Subject<int> _backingCreateGraphDialogStart = new();

    public InteractionsService()
    {
        CreateGraphDialogStart = _backingCreateGraphDialogStart.AsObservable();
    }
    
    public void StartCreateGraphDialog()
    {
        _backingCreateGraphDialogStart.OnNext(0);
    }

    public IObservable<int> CreateGraphDialogStart { get; }
}