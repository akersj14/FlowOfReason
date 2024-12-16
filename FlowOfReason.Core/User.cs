namespace FlowOfReason.Core;

public class User : TrackableData
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public List<string> PinnedLogicGraphs { get; set; } = new();
    public List<string> OwnedLogicGraphs { get; set; } = new();
    public List<string> WatchedLogicGraphNodes { get; set; } = new();
    public List<string> DraftLogicGraphNodes { get; set; } = new();
    public List<string> DraftLeadComments { get; set; } = new();
    public List<string> DraftDiscussionComments { get; set; } = new();
}