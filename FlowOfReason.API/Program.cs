using System.Text.Json.Serialization;
using FlowOfReason.API;
using FlowOfReason.API.Controllers;
using FlowOfReason.API.DataModels;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

var logicGraphFactory = new LogicGraphFactory();
var logicGraphController = new LogicGraphController(logicGraphFactory);
var logicGraphNodeFactory = new LogicGraphNodeFactory();
var logicGraphNodeController = new LogicGraphNodeController(logicGraphNodeFactory);

var logicGraphApi = app.MapGroup("/LogicGraph");
logicGraphApi.MapGet("/", () => logicGraphController.GetAllLogicGraphIds());
logicGraphApi.MapGet("/{graphId}", (string graphId) => logicGraphController.GetLogicGraph(graphId));
logicGraphApi.MapPost("/{ownerId}", (string ownerId) => logicGraphController.AddLogicGraph(ownerId));
logicGraphApi.MapDelete("/{graphId}", (string graphId) => logicGraphController.RemoveLogicGraph(graphId));
logicGraphApi.MapPut("/", (LogicGraph graph) => logicGraphController.UpdateLogicGraph(graph));

var logicGraphNodeApi = app.MapGroup("/Node");
logicGraphNodeApi.MapGet("/", () => logicGraphNodeController.GetAllLogicGraphNodeIds());
logicGraphNodeApi.MapGet("/{nodeId}", (string nodeId) => logicGraphNodeController.GetLogicGraphNode(nodeId));
logicGraphNodeApi.MapPost("/{graphId}", (string graphId) => logicGraphNodeController.AddLogicGraphNode(graphId));
logicGraphNodeApi.MapDelete("/{nodeId}", (string nodeId) => logicGraphNodeController.RemoveLogicGraphNode(nodeId));
logicGraphNodeApi.MapPut("/", (LogicGraphNode node) => logicGraphNodeController.UpdateLogicGraphNode(node));

app.Run();

[JsonSerializable(typeof(LogicGraph))]
[JsonSerializable(typeof(LogicGraphNode))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}