using System.Collections.Generic;
using System.Collections.ObjectModel;
using FlowOfReason.Core;
using FlowOfReason.Core.DataModels;
using ReactiveUI;

namespace FlowOfReason.UI.ViewModels;

public partial class ExistingNodePageViewModel : ViewModelBase
{
    private string _backingClaim = "God is Good";
    private string _backingExplanation = "This is a really long reason on why we don't let developers write static values";

    public string Claim
    {
        get => _backingClaim;
        set => this.RaiseAndSetIfChanged(ref _backingClaim, value);
    }

    public string Explanation
    {
        get => _backingExplanation;
        set => this.RaiseAndSetIfChanged(ref _backingExplanation, value);
    }

    public List<LeadComment> Challenges { get; } = new();
    public List<DiscussionComment> Discussions { get; } = new();
}