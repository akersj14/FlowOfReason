namespace FlowOfReason.API.DataModels;

public interface ILogicGraphFactory
{
    public LogicGraph CreateLogicGraph();
}

public class LogicGraphFactory : ILogicGraphFactory
{
    public LogicGraph CreateLogicGraph()
    {
        return new LogicGraph
        {
            Id = Guid.NewGuid().ToString(),
        };
    }
}