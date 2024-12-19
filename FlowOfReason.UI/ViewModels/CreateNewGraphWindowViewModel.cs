using System.Collections.Generic;
using ReactiveUI;

namespace FlowOfReason.UI.ViewModels;

public class CreateNewGraphWindowViewModel : ViewModelBase
{

    public string GraphName { get; }
    public List<string> NodeTypes { get; }
    public List<string> RelationshipTypes { get; }
    public List<string> CommentTypes { get; }
}