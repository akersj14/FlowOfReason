namespace FlowOfReason.Core;

public interface ILogicGraphFactory
{
    public LogicGraph CreateLogicGraph();
}

public class LogicGraphFactory : ILogicGraphFactory
{
    public LogicGraph CreateLogicGraph()
    {
        return new LogicGraph();
    }
}