namespace _Project_CheatSheet.Common.Mapping
{
    using _Project_CheatSheet.Infrastructure.Data.MongoDb.Models;
    using _Project_CheatSheet.Infrastructure.Data.SQL.Models;

    using Area.AdminServices.Models;

    using AutoMapper;

    using Constants.GlobalConstants;

    using Features.Category.Models;
    using Features.Comment.Models;
    using Features.Course.Models;
    using Features.Identity.Models;
    using Features.Issue.Models;
    using Features.Likes.Models;
    using Features.Profile.Models;
    using Features.Resources.Models;
    using Features.Topics.Models;
    using UserService.Interfaces;

    public class MapperProfile : Profile
    {
        private readonly ICurrentUser userService;

        public MapperProfile(ICurrentUser userService)
        {
            this.userService = userService;

            //Likes
            CreateMap<LikeResourceModel, ResourceLike>()
                .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => Guid.Parse(src.ResourceId)));

            CreateMap<LikeResourceModelAdd, ResourceLike>()
                .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => Guid.Parse(src.ResourceId)));

            //Authentication
            CreateMap<RegisterModel, User>();

            //Profile
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.UserProfileDescription, opt => opt.MapFrom(src => src.ProfileDescription))
                .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.ProfilePictureUrl))
                .ForMember(dest => dest.UserJob, opt => opt.MapFrom(src => src.UserJob))
                .ForMember(dest => dest.UserEducation, opt => opt.MapFrom(src => src.UserEducation))
                .ForMember(dest => dest.UserProfileBackground, opt => opt.MapFrom(src => src.ProfileBackground));

            //Resources

            CreateMap<Resource, ResourceModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.DateTime,
                    opt => opt.MapFrom(src => src.CreatedOn.ToString(Formatter.DateFormatter)))
                .ForMember(dest => dest.TotalLikes,
                    opt => opt.MapFrom(src => src.ResourceLikes.Count(rl => rl.ResourceId == src.Id)))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName.ToString()))
                .ForMember(dest => dest.UserProfileImageUrl, opt => opt.MapFrom(src => src.User.ProfilePictureUrl))
                .ForMember(dest => dest.CategoryNames,
                    opt => opt.MapFrom(src => src.CategoryResources.Select(cr => cr.Category.Name)));

            CreateMap<Resource, DetailResources>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.DateTime,
                    opt => opt.MapFrom(src => src.CreatedOn.ToString(Formatter.DateFormatter)))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName.ToString()))
                .ForMember(dest => dest.UserImage, opt => opt.MapFrom(src => src.User.ProfilePictureUrl))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.ResourceLikes.Count))
                .ForMember(dest => dest.CategoryNames,
                    opt => opt.MapFrom(src => src.CategoryResources.Select(cr => cr.Category.Name)))
                .ForMember(dest => dest.UserImage, opt => opt.MapFrom(src => src.User.ProfilePictureUrl))
                .ForMember(dest => dest.CategoryNames,
                    opt => opt.MapFrom(src => src.CategoryResources.Select(c => c.Category.Name)))
                .ForMember(dest => dest.ResourceLikes,
                    opt => opt.MapFrom(src => src.ResourceLikes.Where(rl => rl.ResourceId == src.Id)))
                .ForMember(dest => dest.ResourceComments, opt => opt.MapFrom(src => src.Comments.Select(rc =>
                    new ResourceCommentModel
                    {
                        Id = rc.Id.ToString(),
                        Content = rc.Content
                    })));

            CreateMap<Resource, EditResources>();

            //ResourceCategories

            CreateMap<CategoryResource, CategoryModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src => src.CategoryId)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Category, CategoryModel>();

            //Comments

            CreateMap<Comment, CommentModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => src.CreatedOn.ToString(Formatter.DateFormatter)))
                .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => src.ResourceId.ToString()))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.UserProfileImage, opt => opt.MapFrom(src => src.User.ProfilePictureUrl))
                .ForMember(dest => dest.CommentLikes, opt => opt.MapFrom(src => src.CommentLikes.Select(cl =>
                    new CommentLikeModel
                    {
                        Id = src.CommentLikes.FirstOrDefault(l => l.CommentId == cl.CommentId).Id.ToString(),
                        CommentId = src.Id.ToString(),
                        CreatedOn = src.CreatedOn.ToString(Formatter.DateFormatter),
                        UserId = src.UserId
                    })))
                .ForMember(dest => dest.LikeCount, opt => opt.MapFrom(dest => dest.CommentLikes.Count));

            //Courses
            CreateMap<Course, CourseRespondModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics.Select(t => new TopicsRespondModel
                {
                    TopicId = t.Id.ToString(),
                    Name = t.Name
                })));

            CreateMap<Course, CourseRespondPaymentModel>()
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.CourseDescription, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StartTime,
                    opt => opt.MapFrom(src => src.StartDate.ToString(Formatter.DateOnlyFormatter)));

            CreateMap<Course, CourseRespondAllModel>()
                .BeforeMap((src, dest) => dest.HasPaid = false)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.TopicsCount, opt => opt.MapFrom(src => src.Topics.Count))
                .ForMember(dest => dest.StartDate,
                    opt => opt.MapFrom(src => src.StartDate.ToString(Formatter.DateOnlyFormatter)))
                .ForMember(dest => dest.EndDate,
                    opt => opt.MapFrom(src => src.EndDate.ToString(Formatter.DateOnlyFormatter)))
                .ForMember(dest => dest.Categories,
                    opt => opt.MapFrom(src => src.CategoryCourseCourses.Select(ccc => new
                        {
                            ccc.CategoryCourse,
                            ccc.CourseId
                        })
                        .Where(ccc => ccc.CourseId == src.Id)
                        .Select(cc => cc.CategoryCourse.Name)));

            CreateMap<Course, CourseRespondUpcomingModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.StartDate,
                    opt => opt.MapFrom(src => src.StartDate.ToString(Formatter.DateFormatter)))
                .ForMember(dest => dest.WeeksDuration,
                    opt => opt.MapFrom(src => (int)(src.EndDate - src.StartDate).TotalDays / 7))
                .ForMember(dest => dest.HasPaid,
                    opt => opt.MapFrom(src =>
                        src.UsersCourses.Any(uc => uc.CourseId == src.Id && uc.UserId == userService.GetUserId())));

            CreateMap<CourseDetails, CourseDetails>()
                .ForMember(dest => dest.TopicsCoverage, opt => opt.MapFrom(src => src.TopicsCoverage));


            //Topics

            CreateMap<Topic, TopicRespondModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.VideoId, opt => opt.MapFrom(src => src.VideoId.ToString()))
                .ForMember(dest => dest.VideoName, opt => opt.MapFrom(src => src.Video.Name));

            CreateMap<Topic, TopicsRespondModel>()
                .ForMember(dest => dest.TopicId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StarTime,
                    opt => opt.MapFrom(src => src.StartTime.ToString(Formatter.DateFormatter)))
                .ForMember(dest => dest.EndTime,
                    opt => opt.MapFrom(src => src.EndTime.ToString(Formatter.DateFormatter)));

            //Issues

            CreateMap<Issue, IssueRespondModel>()
                .ForMember(dest => dest.LocationIssue, opt => opt.MapFrom(src => src.CategoryIssue!.LocationIssue));

            CreateMap<IssueRespondModel, Issue>();

            CreateMap<IssueRequestModel, Issue>()
                .ForMember(dest => dest.CategoryIssueId, opt => opt.MapFrom(src => src.IssueCategoryId));

            CreateMap<CategoryIssue, IssueCategoryModel>();


            //Administrator area
            CreateMap<Course, ResourceAdminModel>()
                .ForMember(dest=>dest.Name,opt=>opt.MapFrom(src=>src.Title));
        }
    }
}