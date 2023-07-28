namespace _Project_CheatSheet.Infrastructure.Data.Models;

using Base.Interfaces;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

using Constants.GlobalConstants.User;

public class User : IdentityUser, IEntity
{
    public User()
    {
        Resources = new HashSet<Resource>();
        ResourceLikes = new HashSet<ResourceLike>();
        CommentLikes = new HashSet<CommentLike>();
        Comments = new HashSet<Comment>();
        UserCourses = new HashSet<UserCourses>();
        Issue = new HashSet<Issue>();
    }

    [Url] public string? ProfilePictureUrl { get; set; }

    [MaxLength(UserConstants.DescriptionMaxLength)]
    public string? ProfileDescription { get; set; }

    [MaxLength(UserConstants.BackGroundImageMaxLength)]
    public string? ProfileBackground { get; set; }

    [MaxLength(UserConstants.EducationMaxLength)]
    public string? UserEducation { get; set; }

    [MaxLength(UserConstants.JobMaxLength)]
    public string? UserJob { get; set; }

    public ICollection<Resource> Resources { get; set; }
    public ICollection<ResourceLike> ResourceLikes { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<CommentLike> CommentLikes { get; set; }
    public ICollection<UserCourses> UserCourses { get; set; }
    public ICollection<Issue> Issue { get; set; }
    public DateTime DeletedOn { get; set; }
    public string? DeletedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime UpdatedOn { get; set; }
    public string? UpdatedBy { get; set; }
}