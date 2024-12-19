using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace FlowOfReason.UI.Services;

public interface IInteractionsService
{
    void StartCreateGraphDialog();
    IObservable<int> CreateGraphDialogStart { get; }
    
    void StopCreateGraphDialog();
    IObservable<int> CreateGraphDialogStop { get; }
}

public class InteractionsService : IInteractionsService
{
    private readonly Subject<int> _backingCreateGraphDialogStart = new();
    private readonly Subject<int> _backingCreateGraphDialogStop = new();

    public InteractionsService()
    {
        CreateGraphDialogStart = _backingCreateGraphDialogStart.AsObservable();
        CreateGraphDialogStop = _backingCreateGraphDialogStop.AsObservable();
    }
    
    public void StartCreateGraphDialog()
    {
        _backingCreateGraphDialogStart.OnNext(0);
    }

    public IObservable<int> CreateGraphDialogStart { get; }
    public void StopCreateGraphDialog()
    {
        _backingCreateGraphDialogStop.OnNext(0);
    }

    public IObservable<int> CreateGraphDialogStop { get; }
}