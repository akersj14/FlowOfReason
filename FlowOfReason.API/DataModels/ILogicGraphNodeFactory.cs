namespace FlowOfReason.API.DataModels;

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
            Id = Guid.NewGuid().ToString(),
            OwningLogicGraphId = logicGraphId,
        };
    }
}