namespace FlowOfReason.Core;

public interface ILogicGraphNodeFactory
{
    public LogicGraphNode CreateLogicGraphNode(string logicGraphId);
}

public class LogicGraphNodeFactory : ILogicGraphNodeFactory
{
    public LogicGraphNode CreateLogicGraphNode(string logicGraphId)
    {
        return new LogicGraphNode
        {
            OwningLogicGraphId = logicGraphId,
        };
    }
}