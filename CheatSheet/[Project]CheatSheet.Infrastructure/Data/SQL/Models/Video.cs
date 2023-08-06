namespace _Project_CheatSheet.Infrastructure.Data.SQL.Models
{
    using Base;
    using System.ComponentModel.DataAnnotations;

    public class Video : Entity
    {
        public Video()
        {
            Id=Guid.NewGuid();
            Topics = new HashSet<Topic>();
        }

        public Guid Id { get; set; }
        [Required] public string Name { get; set; } = null!;

        [Required] public string VideoUrl { get; set; } = null!;

        public ICollection<Topic> Topics { get; set; }
    }
}