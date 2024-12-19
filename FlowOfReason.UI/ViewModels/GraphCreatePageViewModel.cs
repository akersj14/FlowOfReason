using System.Collections.Generic;

namespace FlowOfReason.UI.ViewModels;

public class GraphCreatePageViewModel : ViewModelBase
{

    public string? GraphName { get; } = string.Empty;
    public List<string> NodeTypes { get; } = new();
    public List<string> RelationshipTypes { get; } = new();
    public List<string> CommentTypes { get; } = new();
}