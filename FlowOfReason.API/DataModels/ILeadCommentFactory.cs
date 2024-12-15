namespace FlowOfReason.API.DataModels;

public interface ILeadCommentFactory
{
    LeadComment CreateLeadComment(string ownerId, string owningNodeId);
}

internal class LeadCommentFactory : ILeadCommentFactory
{
    public LeadComment CreateLeadComment(string ownerId, string owningNodeId)
    {
        return new LeadComment
        {
            Id = Guid.NewGuid().ToString(),
            OwnerId = ownerId,
            OwningLogicGraphNodeId = owningNodeId
        };
    }
}