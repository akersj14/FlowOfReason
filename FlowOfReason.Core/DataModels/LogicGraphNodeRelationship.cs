namespace FlowOfReason.Core.DataModels;

public class LogicGraphNodeRelationship : TrackableData
{
    public string SourceNodeId { get; set; }
    public string TargetNodeId { get; set; }
    public string Type { get; set; } = "Related";
}