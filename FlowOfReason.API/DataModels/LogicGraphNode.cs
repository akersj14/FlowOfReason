namespace FlowOfReason.API.DataModels;

public class LogicGraphNode : IIdentifiableData
{
    public string Id { get; set; }
    public string OwningLogicGraphId { get; set; }
    public string Argument { get; set; }
    public string Explanation { get; set; }
    public List<string> LeadCommentIds { get; set; } = new();
    public List<string> RelationshipIds { get; set; } = new();
}