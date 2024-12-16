using FlowOfReason.Core;

namespace FlowOfReason.API.Controllers;

public interface ILogicGraphNodeRelationshipController
{
    public string AddRelationship();
    public string RemoveRelationship(string relationshipId);
    public LogicGraphNodeRelationship? GetRelationship(string relationshipId);
    public List<string> GetAllRelationshipIds(string nodeId);
    public string UpdateRelationship(LogicGraphNodeRelationship relationship);
}

public class LogicGraphNodeRelationshipController(ILogicGraphNodeRelationshipFactory logicGraphNodeRelationshipFactory) : ILogicGraphNodeRelationshipController
{
    public string AddRelationship()
    {
        throw new NotImplementedException();
    }

    public string RemoveRelationship(string relationshipId)
    {
        throw new NotImplementedException();
    }

    public LogicGraphNodeRelationship? GetRelationship(string relationshipId)
    {
        throw new NotImplementedException();
    }

    public List<string> GetAllRelationshipIds(string nodeId)
    {
        throw new NotImplementedException();
    }

    public string UpdateRelationship(LogicGraphNodeRelationship relationship)
    {
        throw new NotImplementedException();
    }
}

public interface ILogicGraphNodeRelationshipFactory
{
}