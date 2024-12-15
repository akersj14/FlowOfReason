namespace FlowOfReason.API.DataModels;

public class LeadComment : IIdentifiableData
{
    public string Id { get; set; }
    public string OwnerId { get; set; }
    public string OwningLogicGraphNodeId { get; set; }
    public string Text { get; set; } = "";
    public string Type { get; set; } = "False";
    public List<string> DiscussionCommentIds { get; set; } = new();
}