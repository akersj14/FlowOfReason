using FlowOfReason.Core;
using FlowOfReason.Core.DataModels;
using FlowOfReason.Core.Factories;

namespace FlowOfReason.API.Controllers;

public interface IDiscussionCommentController
{
    
    public string AddDiscussionComment(string ownerId, string owningLeadCommentId);
    public string RemoveDiscussionComment(string commentId);
    public DiscussionComment? GetDiscussionComment(string commentId);
    public List<string> GetAllDiscussionCommentIds();
    public string UpdateDiscussionComment(DiscussionComment comment);
}


public class DiscussionCommentController(IDiscussionCommentFactory discussionCommentFactory) : IDiscussionCommentController
{
    private readonly List<DiscussionComment> _discussionComments = new();
    private readonly IDiscussionCommentFactory _discussionCommentFactory = discussionCommentFactory ?? throw new ArgumentNullException(nameof(discussionCommentFactory));
    
    
    public string AddDiscussionComment(string ownerId, string owningLeadCommentId)
    {
        var comment = _discussionCommentFactory.CreateDiscussionComment(ownerId, owningLeadCommentId);
        _discussionComments.Add(comment);
        Console.WriteLine($"Discussion Comment added: {comment.Id}");
        return comment.Id;
    }

    public string RemoveDiscussionComment(string commentId)
    {
        var nodeMatch = _discussionComments.Find(c => c.Id == commentId);
        if (nodeMatch == null)
        {
            Console.WriteLine($"Discussion Comment not found: {commentId}");
            return string.Empty;
        }

        _discussionComments.Remove(nodeMatch);
        Console.WriteLine($"Discussion Comment removed: {commentId}");
        return nodeMatch.Id;
    }

    public DiscussionComment? GetDiscussionComment(string commentId)
    {
        var commentMatch = _discussionComments.Find(g => g.Id == commentId);
        Console.WriteLine($"Discussion Comment retrieved: {commentId}");
        return commentMatch;
    }

    public List<string> GetAllDiscussionCommentIds()
    {
        var ids = _discussionComments.Select(c => c.Id).ToList();
        Console.WriteLine($"All Discussion comments returned: [{string.Join(',', ids)}]");
        return ids;
    }

    public string UpdateDiscussionComment(DiscussionComment comment)
    {
        var firstIndex = _discussionComments.FindIndex(c => c.Id == comment.Id && c.OwningLeadCommentId == comment.OwningLeadCommentId);
        if (firstIndex == -1)
        {
            Console.WriteLine($"Discussion Comment not found: {comment.Id}");
            return "";
        }
        _discussionComments[firstIndex] = comment;
        Console.WriteLine($"Discussion Comment Updated: {comment.Id}");
        return comment.Id;
    }
}