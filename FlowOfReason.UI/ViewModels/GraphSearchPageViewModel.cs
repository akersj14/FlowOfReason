using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.DependencyInjection;
using FlowOfReason.Core.DataBases;
using FlowOfReason.Core.DataModels;
using FlowOfReason.UI.Services;
using ReactiveUI;

namespace FlowOfReason.UI.ViewModels;

public class GraphSearchPageViewModel : ViewModelBase
{
    private string _backingSearchText = string.Empty;
    public string SearchText
    {
        get => _backingSearchText;
        set => this.RaiseAndSetIfChanged(ref _backingSearchText, value);
    }

    private readonly ObservableAsPropertyHelper<IEnumerable<GraphSearchGraphResultItemTemplateViewModel>>
        _searchResults;
    public IEnumerable<GraphSearchGraphResultItemTemplateViewModel> GraphSearchResults => _searchResults.Value;
    
    private readonly ObservableAsPropertyHelper<bool> _isAvailable;
    private readonly ISearchingService _searchingService;
    private readonly IContextController _contextController;
    public bool IsAvailable => _isAvailable.Value;

    public GraphSearchPageViewModel(ILogicGraphDataBase logicGraphDataBase, ISearchingService searchingService, IContextController contextController)
    {
        _searchingService = searchingService ?? throw new ArgumentNullException(nameof(searchingService));
        LogicGraphDataBase = logicGraphDataBase ?? throw new ArgumentNullException(nameof(logicGraphDataBase));
        _contextController = contextController ?? throw new ArgumentNullException(nameof(contextController));
        _searchResults = this
            .WhenAnyValue(x => x.SearchText)
            .Throttle(TimeSpan.FromMilliseconds(800))
            .Select(term => term?.Trim())
            .DistinctUntilChanged()
            .Where(term => !string.IsNullOrWhiteSpace(term))
            .SelectMany(SearchGraphs)
            .ObserveOn(RxApp.MainThreadScheduler)
            .ToProperty(this, x => x.GraphSearchResults);
            
        _isAvailable = this
            .WhenAnyValue(x => x.GraphSearchResults)
            .Select(searchResults => searchResults != null)
            .ToProperty(this, x => x.IsAvailable);
    }

    public ILogicGraphDataBase LogicGraphDataBase { get; set; }

    private async Task<IEnumerable<GraphSearchGraphResultItemTemplateViewModel>> SearchGraphs(string text, CancellationToken token)
    {
        var graphResults = await _searchingService
            .SearchGraphs(text);
        return graphResults
            .Select(graph => new GraphSearchGraphResultItemTemplateViewModel(graph, _contextController));
    }
}