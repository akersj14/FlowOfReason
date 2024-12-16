using FlowOfReason.Core;

namespace FlowOfReason.API.Controllers;

public interface ILogicGraphNodeController
{
    
    public string AddLogicGraphNode(string graphId);
    public string RemoveLogicGraphNode(string nodeId);
    public LogicGraphNode? GetLogicGraphNode(string nodeId);
    public List<string> GetAllLogicGraphNodeIds();
    public string UpdateLogicGraphNode(LogicGraphNode graphNode);
}

public class LogicGraphNodeController(ILogicGraphNodeFactory logicGraphNodeFactory) : ILogicGraphNodeController
{
    private readonly List<LogicGraphNode> _logicGraphNodes = new();

    private readonly ILogicGraphNodeFactory _logicGraphNodeFactory =
        logicGraphNodeFactory ?? throw new ArgumentNullException(nameof(logicGraphNodeFactory));
    
    public string AddLogicGraphNode(string graphId)
    {
        var node = _logicGraphNodeFactory.CreateLogicGraphNode(graphId);
        _logicGraphNodes.Add(node);
        Console.WriteLine($"Node added: {node.Id}");
        return node.Id;
    }

    public string RemoveLogicGraphNode(string nodeId)
    {
        var nodeMatch = _logicGraphNodes.Find(g => g.Id == nodeId);
        if (nodeMatch == null)
        {
            Console.WriteLine($"Node not found: {nodeId}");
            return string.Empty;
        }

        _logicGraphNodes.Remove(nodeMatch);
        Console.WriteLine($"Node removed: {nodeId}");
        return nodeMatch.Id;
    }

    public LogicGraphNode? GetLogicGraphNode(string nodeId)
    {
        var nodeMatch = _logicGraphNodes.Find(g => g.Id == nodeId);
        Console.WriteLine($"Node retrieved: {nodeId}");
        return nodeMatch;
    }

    public List<string> GetAllLogicGraphNodeIds()
    {
        var ids = _logicGraphNodes.Select(n => n.Id).ToList();
        Console.WriteLine($"All nodes returned: [{string.Join(',', ids)}]");
        return ids;
    }

    public string UpdateLogicGraphNode(LogicGraphNode graphNode)
    {
        var firstIndex = _logicGraphNodes.FindIndex(n => n.Id == graphNode.Id && n.OwningLogicGraphId == graphNode.OwningLogicGraphId);
        if (firstIndex == -1)
        {
            Console.WriteLine($"Node not found: {graphNode.Id}");
            return "";
        }
        _logicGraphNodes[firstIndex] = graphNode;
        Console.WriteLine($"Node Updated: {graphNode.Id}");
        return graphNode.Id;
    }
}