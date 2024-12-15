namespace FlowOfReason.API.DataModels;

public class DiscussionComment : IIdentifiableData
{
    public string Id { get; set; }
    public string OwnerId { get; set; }
    public string OwningLeadCommentId { get; set; }
    public string Text { get; set; }
}