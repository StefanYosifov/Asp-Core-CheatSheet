namespace _Project_CheatSheet.Features.Likes.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LikeResourceModelAdd
    {
        [Required] public string ResourceId { get; set; } = null!;
    }
}