using FlowOfReason.API.DataModels;

namespace FlowOfReason.API.Controllers;

public interface ILogicGraphController
{
    public string AddLogicGraph();
    public string RemoveLogicGraph(string graphId);
    public LogicGraph? GetLogicGraph(string graphId);
    public List<string> GetAllLogicGraphIds();
    public string UpdateLogicGraph(LogicGraph graph);
}

public class LogicGraphController(ILogicGraphFactory logicGraphFactory) : ILogicGraphController
{
    private readonly List<LogicGraph> _logicGraphs = new();
    
    private readonly ILogicGraphFactory _logicGraphFactory = logicGraphFactory ?? throw new ArgumentNullException(nameof(logicGraphFactory));

    public string AddLogicGraph()
    {
        var logicGraph = _logicGraphFactory.CreateLogicGraph();
        _logicGraphs.Add(logicGraph);
        Console.WriteLine($"Graph added: {logicGraph.Id}");
        return logicGraph.Id;
    }

    public string RemoveLogicGraph(string graphId)
    {
        var graphMatch = _logicGraphs.Find(g => g.Id == graphId);
        if (graphMatch == null)
        {
            Console.WriteLine($"Graph not found: {graphId}");
            return string.Empty;
        }

        _logicGraphs.Remove(graphMatch);
        Console.WriteLine($"Graph removed: {graphId}");
        return graphMatch.Id;
    }

    public LogicGraph? GetLogicGraph(string graphId)
    {
        var graphMatch = _logicGraphs.Find(g => g.Id == graphId);
        Console.WriteLine($"Graph retrieved: {graphId}");
        return graphMatch;
    }

    public List<string> GetAllLogicGraphIds()
    {
        var ids = _logicGraphs.Select(g => g.Id).ToList();
        Console.WriteLine($"All graphs returned: [{string.Join(',', ids)}]");
        return ids;
    }

    public string UpdateLogicGraph(LogicGraph graph)
    {
        var firstIndex = _logicGraphs.FindIndex(g => g.Id == graph.Id);
        if (firstIndex == -1)
        {
            Console.WriteLine($"Graph not found: {graph.Id}");
            return "";
        }
        _logicGraphs[firstIndex] = graph;
        Console.WriteLine($"Graph Updated: {graph.Id}");
        return graph.Id;

    }
}