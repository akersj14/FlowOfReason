namespace FlowOfReason.Core.DataModels;

public class LogicGraphNode : TrackableData
{
    public string OwningLogicGraphId { get; set; }
    public string Argument { get; set; }
    public string Explanation { get; set; }
    public List<string> LeadCommentIds { get; set; } = new();
    public List<string> RelationshipIds { get; set; } = new();
}