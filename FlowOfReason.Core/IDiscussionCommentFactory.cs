namespace FlowOfReason.Core;

public interface IDiscussionCommentFactory
{
    DiscussionComment CreateDiscussionComment(string ownerId, string owningLeadCommentId);
}

public class DiscussionCommentFactory : IDiscussionCommentFactory
{
    public DiscussionComment CreateDiscussionComment(string ownerId, string owningLeadCommentId)
    {
        return new DiscussionComment
        {
            OwnerId = ownerId,
            OwningLeadCommentId = owningLeadCommentId,
        };
    }
}