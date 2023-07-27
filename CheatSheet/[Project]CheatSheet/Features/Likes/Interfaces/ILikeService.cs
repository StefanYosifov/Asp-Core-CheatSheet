namespace _Project_CheatSheet.Features.Likes.Interfaces
{
    using Models;

    public interface ILikeService
    {
        public int GetCommentLikesCount(LikeCommentModel likeComment);

        public Task<string> LikeAComment(LikeCommentModel likeComment);

        public Task<string> RemoveLikeFromComment(LikeCommentModel likeComment);

        public int GetResourceLikesCount(string id);

        public Task<string> LikeAResource(LikeResourceModelAdd likeResource);

        public Task<string> RemoveLikeFromResource(LikeResourceModel likeResource);
        public Task<IEnumerable<LikeResourceModel>> ResourcesLikes();
    }
}