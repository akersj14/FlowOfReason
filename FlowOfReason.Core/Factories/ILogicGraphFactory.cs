using FlowOfReason.Core.DataModels;

namespace FlowOfReason.Core.Factories;

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