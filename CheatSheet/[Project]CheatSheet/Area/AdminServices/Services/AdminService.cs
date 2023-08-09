namespace _Project_CheatSheet.Area.AdminServices.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Common.Exceptions;
    using Common.Pagination;
    using Common.Repositories.MongoRepository;

    using Constants.GlobalConstants.Course;
    using Constants.GlobalConstants.Issue;
    using Constants.GlobalConstants.Topic;

    using Features.Category.Models;
    using Features.Course.Enums;
    using Features.Issue.Enums;

    using Infrastructure.Data.MongoDb.Models;
    using Infrastructure.Data.SQL;
    using Infrastructure.Data.SQL.Models;

    using Interfaces;

    using Microsoft.EntityFrameworkCore;

    using Models.Courses;
    using Models.Issues;

    public class AdminService : IAdminService
    {
        private const byte IssuePerPage = 15;

        private readonly CheatSheetDbContext context;
        private readonly ICourseDetailsService detailContext;
        private readonly IMapper mapper;

        public AdminService(
            CheatSheetDbContext context,
            IMapper mapper,
            ICourseDetailsService detailContext)
        {
            this.context = context;
            this.mapper = mapper;
            this.detailContext = detailContext;
        }

        public async Task<ICollection<ResourceAdminModel>> GetListOfCourses(ResourceAdminQueryModel query)
        {
            var courses = context.Courses.AsNoTracking();

            if (!string.IsNullOrEmpty(query.Search))
            {
                var wildcard = $"%{query.Search.ToLower()}%";

                courses = courses.Where(c => EF.Functions.Like(c.Title.ToLower(), wildcard));
            }

            if (!string.IsNullOrWhiteSpace(query.CategoryName))
            {
                courses = courses.Where(c =>
                    c.CategoryCourseCourses
                        .Any(cc => cc.CategoryCourse.Name == query.CategoryName));
            }

            if (query.CourseActivity != null && query.CourseActivity.ToString() != "All")
            {
                courses = query.CourseActivity switch
                {
                    CourseFilters.Active => courses.Where(c => c.StartDate > DateTime.UtcNow),
                    CourseFilters.Passed => courses.Where(c => c.StartDate < DateTime.UtcNow),
                    CourseFilters.OnGoing => courses.Where(c =>
                        c.StartDate < DateTime.UtcNow && c.EndDate > DateTime.UtcNow)
                };
            }

            return await courses.ProjectTo<ResourceAdminModel>(mapper.ConfigurationProvider).ToArrayAsync();
        }

        public async Task<ICollection<CoursePrimaryDetailsAdminModel>> GetCourseTopicAndVideo(string courseId)
        {
            var topics = await context.Topics
                .Include(t => t.Course)
                .Include(t => t.Video)
                .Where(t => t.Course.Id.ToString().ToLower() == courseId)
                .ProjectTo<CoursePrimaryDetailsAdminModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();

            return topics;
        }

        public async Task<CourseSecondaryDetailsEditAdminModel> GetCourseSecondaryDetails(string topicId)
        {
            var topicDetails = mapper.Map<CourseSecondaryDetailsEditAdminModel>(await context.Topics
                .Include(t => t.Course)
                .Include(t => t.Video)
                .FirstOrDefaultAsync(t => t.Id.ToString().ToLower() == topicId.ToLower()));

            var topic = mapper.Map<CourseSecondaryDetailsEditAdminModel>(
                await context.Topics
                    .FindAsync(Guid.Parse(topicId)));

            Console.WriteLine();
            return topicDetails;
        }

        public async Task<string> UpdateCourseSecondaryDetails(string topicId,
            CourseSecondaryDetailsEditAdminModel updatedTopic)
        {
            var topic = await context.Topics
                .Include(t => t.Video)
                .FirstOrDefaultAsync(t => t.Id == Guid.Parse(topicId));

            CustomException.ThrowIfNull(topic, TopicMessages.TopicDoesNotExist);

            try
            {
                topic.StartTime = DateTime.Parse(updatedTopic.StartTime);
                topic.EndTime = DateTime.Parse(updatedTopic.EndTime);
                topic.Name = updatedTopic.TopicName;
                topic.Content = updatedTopic.TopicContent;
                topic.Video.Name = updatedTopic.VideoName;
                topic.Video.VideoUrl = updatedTopic.VideoUrl;
                await context.SaveChangesAsync();
                return TopicMessages.SuccessfullyEditedTopic;
            }
            catch (Exception e)
            {
                throw new ServiceException(TopicMessages.EditingTopicFailed);
            }
        }

        public async Task<string> CreateCourse(CreateCourseAdminModel createdCourse)
        {
            var course = mapper.Map<Course>(createdCourse);

            if (course.EndDate <= course.StartDate)
            {
                return CourseMessages.EndDateBeforeStartDate;
            }

            context.Add((object)course);
            await context.SaveChangesAsync();

            var courseDetails = mapper.Map<CourseDetails>(createdCourse);
            courseDetails.TopicsCoverage = createdCourse.CourseCoverage
                .Trim()
                .Split("&");
            courseDetails.CourseId = course.Id.ToString();

            var succeededToSaveTheDetails = await detailContext.Create(courseDetails);

            if (succeededToSaveTheDetails == false)
            {
                throw new ServiceException(CourseMessages.UnSuccessfullyCreatedCourse);
            }

            return CourseMessages.SuccessfullyCreatedCourse;
        }

        public async Task<string> AddTopicToCourse(string courseName, TopicCreateDetailsAdminModel createdTopic)
        {
            var findCourse = await context
                .Courses
                .Select(c => new
                {
                    c.Id,
                    c.Title
                })
                .FirstOrDefaultAsync(c => c.Title.ToLower() == courseName.ToLower());

            CustomException.ThrowIfNull(findCourse, CourseMessages.CourseNotFound);

            var videoToAdd = mapper.Map<Video>(createdTopic);
            await context.AddAsync(videoToAdd);
            await context.SaveChangesAsync();

            var createTopic = mapper.Map<Topic>(createdTopic);

            createTopic.VideoId = videoToAdd.Id;
            createTopic.CourseId = findCourse.Id;
            await context.AddAsync(createTopic);
            await context.SaveChangesAsync();

            return TopicMessages.SuccessfullyAddedATopic;
        }

        public async Task<PaginatedIssuesAdminModel> GetIssues(IssueQueryModel query)
        {
            var issues = context.Issues.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                var wildcard = $"%{query.Search.ToLower()}%";

                issues = issues
                    .Where(i => EF.Functions.Like(i.Title.ToLower(), wildcard));
            }

            if (!string.IsNullOrWhiteSpace(query.SelectedCourseName))
            {
                issues = issues
                    .Where(i => i.Title == query.SelectedCourseName);
            }

            issues = query.Sorting switch
            {
                IssueSorting.Deleted => issues.OrderBy(i => i.IsDeleted),
                IssueSorting.Newest => issues.OrderByDescending(i => i.CreatedOn),
                IssueSorting.Oldest => issues.OrderBy(i => i.CreatedOn)
            };

            var filteredIssues = issues.ProjectTo<GetIssuesAdminModel>(mapper.ConfigurationProvider);

            var paginatedResult =
                await Pagination<GetIssuesAdminModel>.CreateAsync(filteredIssues, query.PageNumber, IssuePerPage);

            var paginatedIssues = new PaginatedIssuesAdminModel
            {
                Issues = paginatedResult,
                TotalPages = paginatedResult.Count / IssuePerPage + 1
            };

            return paginatedIssues;
        }

        public async Task<IssueFilteringAdminModel> GetFilteringData()
        {

            var test =
                await context
                    .Courses
                    .Where(c => c.Topics.Any(t => t.TopicIssues.Count >= 1))
                    .ToArrayAsync();

            var findCoursesWithIssues =
                await context
                    .Courses
                    .Where(c => c.Topics.Any(t => t.TopicIssues.Count >= 1))
                    .Select(c=>new IssueViewModel()
                    {
                        Id = c.Topics
                            .SelectMany(t => t.TopicIssues)
                            .Select(ti => ti.Id)
                            .FirstOrDefault(),
                        Title = c.Title

                    })
                    .ToArrayAsync();

            var issueCategories = ((IssueSorting[])Enum.GetValues(typeof(IssueSorting)))
                .Select(s => new SortingModel
                {
                    Id = (int)s,
                    Name = s.ToString()
                })
                .ToArray();

            return new IssueFilteringAdminModel
            {
                Courses = findCoursesWithIssues,
                IssueSorting = issueCategories
            };
        }

        public async Task<string> ResolveIssue(int issueId)
        {
            var findIssue = await context.Issues.FindAsync(issueId);

            ServiceException.ThrowIfNull(findIssue,IssueMessages.NotFound);

            context.Remove(findIssue);
            await context.SaveChangesAsync();
            return IssueMessages.SuccessfullyDeletedIssue;
        }
    }
}