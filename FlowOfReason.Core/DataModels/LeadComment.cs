namespace FlowOfReason.Core.DataModels;

public class LeadComment : TrackableData
{
    public string OwnerId { get; set; }
    public string OwningLogicGraphNodeId { get; set; }
    public string Text { get; set; } = "";
    public string Type { get; set; } = "False";
    public List<string> DiscussionCommentIds { get; set; } = new();
}