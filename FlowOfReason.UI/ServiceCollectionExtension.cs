using FlowOfReason.Core.DataBases;
using FlowOfReason.Core.Factories;
using FlowOfReason.UI.Services;
using FlowOfReason.UI.ViewModels;
using FlowOfReason.UI.Views;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace FlowOfReason.UI;

public static class ServiceCollectionExtension
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        //Services
        collection.AddSingleton<IUserAccountService, UserAccountService>();
        collection.AddSingleton<ISearchingService, SearchingService>();
        collection.AddSingleton<IContextController, ContextController>();
        collection.AddSingleton<IInteractionsService, InteractionsService>();
        
        // View Models
        collection.AddTransient<MainWindowViewModel>();
        collection.AddTransient<ExistingNodePageViewModel>();
        collection.AddTransient<GraphSearchPageViewModel>();
        collection.AddTransient<GraphCreatePageViewModel>();
        collection.AddTransient<HomePageViewModel>();
        collection.AddTransient<UserAccountPageViewModel>();
        collection.AddTransient<GraphScatteredViewModel>();
        collection.AddTransient<GraphSearchGraphResultItemTemplateViewModel>();
        
        //Views
        collection.AddTransient<MainWindow>();
        collection.AddTransient<ExistingNodePage>();
        collection.AddTransient<GraphCreatePage>();
        collection.AddTransient<GraphSearchPage>();
        collection.AddTransient<HomePage>();
        collection.AddTransient<UserAccountPage>();
        collection.AddTransient<GraphScatteredView>();
        collection.AddTransient<GraphSearchGraphResultItemTemplate>();
        
        // Data Model Factories
        collection.AddSingleton<IDiscussionCommentFactory, DiscussionCommentFactory>();
        collection.AddSingleton<ILeadCommentFactory, LeadCommentFactory>();
        collection.AddSingleton<ILogicGraphFactory, LogicGraphFactory>();
        collection.AddSingleton<ILogicGraphNodeFactory, LogicGraphNodeFactory>();
        collection.AddSingleton<ILogicGraphNodeRelationshipFactory, LogicGraphNodeRelationshipFactory>();

        // Data Bases
        collection.AddEntityFrameworkSqlite();
        collection.AddSingleton<ILogicGraphDataBase, LogicGraphSqLiteDataBase>(c =>
            new LogicGraphSqLiteDataBase("logic-graph.sqlite"));
        collection.AddSingleton<ILogicGraphNodeDataBase, LogicGraphSqLiteNodeDataBase>(c =>
            new LogicGraphSqLiteNodeDataBase("logic-graph-node.sqlite"));
        collection.AddSingleton<ILeadCommentDataBase, LeadCommentSqLiteDataBase>(c =>
            new LeadCommentSqLiteDataBase("lead-comment.sqlite"));
        collection.AddSingleton<IDiscussionCommentDataBase, DiscussionCommentSqLiteDataBase>(c =>
            new DiscussionCommentSqLiteDataBase("discussion-comment.sqlite"));
        collection.AddSingleton<ILogicGraphNodeRelationshipDataBase, LogicGraphNodeRelationshipSqLiteDataBase>(c =>
            new LogicGraphNodeRelationshipSqLiteDataBase("logic-graph-node-relationship.sqlite"));
        collection.AddSingleton<IUserDataBase, UserSqLiteDataBase>(c =>
            new UserSqLiteDataBase("user.sqlite"));
    }
}