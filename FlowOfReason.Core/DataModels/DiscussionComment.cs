namespace FlowOfReason.Core.DataModels;

public class DiscussionComment : TrackableData
{
    public string OwnerId { get; set; }
    public string OwningLeadCommentId { get; set; }
    public string Text { get; set; }
}