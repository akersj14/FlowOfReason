using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowOfReason.Core.DataBases;
using FlowOfReason.Core.DataModels;

namespace FlowOfReason.UI.Services;

public interface ISearchingService
{
    public Task<IEnumerable<LogicGraph>> SearchGraphs(string searchTerm);
    public Task<IEnumerable<LogicGraphNode>> SearchGraphNodes(string graphId, string searchTerm);
}

public class SearchingService(ILogicGraphDataBase logicGraphDataBase, ILogicGraphNodeDataBase logicGraphNodeDataBase)
    : ISearchingService
{
    private readonly ILogicGraphDataBase _logicGraphDataBase = logicGraphDataBase ?? throw new ArgumentNullException(nameof(logicGraphDataBase));
    private readonly ILogicGraphNodeDataBase _logicGraphNodeDataBase = logicGraphNodeDataBase ?? throw new ArgumentNullException(nameof(logicGraphNodeDataBase));

    public async Task<IEnumerable<LogicGraph>> SearchGraphs(string searchTerm)
    {
        return await _logicGraphDataBase.GetAllAsync();
    }

    public async Task<IEnumerable<LogicGraphNode>> SearchGraphNodes(string graphId, string searchTerm)
    {
        var result = await _logicGraphNodeDataBase.GetAllAsync();
        return result.Where(node => node.OwningLogicGraphId == graphId);
    }
}