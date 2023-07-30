namespace _Project_CheatSheet.Infrastructure.Data.SQL.Models
{
    using Base;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Constants.GlobalConstants.Topic;

    public class Topic : Entity
    {
        public Topic()
        {
            Id = Guid.NewGuid();
            TopicIssues = new HashSet<Issue>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TopicConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(TopicConstants.ContentMaxLength)]
        public string Content { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [ForeignKey(nameof(Course))] public Guid CourseId { get; set; }

        public Course Course { get; set; }

        [ForeignKey(nameof(Video))] public Guid VideoId { get; set; }

        public virtual Video Video { get; set; } = null!;
        public ICollection<Issue?> TopicIssues { get; set; }
    }
}