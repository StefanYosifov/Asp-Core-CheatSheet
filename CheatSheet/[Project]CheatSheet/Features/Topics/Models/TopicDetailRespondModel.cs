namespace _Project_CheatSheet.Features.Topics.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TopicDetailRespondModel
    {
        [Required] public string Id { get; set; } = null!;

        [Required] public string Name { get; set; } = null!;

        [Required] public string Content { get; set; } = null!;

        [Required] public string CourseName { get; set; } = null!;

        [Required] public string VideoId { get; set; } = null!;

        [Required] public string VideoName { get; set; } = null!;

        [Required] public string VideoUrl { get; set; } = null!;
    }
}