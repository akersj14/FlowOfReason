using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using ReactiveUI;
using SQLitePCL;

namespace FlowOfReason.UI.Services;

public interface IContextController
{
    void OpenGraphById(string logicGraphId);
    IObservable<string> ActiveGraphId { get; }
}

public class ContextController : ReactiveObject, IContextController
{
    private readonly Subject<string> _activeGraphId = new();

    public ContextController()
    {
        ActiveGraphId = _activeGraphId.AsObservable();
    }
    
    public void OpenGraphById(string logicGraphId)
    {
        _activeGraphId.OnNext(logicGraphId);
    }

    public IObservable<string> ActiveGraphId { get; }
}