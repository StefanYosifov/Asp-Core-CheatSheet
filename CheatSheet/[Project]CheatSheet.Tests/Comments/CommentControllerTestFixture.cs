using _Project_CheatSheet.Features.Comment.Interfaces;

using Moq;

namespace _Project_CheatSheet.Tests.Comments;

public class CommentControllerTestFixture : IDisposable
{
    public ICommentService CommentService { get; }

    public CommentControllerTestFixture()
    {
        var mockCommentService = new Mock<ICommentService>();

        CommentService = mockCommentService.Object;
    }

    public void Dispose()
    {
        // Perform any cleanup here if needed
    }
}