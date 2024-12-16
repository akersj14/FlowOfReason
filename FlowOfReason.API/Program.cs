using System.Text.Json.Serialization;
using FlowOfReason.API;
using FlowOfReason.API.Controllers;
using FlowOfReason.Core;

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
var leadCommentFactory = new LeadCommentFactory();
var leadCommentController = new LeadCommentController(leadCommentFactory);
var discussionCommentFactory = new DiscussionCommentFactory();
var discussionCommentController = new DiscussionCommentController(discussionCommentFactory);

var logicGraphApi = app.MapGroup("/LogicGraph");
logicGraphApi.MapGet("/", () => logicGraphController.GetAllLogicGraphIds());
logicGraphApi.MapGet("/{graphId}", (string graphId) => logicGraphController.GetLogicGraph(graphId));
logicGraphApi.MapPost("/", () => logicGraphController.AddLogicGraph());
logicGraphApi.MapDelete("/{graphId}", (string graphId) => logicGraphController.RemoveLogicGraph(graphId));
logicGraphApi.MapPut("/", (LogicGraph graph) => logicGraphController.UpdateLogicGraph(graph));

var logicGraphNodeApi = app.MapGroup("/Node");
logicGraphNodeApi.MapGet("/", () => logicGraphNodeController.GetAllLogicGraphNodeIds());
logicGraphNodeApi.MapGet("/{nodeId}", (string nodeId) => logicGraphNodeController.GetLogicGraphNode(nodeId));
logicGraphNodeApi.MapPost("/{graphId}", (string graphId) => logicGraphNodeController.AddLogicGraphNode(graphId));
logicGraphNodeApi.MapDelete("/{nodeId}", (string nodeId) => logicGraphNodeController.RemoveLogicGraphNode(nodeId));
logicGraphNodeApi.MapPut("/", (LogicGraphNode node) => logicGraphNodeController.UpdateLogicGraphNode(node));

var leadCommentApi = app.MapGroup("/LeadComment");
leadCommentApi.MapGet("/", () => leadCommentController.GetAllLeadCommentIds());
leadCommentApi.MapGet("/{commentId}", (string commentId) => leadCommentController.GetLeadComment(commentId));
leadCommentApi.MapPost("/{nodeId}/{ownerId}", (string nodeId, string ownerId) => leadCommentController.AddLeadComment(ownerId, nodeId));
leadCommentApi.MapDelete("/{commentId}", (string commentId) => leadCommentController.RemoveLeadComment(commentId));
leadCommentApi.MapPut("/", (LeadComment comment) => leadCommentController.UpdateLeadComment(comment));

var discussionCommentApi = app.MapGroup("/DiscussionComment");
discussionCommentApi.MapGet("/", () => discussionCommentController.GetAllDiscussionCommentIds());
discussionCommentApi.MapGet("/{commentId}", (string commentId) => discussionCommentController.GetDiscussionComment(commentId));
discussionCommentApi.MapPost("/{nodeId}/{ownerId}", (string nodeId, string ownerId) => discussionCommentController.AddDiscussionComment(ownerId, nodeId));
discussionCommentApi.MapDelete("/{commentId}", (string commentId) => discussionCommentController.RemoveDiscussionComment(commentId));
discussionCommentApi.MapPut("/", (DiscussionComment comment) => discussionCommentController.UpdateDiscussionComment(comment));


app.Run();

[JsonSerializable(typeof(LogicGraph))]
[JsonSerializable(typeof(LogicGraphNode))]
[JsonSerializable(typeof(LeadComment))]
[JsonSerializable(typeof(DiscussionComment))]
[JsonSerializable(typeof(LogicGraphNodeRelationship))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}