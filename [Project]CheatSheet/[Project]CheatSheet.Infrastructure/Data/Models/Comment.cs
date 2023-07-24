﻿namespace _Project_CheatSheet.Infrastructure.Data.Models
{
    using Base;
    using GlobalConstants.Comment;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment : DeletableEntity
    {
        public Comment()
        {
            CommentLikes = new HashSet<CommentLike>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(CommentConstants.ContentMaxLength)]
        public string Content { get; set; } = null!;

        [ForeignKey(nameof(User))] public string UserId { get; set; } = null!;

        public User User { get; set; } = null!;

        [ForeignKey(nameof(Resource))] public Guid ResourceId { get; set; }

        public Resource Resource { get; set; } = null!;
        public ICollection<CommentLike> CommentLikes { get; set; }
    }
}