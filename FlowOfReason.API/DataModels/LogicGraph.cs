namespace FlowOfReason.API.DataModels;

public class LogicGraph : IIdentifiableData
{
    public List<string> NodesIds { get; set; } = new();
    public string Id { get; set; }
}