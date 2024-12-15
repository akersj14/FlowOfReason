namespace FlowOfReason.API.DataModels;

public class LogicGraphNodeRelationship : IIdentifiableData
{
    public string Id { get; set; }
    public string SourceNodeId { get; set; }
    public string TargetNodeId { get; set; }
    public string Type { get; set; } = "Related";
}