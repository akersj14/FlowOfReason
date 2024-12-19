using FlowOfReason.Core.DataModels;

namespace FlowOfReason.Core.Factories;

public interface ILeadCommentFactory
{
    LeadComment CreateLeadComment(string ownerId, string owningNodeId);
}

public class LeadCommentFactory : ILeadCommentFactory
{
    public LeadComment CreateLeadComment(string ownerId, string owningNodeId)
    {
        return new LeadComment
        {
            OwnerId = ownerId,
            OwningLogicGraphNodeId = owningNodeId
        };
    }
}