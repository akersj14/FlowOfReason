namespace FlowOfReason.Core;

public class LogicGraph : TrackableData
{
    public List<string> NodeIds { get; set; } = new();
    public string Name { get; set; } = "";
    public List<string> NodeTypes { get; set; } = new();
    public List<string> RelationshipTypes { get; set; } = new();
}