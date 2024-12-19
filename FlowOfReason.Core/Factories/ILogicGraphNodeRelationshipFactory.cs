using FlowOfReason.Core.DataModels;

namespace FlowOfReason.Core.Factories;

public interface ILogicGraphNodeRelationshipFactory
{
    public LogicGraphNodeRelationship Create(string sourceNodeId, string targetNodeId, string relationshipType);
}

public class LogicGraphNodeRelationshipFactory : ILogicGraphNodeRelationshipFactory
{
    public LogicGraphNodeRelationship Create(string sourceNodeId, string targetNodeId, string relationshipType)
    {
        return new LogicGraphNodeRelationship
        {
            SourceNodeId = sourceNodeId,
            TargetNodeId = targetNodeId,
            Type = relationshipType
        };
    }
}