using FlowOfReason.API.DataModels;

namespace FlowOfReason.API.Controllers;

public interface ILeadCommentController
{
    
    public string AddLeadComment(string ownerId, string owningNodeId);
    public string RemoveLeadComment(string commentId);
    public LeadComment? GetLeadComment(string commentId);
    public List<string> GetAllLeadCommentIds();
    public string UpdateLeadComment(LeadComment comment);
}

public class LeadCommentController(ILeadCommentFactory leadCommentFactory) : ILeadCommentController
{
    private readonly List<LeadComment> _leadComments = new();
    private readonly ILeadCommentFactory _leadCommentFactory = leadCommentFactory ?? throw new ArgumentNullException(nameof(leadCommentFactory));
    
    
    public string AddLeadComment(string ownerId, string owningNodeId)
    {
        var comment = _leadCommentFactory.CreateLeadComment(ownerId, owningNodeId);
        _leadComments.Add(comment);
        Console.WriteLine($"Lead Comment added: {comment.Id}");
        return comment.Id;
    }

    public string RemoveLeadComment(string commentId)
    {
        var nodeMatch = _leadComments.Find(c => c.Id == commentId);
        if (nodeMatch == null)
        {
            Console.WriteLine($"Lead Comment not found: {commentId}");
            return string.Empty;
        }

        _leadComments.Remove(nodeMatch);
        Console.WriteLine($"Lead Comment removed: {commentId}");
        return nodeMatch.Id;
    }

    public LeadComment? GetLeadComment(string commentId)
    {
        var commentMatch = _leadComments.Find(g => g.Id == commentId);
        Console.WriteLine($"Lead Comment retrieved: {commentId}");
        return commentMatch;
    }

    public List<string> GetAllLeadCommentIds()
    {
        var ids = _leadComments.Select(c => c.Id).ToList();
        Console.WriteLine($"All lead comments returned: [{string.Join(',', ids)}]");
        return ids;
    }

    public string UpdateLeadComment(LeadComment comment)
    {
        var firstIndex = _leadComments.FindIndex(c => c.Id == comment.Id && c.OwningLogicGraphNodeId == comment.OwningLogicGraphNodeId);
        if (firstIndex == -1)
        {
            Console.WriteLine($"Lead Comment not found: {comment.Id}");
            return "";
        }
        _leadComments[firstIndex] = comment;
        Console.WriteLine($"Lead Comment Updated: {comment.Id}");
        return comment.Id;
    }
}