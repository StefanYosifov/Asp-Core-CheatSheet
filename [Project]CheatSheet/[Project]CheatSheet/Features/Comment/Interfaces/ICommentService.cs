namespace _Project_CheatSheet.Features.Comment.Interfaces
{
    using Models;

    public interface ICommentService
    {
        public Task<IEnumerable<CommentModel>> GetCommentsFromResource(string resourceId);

        public Task<string> CreateAComment(InputCommentModel comment);

        public Task<string> EditComment(string id, EditCommentModel commentModel);

        public Task<string> DeleteComment(string id); //Todo Investigate why using isn't working
    }
}