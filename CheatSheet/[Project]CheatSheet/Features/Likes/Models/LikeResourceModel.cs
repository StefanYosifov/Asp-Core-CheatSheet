namespace _Project_CheatSheet.Features.Likes.Models
{
    using _Project_CheatSheet.Infrastructure.Data.GlobalConstants.Likes;
    using System.ComponentModel.DataAnnotations;

    public class LikeResourceModel
    {
        [Required] public string ResourceId { get; set; } = null!;

        public bool HasLiked { get; set; }

        [Range(LikeConstants.MinTotalLikes, LikeConstants.MaxTotalLikes)]
        public int TotalLikes { get; set; }
    }
}